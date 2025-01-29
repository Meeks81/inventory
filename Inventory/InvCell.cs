using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace InventorySystem
{

    public class InvCell : MonoBehaviour, IPointerClickHandler
    {

        [SerializeField] private Image m_iconImage;
        [SerializeField] private TMP_Text m_countText;

        public InvItemData Item { get; private set; }
        public InvItemContent ItemContent { get; private set; }

        private Inventory _inventory;

        public void Init(Inventory inventory)
        {
            _inventory = inventory;
        }

        private void OnEnable()
        {
            UpdateUI();
        }

        public bool PutItem(InvItemData putItem, InvItemContent itemContent = default)
        {
            if (Item.id != putItem.id && string.IsNullOrEmpty(Item.id) == false)
                return false;
            if (putItem.count <= 0)
                return false;

            Item = new InvItemData()
            {
                id = string.IsNullOrEmpty(Item.id) ? putItem.id : Item.id,
                count = Item.count + putItem.count
            };
            ItemContent = itemContent;
            UpdateUI();
            return true;
        }

        public bool TakeItem(InvItemData takeItem)
        {
            if (string.IsNullOrEmpty(Item.id) || Item.id != takeItem.id || Item.count <= 0)
                return false;

            int newCount = Item.count - takeItem.count;
            if (newCount <= 0)
            {
                Clear();
            }
            else
            {
                Item = new InvItemData()
                {
                    id = Item.id,
                    count = newCount
                };
            }
            UpdateUI();
            return true;
        }

        public void Clear()
        {
            Item = default;
            ItemContent = default;
        }

        public void UpdateUI()
        {
            m_iconImage.gameObject.SetActive(string.IsNullOrEmpty(Item.id) == false);
            m_countText.gameObject.SetActive(string.IsNullOrEmpty(Item.id) == false);
            if (string.IsNullOrEmpty(Item.id))
                return;

            m_iconImage.sprite = ItemContent.sprite;
            m_countText.text = $"x{Item.count}";
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            _inventory.InfoPanel.SetItem(this);
        }

    }

}
using UnityEngine;

namespace InventorySystem
{

    public class Inventory : MonoBehaviour
    {

        [SerializeField] protected InvItemsContainer m_itemsContainer;
        [SerializeField] private InvCell[] m_cells;
        [Space]
        [SerializeField] private InventoryInfoPanel m_infoPanel;

        public InvCell[] Cells => m_cells;

        public InventoryInfoPanel InfoPanel => m_infoPanel;

        public void Init(InvItemData[] items)
        {
            for (int i = 0; i < Cells.Length; i++)
            {
                Cells[i].Clear();
                Cells[i].Init(this);
                if (i < items.Length)
                    Cells[i].PutItem(items[i], GetItemContent(items[i].id));
            }
        }

        public virtual bool PutItem(InvItemData putItem)
        {
            bool result = false;
            foreach (var item in Cells)
            {
                result = item.PutItem(putItem);
                if (result)
                    break;
            }
            return result;
        }

        public virtual bool TakeItem(InvItemData takeItem)
        {
            bool result = false;
            foreach (var item in Cells)
            {
                result = item.TakeItem(takeItem);
                if (result)
                    break;
            }
            return result;
        }

        public virtual int GetItemCount(string itemId)
        {
            int count = 0;
            foreach (var cell in Cells)
            {
                if (cell.Item.id == itemId)
                {
                    count += cell.Item.count;
                }
            }
            return count;
        }

        public InvItemContent GetItemContent(string itemId)
        {
            return m_itemsContainer.Items.Find(e => e.id == itemId);
        }

    }

}
using InventorySystem;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryInfoPanel : MonoBehaviour
{

    [SerializeField] private TMP_Text m_descriptionText;
    [SerializeField] private Button m_methodButton;
    [Space]
    [SerializeField] private InventoryMethods m_methods;

    public void SetItem(InvCell cell)
    {
        m_descriptionText.text = cell.ItemContent.description;
        m_methodButton.gameObject.SetActive(false);
        m_methodButton.onClick.RemoveAllListeners();
        if (cell.Item.id == ItemsIDs.Cristales)
        {
            m_methodButton.onClick.AddListener(() => m_methods.SellCristalls(cell));
            m_methodButton.gameObject.SetActive(true);
        }
    }

}

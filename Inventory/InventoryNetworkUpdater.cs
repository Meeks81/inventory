using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InventorySystem {

    public class InventoryNetworkUpdater : MonoBehaviour
    {

        [SerializeField] private InventoryNetwork m_inventoryNetwork;

        private void OnEnable()
        {
            m_inventoryNetwork.LoadItems();
        }

    }

}
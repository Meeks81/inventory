using System.Collections.Generic;
using UnityEngine;

namespace InventorySystem {

    [CreateAssetMenu(fileName = "Items Container", menuName = "Inventory/Items Container")]
    public class InvItemsContainer : ScriptableObject
    {

        public List<InvItemContent> Items;

    }

}
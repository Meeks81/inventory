using AccountSystem;
using UnityEngine;

namespace InventorySystem
{

    public class InventoryMethods : MonoBehaviour
    {

        public void SellCristalls(InvCell cell)
        {
            if (cell.Item.id != ItemsIDs.Cristales)
                return;
            int price = 0;
            DatabaseNetwork.Instance.Send(new WWWForm(), "cristales-get-price.php",
                (data) =>
                {
                    int price = System.Convert.ToInt32(data) * cell.Item.count;
                    if (price > 0)
                    {
                        WWWForm form = new WWWForm();
                        form.AddField("username", AccountNetwork.Instance.userData.username);
                        form.AddField("type", 1);
                        form.AddField("item-id", ItemsIDs.Cristales);
                        form.AddField("gold-amount", price);
                        form.AddField("item-amount", cell.Item.count);
                        DatabaseNetwork.Instance.Send(form, "gold-item-exchange.php",
                            (data) =>
                            {
                                InventoryNetwork inventoryNetwork = FindFirstObjectByType<InventoryNetwork>();
                                inventoryNetwork.LoadItems();
                            },
                            (error) =>
                            {

                            });
                    }
                },
                (error) =>
                {

                });
        }

    }

}
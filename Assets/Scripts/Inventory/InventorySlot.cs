using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour {

    public Image icon;
    public Button removeButton;
    Item item;

    //Adds an item to the slot, makes icons visible
    public void AddItem(Item newItem)
    {
        item = newItem;

        icon.sprite = item.icon;
        icon.enabled = true;
        removeButton.interactable = true;
    }

    //Disables the remove icon, its clickability and the item icon
    public void ClearSlot()
    {
        item = null;

        icon.sprite = null;
        icon.enabled = false;
        removeButton.interactable = false;
    }

    //Removes the item from the inventory
    public void OnRemoveButton()
    {
        Inventory.instance.Remove(item);
    }

    //Called on slot click
    public void UseItem()
    {
        if (item != null)
            item.Use();
    }
}

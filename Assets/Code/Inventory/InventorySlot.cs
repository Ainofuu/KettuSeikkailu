using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Image icon;
    public Button removeButton;
    public GameObject dropMenu;

    Item item;

    public void AddItem(Item newItem)
    {
        item = newItem;

        icon.sprite = item.icon;
        icon.enabled = true;
        removeButton.interactable = true;
    }

    public void ClearSlot()
    {
        item = null;

        icon.sprite = null;
        icon.enabled = false;
        removeButton.interactable = false;
    }

    public void OnRemoveButton()
    {
        Inventory.instance.Remove(item);
        dropMenu.SetActive(false);
    }

    public void UseItem()
    {
        if (item != null)
        {
            item.Use();
            dropMenu.SetActive(false);
        }
    }

    public void OnClickItemSlot()
    {
        if (item != null && !dropMenu.activeSelf)
            dropMenu.SetActive(true);
        else if (item != null && dropMenu.activeSelf)
            dropMenu.SetActive(false);
    }
}

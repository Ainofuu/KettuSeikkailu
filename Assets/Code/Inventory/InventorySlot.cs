using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventorySlot : MonoBehaviour
{
    public Image icon;
    public GameObject dropMenu;
    public GameObject namePopup;

    Item item;

    public void AddItem(Item newItem)
    {
        item = newItem;

        icon.sprite = item.icon;
        icon.enabled = true;
    }

    public void ClearSlot()
    {
        item = null;

        icon.sprite = null;
        icon.enabled = false;
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

    public void OnCombineButton()
    {
        CombineManager.instance.SetItem(item);
    }

    public void OnClickItemSlot()
    {
        if (item != null && !dropMenu.activeSelf)
            dropMenu.SetActive(true);
        else if (item != null && dropMenu.activeSelf)
            dropMenu.SetActive(false);
    }

    public void OnMouseEnterInvSlot()
    {
        if (item == null)
            return;

        namePopup.SetActive(true);
        namePopup.GetComponentInChildren<TextMeshProUGUI>().text = item.name;
    }

    public void OnMouseExitInvSlot()
    {
        if (item == null)
            return;

        namePopup.SetActive(false);
    }
}

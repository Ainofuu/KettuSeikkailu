using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EquipSlot : MonoBehaviour
{
    public Image icon;
    public GameObject namePopup;

    public TextMeshProUGUI damageValue;
    public TextMeshProUGUI armorValue;
    
    Equipment equipment;

    public void AddItem(Equipment newEquipment)
    {
        equipment = newEquipment;

        icon.sprite = equipment.icon;
        icon.enabled = true;

        damageValue.text = newEquipment.damageModifier.ToString() + " Damage";
        armorValue.text = newEquipment.armorModifier.ToString() + " Armor";
    }

    public void ClearSlot()
    {
        equipment = null;

        icon.sprite = null;
        icon.enabled = false;

        damageValue.text = null;
        armorValue.text = null;
    }

    public void OnClickEquipSlot()
    {
        if (equipment != null)
            EquipmentManager.instance.Unequip((int)equipment.equipSlot);
    }

    public void OnMouseEnterInvSlot()
    {
        if (equipment == null)
            return;

        namePopup.SetActive(true);
        namePopup.GetComponentInChildren<TextMeshProUGUI>().text = equipment.name;
    }

    public void OnMouseExitInvSlot()
    {
        namePopup.SetActive(false);
    }
}

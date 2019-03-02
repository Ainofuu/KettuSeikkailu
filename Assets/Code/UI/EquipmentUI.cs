using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentUI : MonoBehaviour
{
    public Transform itemsParent;
    public GameObject equipmentUI;

    Equipment[] currentEquipment;

    EquipSlot[] slots;
    
    void Start()
    {
        EquipmentManager.instance.onEquipmentChanged += UpdateUI;

        currentEquipment = EquipmentManager.instance.GetCurrentEquipment();
        slots = itemsParent.GetComponentsInChildren<EquipSlot>();
    }
    
    void Update()
    {
        if (Input.GetButtonDown("Equipment"))
        {
            equipmentUI.SetActive(!equipmentUI.activeSelf);
        }
    }

    void UpdateUI(Equipment newEquip, Equipment oldEquip)
    {
        for (int i = 0; i < currentEquipment.Length; i++)
        {
            if (currentEquipment[i] != null)
            {
                slots[i].AddItem(currentEquipment[i]);
            }
            else
            {
                slots[i].ClearSlot();
            }
        }
    }
}

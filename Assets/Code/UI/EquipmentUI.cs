using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentUI : MonoBehaviour
{
    public Transform itemsParent;
    public GameObject equipmentUI;

    Equipment[] currentEquipment;

    InventorySlot[] slots;

    // Start is called before the first frame update
    void Start()
    {
        currentEquipment = EquipmentManager.instance.GetCurrentEquipment();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Equipment"))
        {

        }
    }

    void UpdateUI()
    {
        for (int i = 0; i < currentEquipment.Length; i++)
        {

        }
    }
}

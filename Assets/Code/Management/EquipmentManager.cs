﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour
{
    #region Singleton

    public static EquipmentManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one instance of EquipmentManager" +
                " found!");
            return;
        }

        instance = this;

        int numberOfSlots = System.Enum.GetNames(typeof(EquipmentSlot)).Length;
        currentEquipment = new Equipment[numberOfSlots];
    }

    #endregion

    public delegate void OnEquipmentChanged(Equipment newItem, Equipment oldItem);
    public OnEquipmentChanged onEquipmentChanged;

    Equipment[] currentEquipment;
    Inventory inventory;

    void Start()
    {
        inventory = Inventory.instance;

        
    }

    public void Equip(Equipment newItem)
    {
        int slotIndex = (int)newItem.equipSlot;

        Equipment oldItem = null;

        if (currentEquipment[slotIndex] != null)
        {
            oldItem = currentEquipment[slotIndex];
            inventory.Add(oldItem);
        }

        currentEquipment[slotIndex] = newItem;

        if (onEquipmentChanged != null)
        {
            onEquipmentChanged(newItem, oldItem);
        }
    }

    public void Unequip(int slotIndex)
    {
        if (currentEquipment[slotIndex] != null)
        {
            Equipment oldItem = currentEquipment[slotIndex];
            inventory.Add(oldItem);

            currentEquipment[slotIndex] = null;

            if (onEquipmentChanged != null)
            {
                onEquipmentChanged(null, oldItem);
            }
        }
    }

    public void UnequipAll()
    {
        for (int i = 0; i < currentEquipment.Length; i++)
        {
            Unequip(i);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            UnequipAll();
        }
    }

    public Equipment GetCurrentEquipment(EquipmentSlot equipmentSlot)
    {
        return currentEquipment[(int)equipmentSlot];
    }

    public Equipment[] GetCurrentEquipment()
    {
        return currentEquipment;
    }
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookingStation : Interactable
{
    Fire fire;

    public override void Interact()
    {
        base.Interact();

        Cook();
        StartCoroutine(LightFire());
    }

    void Cook()
    {
        // Get the current item the player has equiped in WEAPON slot. This needs to be a bit more elegant in the future.
        Item ingredient = EquipmentManager.instance.GetCurrentEquipment(EquipmentSlot.Weapon);

        if (ingredient == null)
            return;

        CookingRecipe recipe = CookingManager.instane.GetRecipe(ingredient);

        if (recipe != null)
        {
            // Shouldn't even use equipment. change in future.
            EquipmentManager.instance.Unequip((int)EquipmentSlot.Weapon);
            // Unequip moves item to inventory. Must delete from there too.
            Inventory.instance.Remove(ingredient);

            Item result = recipe.result;
            float duration = recipe.cookingTime;
            StartCoroutine(CookingProcess(result, duration));
        }
    }

    IEnumerator CookingProcess(Item result, float duration)
    {
        yield return new WaitForSeconds(duration);
        Inventory.instance.Add(result);
    }
    
    IEnumerator LightFire()
    {
        fire = GetComponent<Fire>();
        if (fire != null)
        {
            fire.LightFire();
            while (isFocus)
            {
                yield return null;
            }
            fire.TurnOffFire();
        }
    }
}

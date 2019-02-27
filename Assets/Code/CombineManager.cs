using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombineManager : MonoBehaviour
{
    #region Singleton

    public static CombineManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Found more than one CombineManager!");
            return;
        }

        instance = this;
    }

    #endregion

    Item firstItem;
    Item secondItem;
    bool firstItemSet = false;

    public List<Recipe> recipes = new List<Recipe>();

    public void SetItem(Item item)
    {
        if (!firstItemSet)
        {
            firstItem = item;
            Debug.Log("Set " + firstItem.name + " to first combine");
            firstItemSet = true;
        }
        else
        {
            secondItem = item;
            Debug.Log("Set " + firstItem.name + " to second combine");
            Combine();
            firstItemSet = false;
        }
    }

    void Combine()
    {
        List<Recipe> possibleRecipes = new List<Recipe>();
        foreach (Recipe recipe in recipes)
        {
            if (recipe.itemOne == firstItem)
            {
                possibleRecipes.Add(recipe);
                Debug.Log("Found possible recipe: " + recipe.name);
            }
        }

        if (possibleRecipes.Count == 0)
            Debug.Log("Didn't find any possible reciped");

        foreach (Recipe recipe in possibleRecipes)
        {
            if (recipe.itemTwo == secondItem)
            {
                Debug.Log("Found recipe: " + recipe.name + " for " + firstItem.name + " and " + secondItem.name);
                firstItem.RemoveFromInventory();
                secondItem.RemoveFromInventory();
                Inventory.instance.Add(recipe.result);
                return;
            }
        }
        Debug.Log("Didn't find a second match, resetting items to combine to null.");
        firstItem = null;
        secondItem = null;
    }
}

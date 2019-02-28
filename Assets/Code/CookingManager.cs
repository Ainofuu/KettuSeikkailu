using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookingManager : MonoBehaviour
{
    #region Singleton

    public static CookingManager instane;

    private void Awake()
    {
        if (instane != null)
        {
            Debug.LogWarning("Found more than one CookingManager!");
            return;
        }

        instane = this;
    }

    #endregion
    
    [SerializeField]
    List<CookingRecipe> recipes = new List<CookingRecipe>();

    public CookingRecipe GetRecipe(Item ingredient)
    {
        foreach (CookingRecipe recipe in recipes)
        {
            if (recipe.ingredient == ingredient)
            {
                Debug.Log("Found matching recipe: " + recipe.name + " for ingredient: " + ingredient.name);
                return recipe;
            }
        }

        Debug.Log("Didn't find a recipe for ingredient: " + ingredient.name);
        return null;
    }
}

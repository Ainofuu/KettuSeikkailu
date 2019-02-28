using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Cooking Recipe", menuName = "Recipe/Cooking Recipe")]
public class CookingRecipe : ScriptableObject
{
    new public string name;

    public Item result;
    public Item ingredient;

    public float cookingTime;
}

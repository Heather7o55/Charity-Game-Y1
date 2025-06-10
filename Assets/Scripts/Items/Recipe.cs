using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "NewRecipe", menuName = "Recipe")]
public class Recipe : ScriptableObject
{
    // Here we define a recipes requirement aka the Items needed to create it, we also define what this recipe will create
    public Item[] requirements;
    public Item output;
}

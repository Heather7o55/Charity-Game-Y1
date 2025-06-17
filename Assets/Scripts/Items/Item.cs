using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "NewItem", menuName = "Item")]
public class Item : ScriptableObject
{
    /* Here we define the basic item stats, including its nextState making it easy to program the burning and cooking code.
    We also define its model and artwork, for UI elements and player holding */
    public new string name;
    public Sprite artwork;
    public GameObject model;
    public int ID;
    public Item nextState;
    public Recipe[] recipes;
}
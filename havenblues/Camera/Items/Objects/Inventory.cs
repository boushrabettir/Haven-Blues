using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Inventory : ScriptableObject
{
    //reference to whatever is in the chest
    public Item currentItem;
    public List<Item> items = new List<Item>();
    //list will be what our inventory is
    public int numberOfKeys;
    public int coins;
    public int enemy;

    public void AddItem(Item itemToAdd)
    {

        //is item key?
        if (itemToAdd.isKey)
        {
            numberOfKeys++;

        }else
        {
            if (!items.Contains(itemToAdd)) //if its not already in out list of inventory
            {

                items.Add(itemToAdd);
            }

        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable] 
//data holder for loot we want
public class Loot
{
    public PowerUps thisLoot;
    public int lootChance; //can use floats too


}

[CreateAssetMenu]

public class Loottable : ScriptableObject
{

    public Loot[] loot;

    public PowerUps LootPower()
    {

        int cumilativeProb = 0;
        int currentProb = Random.Range(0, 100);
        for(int i = 0; i < loot.Length; i++)
        {
            //so basically if a heart was chosen, it goes through the probability partt
            //its going to go thru, make random number, for instance 30. it will then be added to the probability, which is 60
            // so if the currentprob (40) is less than or equal to lootchance, then it will return the loot aka hearts
            //if current prob is more than it, then it will go through the system again and if it doesnt work, then return null
            //this whole operation is a loop


            cumilativeProb += loot[i].lootChance;
            if(currentProb <= cumilativeProb)
            {
                return loot[i].thisLoot;

            }

        }

        return null; //sometimes nothing is recieved if the system goes thru the loop a couple of times

    }

}

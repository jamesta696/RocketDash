using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour
{

    void Start()
    {
        ItemShopDictionary();
    }

    void Update()
    {
        
    }

    void ItemShopDictionary()
    {
        int PlayerGold = 100;
        Dictionary<string, int> itemInventory = new Dictionary<string, int>() 
        {
            {"Potion", 5},
            {"Antidote", 10},
            {"Fire Sword", 50},
            {"Brass Gloves", 100}
        };

        foreach (KeyValuePair<string, int> item in itemInventory)
        {
            // Debug.LogFormat("{0}: {1}g", item.Key, item.Value);
            // Check to see if the player has enough gold to buy the item
            if (PlayerGold >= item.Value)
            {
                // Debug.LogFormat("{0}: {1}g (Has enough gold)", item.Key, item.Value);
                PlayerGold -= item.Value;
            }
            else
            {
                Debug.LogFormat("{0}: {1}g (Not enough gold)", item.Key, item.Value);

            }

            Debug.Log("Player Gold: " + PlayerGold);
        }
    }
}

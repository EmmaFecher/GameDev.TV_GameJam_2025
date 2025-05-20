using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseShopTable : MonoBehaviour
{
    int amountOfInventory;
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //play anim of adding however many items in the player inventory to this inventory
        }
    }
}

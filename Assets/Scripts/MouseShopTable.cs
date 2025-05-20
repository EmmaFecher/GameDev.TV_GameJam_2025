using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseShopTable : MonoBehaviour
{
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerMovement pm = other.gameObject.GetComponent<PlayerMovement>();
            //play anim of adding however many items in the player inventory to this inventory
            if (pm.canControl)
            {
                if (pm.fireInput)
                {
                    Debug.Log("Put backpack in store");
                    GameManager.instance.shopInventory += GameManager.instance.currentMouseInventory;
                    GameManager.instance.currentMouseInventory = 0;
                    pm.fireInput = false;
                }
            }
        }
    }
}

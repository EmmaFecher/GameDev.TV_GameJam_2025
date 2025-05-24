using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGrab : MonoBehaviour
{
    //trigger, if player stands on spot and hits button
    //have anim for grabbing?
    //add to inventory, turn off collider (and glowing gold color??)
    //return
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
                    if (GameManager.instance.currentMouseInventory < GameManager.instance.maxMouseInventory)
                    {
                        // Debug.Log("Add");
                        GameManager.instance.AddToInventory();
                        pm.fireInput = false;
                        this.gameObject.SetActive(false);
                    }
                }
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGrab : MonoBehaviour
{
    public bool isTutorialObject = false;
    public bool grabbed = false;
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
                        GameManager.instance.AddToInventory();
                        pm.fireInput = false;
                        grabbed = true;
                        if (isTutorialObject == false)
                            this.gameObject.SetActive(false);
                    }
                }
            }
        }
    }
}

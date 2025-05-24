using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MouseShopTable : MonoBehaviour
{
    public TextMeshProUGUI amount;
    void Start()
    {
        amount.text = GameManager.instance.shopInventory.ToString();
    }
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
                    GameManager.instance.ResetInventory();
                    amount.text = GameManager.instance.shopInventory.ToString();
                    pm.fireInput = false;
                }
            }
        }
    }
    public void SellItem()
    {
        GameManager.instance.UpdateShopInventory(1);
        amount.text = GameManager.instance.shopInventory.ToString();
    }
}

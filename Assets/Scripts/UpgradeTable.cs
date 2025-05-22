using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpgradeTable : MonoBehaviour
{
    public TextMeshProUGUI amount;
    void Start()
    {
        amount.text = GameManager.instance.upgradeCost.ToString();
    }
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerMovement pm = other.gameObject.GetComponent<PlayerMovement>();
            
            if (pm.canControl)
            {
                if (pm.fireInput)
                {
                    if (GameManager.instance.upgradeCost <= GameManager.instance.score)
                    {
                        Debug.Log("Upgrade backpack");
                        // GameManager.instance.shopInventory += GameManager.instance.currentMouseInventory;
                        GameManager.instance.IncreaseMaxCap(1);
                        amount.text = GameManager.instance.upgradeCost.ToString();
                        pm.fireInput = false;
                    }
                    
                }
            }
        }
    }
}

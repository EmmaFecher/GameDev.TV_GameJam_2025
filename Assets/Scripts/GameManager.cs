using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int score = 0;//sell item -> add to this
    public int shopInventory = 0;//add to this when click on base shop
    public int maxMouseInventory = 5;
    public int currentMouseInventory = 0;
    public int upgradeCost = 1;
    public static GameManager instance;
    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    public void Reset()
    {
        score = 0;
        shopInventory = 0;
        maxMouseInventory = 5;
        currentMouseInventory = 0;
    }
    public void UpdateShopInventory(int amount)
    {
        shopInventory += amount;
        GameObject.FindGameObjectWithTag("Finish").GetComponent<GameManageHelper>().thing.text = shopInventory.ToString();
<<<<<<< HEAD
=======
        GameObject.Find("/CustomerSpawn").GetComponent<CustomerSpawner>().SpawnCustomer();
>>>>>>> df5eac1441ec466b43e0a87789bb35971412ce49
    }
    public void AddToInventory()
    {
        currentMouseInventory++;
        GameObject.Find("/GameCanvas").GetComponent<GameUI>().UpdateBackpack();
    }
    public void ResetInventory()
    {
        currentMouseInventory = 0;
        GameObject.Find("/GameCanvas").GetComponent<GameUI>().UpdateBackpack();
    }
    public void IncreaseMaxCap(int amount)
    {
        maxMouseInventory += amount;
        upgradeCost += 2;
        GameObject.Find("/GameCanvas").GetComponent<GameUI>().UpdateBackpack();
    }
}

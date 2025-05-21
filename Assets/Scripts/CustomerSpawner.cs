using UnityEngine;
public class CustomerSpawner : MonoBehaviour
{
    public GameObject customer;
    void Start()
    {
        SpawnCustomer();
    }
    public void SpawnCustomer()
    {
        Instantiate(customer, transform.position, Quaternion.identity);
    }
}
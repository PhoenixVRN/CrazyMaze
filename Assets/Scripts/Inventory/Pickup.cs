
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public GameObject nextView;
    public GameObject view;
    public GameObject nextGameItem;
    
    private Inventory _inventory;

    private void Start()
    {
     var ddd = GameObject.FindGameObjectsWithTag("Player");
     _inventory = ddd[0].GetComponent<Inventory>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            nextGameItem.SetActive(true);
            foreach (Transform child in view.transform)
            {
                GameObject.Destroy((child.gameObject));
            }   
                   
            Instantiate(nextView, _inventory.slots[0].transform);
            Destroy(gameObject);
        }
    }
}
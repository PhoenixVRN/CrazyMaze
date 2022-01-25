using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    private Inventory _Inventory;
    public GameObject nextView;
    public GameObject view;
    public GameObject nextGameItem;

    private void Start()
    {
     var ddd = GameObject.FindGameObjectsWithTag("Player");
     _Inventory = ddd[0].GetComponent<Inventory>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
 //           for (int i = 0; i < _Inventory.slots.Length; i++)
//            {
//                if (_Inventory.isFull[i] == false)
//                {
//                    _Inventory.isFull[i] = true;
                    nextGameItem.SetActive(true); //активируем итем из списка.
//                    exit.SetActive(true);
                    foreach (Transform child in view.transform)
                    {
                        GameObject.Destroy((child.gameObject));
                    }
                   
                    Instantiate(nextView, _Inventory.slots[0].transform);
                    Destroy(gameObject);
//                    break;
//                }
 //           }
        }
    }
}
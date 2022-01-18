using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    private Inventory _Inventory;
    public GameObject slotButton;
    public GameObject exit;

    private void Start()
    {
     var ddd = GameObject.FindGameObjectsWithTag("Player");
     _Inventory = ddd[0].GetComponent<Inventory>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            for (int i = 0; i < _Inventory.slots.Length; i++)
            {
                if (_Inventory.isFull[i] == false)
                {
                    _Inventory.isFull[i] = true;
                    exit.SetActive(true);
                    Instantiate(slotButton, _Inventory.slots[i].transform);
                    Destroy(gameObject);
                    break;
                }
            }
        }
    }
}
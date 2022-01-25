using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
   public bool[] isFull;
   public GameObject[] slots;
   public GameObject[] point;
   public GameObject startItem;

   private void Start()
   {
      
      Instantiate(startItem, slots[0].transform); // рисуем имедж итема в ячейке UI.
   }
}

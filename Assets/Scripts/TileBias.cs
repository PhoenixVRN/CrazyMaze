using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TileBias : MonoBehaviour
{
 public FildInstance fildInstance;
 private GameObject[] _arreyStrok = new GameObject[6];
 private Collider2D _collision;

 private void Start()
 {
  
 }

 private void OnTriggerEnter2D(Collider2D other)
 {
  _collision = other;
 }

 private void OnTriggerExit2D(Collider2D other)
 {
  _collision = null;
 }

 public void TilesBias()
 {
  if (_collision == null) return;

  if (_collision.gameObject.tag == "Rirht") BiasRight();
  
  }

 public void BiasRight()
 {
  for (int i = 0; i < fildInstance.array2.Length; i++)
  {
   var obg = fildInstance.array2[i];
   if (obg.transform.position.y == 0)
   {
    obg.transform.Translate(1,0,0);
    Debug.Log(obg.transform.position.y +"  " + obg.transform.position.x);
   }
   fildInstance.array2[i] = obg;
  
  }
 
 }
}

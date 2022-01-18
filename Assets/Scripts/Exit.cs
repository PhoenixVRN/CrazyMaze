using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Exit : MonoBehaviour
{
//   public Text miText;
   private void OnTriggerEnter2D(Collider2D other)
   {
     
      if (other.gameObject.tag == "Player")
      {
         SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
      }
   }
}

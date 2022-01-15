using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Exit : MonoBehaviour
{
   public Text miText;
   private void OnTriggerEnter2D(Collider2D other)
   {
      Debug.Log("You Win");
      if (other.gameObject.tag == "Player")
      {
//         miText.text = "YOU WIN";
         SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

         Debug.Log("You Win");
      }
   }
}

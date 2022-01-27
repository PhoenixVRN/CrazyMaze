
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Exit : MonoBehaviour
{
   public Text miText;
   private void OnTriggerEnter2D(Collider2D other)
   {

      if (other.gameObject.tag == "Player") StartCoroutine(Restart());

   }

   private IEnumerator Restart()
   {
      miText.gameObject.SetActive(true);
      yield return new WaitForSeconds(1f);
      miText.gameObject.SetActive(false);
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
   }
}

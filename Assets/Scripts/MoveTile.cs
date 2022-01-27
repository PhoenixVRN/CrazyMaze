
using UnityEngine;


public class MoveTile : MonoBehaviour
{
    public GameObject moveTile;
    public TileBias stopAnim;
    
    private static Vector2 _koordinat;
    
     void OnMouseOver()
     {
        
         if (Input.GetMouseButtonDown(0))
         {
             Debug.Log(stopAnim.stop);
             if (stopAnim.stop) return; // проверка на работу анимации.
             _koordinat = transform.position;
             moveTile.transform.position = _koordinat;
         }
     }
}

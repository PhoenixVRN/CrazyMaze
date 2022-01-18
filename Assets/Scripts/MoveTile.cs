using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTile : MonoBehaviour
{
    private Renderer rend;
    private static Vector2 _koordinat;
    public GameObject moveTile;
    

    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    // The mesh goes red when the mouse is over it...
    // void OnMouseEnter()
    // {
    //     _koordinat = transform.position;
    //     moveTile.transform.position = _koordinat;
    // }

    // ...the red fades out to cyan as the mouse is held over...
     void OnMouseOver()
     {
         if (Input.GetMouseButtonDown(0))
         {
             _koordinat = transform.position;
             moveTile.transform.position = _koordinat;
         }
         //     rend.material.color -= new Color(0.1F, 0, 0) * Time.deltaTime;
     }

    // ...and the mesh finally turns white when the mouse moves away.
    // void OnMouseExit()
    // {
    //     rend.material.color = Color.white;
    // }
}

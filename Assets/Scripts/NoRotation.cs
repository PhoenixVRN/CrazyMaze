using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoRotation : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.rotation.z != 0)
        {
            transform.rotation =  Quaternion.Euler(0, 0, 0);
            
             Debug.Log("Local pPos: " + transform.localRotation);
             Debug.Log("Local pPos: " + transform.rotation);
        }
    }
}


using UnityEngine;

public class NoRotation : MonoBehaviour
{
 void Update()
    {
        if (transform.rotation.z != 0)
        {
            transform.rotation =  Quaternion.Euler(0, 0, 0);
        }
    }
}

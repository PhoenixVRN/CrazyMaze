using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationTile : MonoBehaviour
{
    private Transform _transform;
    void Start()
    {
        _transform = GetComponent<Transform>();
    }

    public void RotationTiles()
    {
//        var tr = _transform.rotation;
        _transform.rotation *= Quaternion.Euler(0,0,90F);;
    }
}

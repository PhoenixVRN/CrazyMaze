using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationTile : MonoBehaviour
{
    private Transform _transChild;
    void Start()
    {
        _transChild = this.gameObject.transform.GetChild(0);
    }

    private void Update()
    {
        if (Input.GetKeyDown("e")) RotationTiles();
    }

    public void RotationTiles()
    {
        _transChild = this.gameObject.transform.GetChild(0);
        _transChild.rotation *= Quaternion.Euler(0,0,90F);;
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class FildInstance : MonoBehaviour
{
    public GameObject[] array = new GameObject[49];

  //угол поворота тайла.
    private int[] rot = new int[4]{
        0,90,180,-90
    };
        
    private void Start()
    {
        ReshufflingArray();
        
        for (int y = 0; y < 6; y++)
        {
            for (int x = 0; x < 6; x++)
            {

                var go = Instantiate(array[y+x], new Vector3(x, y, 0), Quaternion.identity);
            
                go.transform.rotation = Quaternion.Euler(0,0,rot[Random.Range(0,3)]);
            }
        }
    }
// перемешивание массива тайлов.
    private void ReshufflingArray()
    {
        for (int i = 0; i < array.Length; i++)
        {
            int j = Random.Range(0, (i + 1));

            (array[j], array[i]) = (array[i], array[j]);
        }
    }
}

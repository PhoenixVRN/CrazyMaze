using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class FildInstance : MonoBehaviour
{
    public const int FIELD_SIZE_X = 6;
    public const int FIELD_SIZE_Y = 6;

    public void GenerateMap()
    {
        ReshufflingArray();
        
        for (int y = 0; y < FIELD_SIZE_X; y++)
        {
            for (int x = 0; x < FIELD_SIZE_Y; x++)
            {
                var go = Instantiate(array[y*FIELD_SIZE_X+x],
                    new Vector3(x, y, 0),
                    Quaternion.Euler(0,0,rot[Random.Range(0,3)]),
                    NavMash.transform);
                
                array2[y*FIELD_SIZE_X + x] = go;
            }
        }
        
        NavMeshRebaker();
    }

    public GameObject[] array = new GameObject[49];
    public GameObject[] array2 = new GameObject[FIELD_SIZE_X * FIELD_SIZE_Y];

    public NavMeshSurface2d NavMash;
  //угол поворота тайла.
    private int[] rot = new int[4]{
        0,90,180,-90
    };
        
    private void Start()
    {
        GenerateMap();
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

    public void NavMeshRebaker()
    {
        NavMash.BuildNavMesh();
    }
}

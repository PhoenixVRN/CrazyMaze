using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using UnityEngine.AI;

public class FillingTileArrey : MonoBehaviour
{
   public List<Transform> waypoints;
   public NavMeshSurface2d NavMash;
   //угол поворота тайла.
   private int[] rot = new int[4]{
       0,90,180,-90
   };
    private void Awake()
    {
        UpdateWaypoints();
    }

    private void Start()
    {
 //       ReshufflingArray();
//        NavMeshRebaker();
    }

    [ContextMenu("Update Waypoint List")]
    private void UpdateWaypoints()
    {
        waypoints.Clear();

        foreach(Transform child in transform)
        {
            waypoints.Add(child);
        }
    }
    
    // перемешивание массива тайлов.
    public void ReshufflingArray()
    {
        for (int i = 0; i < waypoints.Count; i++)
        {
            int j = Random.Range(0, (i + 1));

            (waypoints[j].position, waypoints[i].position) = (waypoints[i].position, waypoints[j].position);
            var q = waypoints[i];
            q.rotation = Quaternion.Euler(0,0,rot[Random.Range(0,3)]);
        }
    }
    
    public void AngleArray()
    {
        for (int i = 0; i < waypoints.Count; i++)
        {
            var q = waypoints[i];
            q.rotation = Quaternion.Euler(0,0,rot[Random.Range(0,3)]);
        }
    }
    
    public void NavMeshRebaker()
    {
        NavMash.BuildNavMesh();
    }
    public void NavMeshClear()
    {
        NavMash.RemoveData();
    }
}

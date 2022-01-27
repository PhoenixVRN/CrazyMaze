
using System.Collections.Generic;
using UnityEngine;

public class MIxingMap : MonoBehaviour
{
    public List<Transform> waypoints;


    //угол поворота тайла.
    private int[] rot = new int[4]
    {
        0, 90, 180, -90
    };

    private void Awake()
    {
        UpdateWaypoints();
    }

    private void Start()
    {
        ReshufflingArray();

    }

    [ContextMenu("Update Waypoint List")]
    private void UpdateWaypoints()
    {
        waypoints.Clear();

        foreach (Transform child in transform)
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
            q.rotation = Quaternion.Euler(0, 0, rot[Random.Range(0, 3)]);
        }
    }
}
 
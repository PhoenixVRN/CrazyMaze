using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;


public class TileBias : MonoBehaviour
{
//    public List<Transform> tileMap;
    private GameObject _tm;
    public MIxingMap _map;
    public GameObject tileForMove;
    private GameObject _tf;
    private Vector2 StartTile;

    private String _directMove;
    public List<Transform> _listMove;

    private void Start()
    {
        StartTile = this.transform.position;
        _tm = GameObject.Find("Tile_Map");
        _map = _tm.GetComponent<MIxingMap>();
       InstaTileMove();
    }
    public void MoveTile()
    {
        
        DirectionMove();
        ListMove();


    }

    private String DirectionMove()
    {
        if (this.transform.position.x == -1 && transform.position.y <= 5 && transform.position.y >= 0)
        {
            _directMove = "Right";
            return _directMove;
        }

        if (this.transform.position.x == 6 && transform.position.y <= 5 && transform.position.y >= 0)
        {
            _directMove = "Left";
            return _directMove;
        }

        if (this.transform.position.y == -1 && transform.position.x <= 5 && transform.position.x >= 0)
        {
            _directMove = "Up";
            return _directMove;
        }

        if (this.transform.position.x == 6 && transform.position.x <= 5 && transform.position.x >= 0)
        {
            _directMove = "Down";
            return _directMove;
        }

        _directMove = "Error";
        
        return _directMove;
    }

    private void ListMove()
    {
        if (_directMove == "Right")
        {
            _map.waypoints.Add(_tf.transform);
            foreach (var i in _map.waypoints)
            {
                if (i.position.y == 0) _listMove.Add(i);
            }

//            _listMove.Add(_tf.transform);


            for (int i = 0; i < _listMove.Count; i++)
            {
                for (int j = 0; j < _listMove.Count - 1; j++)
                {
                    if (_listMove[j].position.x > _listMove[j + 1].position.x)
                    {
                        (_listMove[j], _listMove[j + 1]) = (_listMove[j + 1], _listMove[j]);
                    }
                }
            }

           
            foreach (var s in _listMove)
            {
                Vector2 position = s.position;
                position.x += 1;
                s.position = position;

            }
           _tf.transform.SetParent(_tm.transform); // убираем из родителя
            tileForMove = _listMove[6].gameObject;
            tileForMove.transform.position = Vector3.zero;
            tileForMove.transform.SetParent(this.gameObject.transform,false);
            this.transform.position = StartTile;
        }
    }

    private void InstaTileMove()
    {
     _tf = Instantiate(tileForMove, this.transform.position, this.transform.rotation = quaternion.identity, transform);
    }
    private void MoveTilesMap()
    {
        
    }
}
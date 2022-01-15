using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;


public class TileBias : MonoBehaviour
{
    private GameObject _tMap;
    public MIxingMap _map;
    public GameObject tileForMove;
    public Rigidbody2D Player;
    private GameObject _tf;
    private Vector2 StartTile;

    private String _directMove;
    private String koortinat;
    public List<Transform> _listMove;

    private void Start()
    {
        StartTile = this.transform.position;
        _tMap = GameObject.Find("Tile_Map");
        _map = _tMap.GetComponent<MIxingMap>();
        _tf = tileForMove;
        _map.waypoints.Add(_tf.transform);
    }

    private void Update()
    {
        if (Input.GetKeyDown("space")) MoveTile();
    }

    public void MoveTile()
    {
        DirectionMove();
        if (_directMove == "Error") return;
        ListMove();
    }

    private void DirectionMove()
    {
        if (transform.position.x == -1 && transform.position.y <= 5 && transform.position.y >= 0)
        {
            _directMove = "Right";
            return;
        }

        if (transform.position.x == 6 && transform.position.y <= 5 && transform.position.y >= 0)
        {
            _directMove = "Left";
            return;
        }

        if (transform.position.y == -1 && transform.position.x <= 5 && transform.position.x >= 0)
        {
            _directMove = "Up";
            return;
        }

        if (transform.position.y == 6 && transform.position.x <= 5 && transform.position.x >= 0)
        {
            _directMove = "Down";
            return;
        }
        
        _directMove = "Error";
    }

    private void ListMove()
    {
        
        var x = tileForMove.transform.position.x;
        var y = tileForMove.transform.position.y;
        if (_directMove == "Right")
        {
            WorkingAnArray(6, y, 1, false);
            
            Vector2 positionP = Player.position;
            {
                if (positionP.y == y)
                {
                    if (positionP.x < 5) positionP.x += 1;

                    else positionP.x = 0;

                    Player.MovePosition(positionP);
                }
            }
        }
        
        if (_directMove == "Left")
        {
            WorkingAnArray(0, y , -1, false);


            Vector2 positionP = Player.position;
            {
                if (positionP.y == y)
                {
                    if (positionP.x > 0) positionP.x -= 1;
                    else positionP.x = 5;
                    Player.MovePosition(positionP);
                }
            }
        }
        if (_directMove == "Up")
        {
            WorkingAnArray(6, x , 1, true);

            Vector2 positionP = Player.position;
            {
                if (positionP.x == x)
                {
                    if (positionP.y < 5) positionP.y += 1;
                    else positionP.y = 0;
                    Player.MovePosition(positionP);
                }
            }
        } 
        
        if (_directMove == "Down")
        {
            WorkingAnArray(0, x , -1, true);


            Vector2 positionP = Player.position;
            {
                if (positionP.x == x)
                {
                    if (positionP.y > 0) positionP.y -= 1;
                    else positionP.y = 5;
                    Player.MovePosition(positionP);
                }
            }
        }
    }

    private void WorkingAnArray(int a, float b, int c, bool vertical)
    {
        if (vertical)
        {
            foreach (var i in _map.waypoints)
            {
                if (i.position.x == b) _listMove.Add(i);
            } 
            for (int i = 0; i < _listMove.Count; i++)
            {
                for (int j = 0; j < _listMove.Count - 1; j++)
                {
                    if (_listMove[j].position.y > _listMove[j + 1].position.y)
                    {
                        (_listMove[j], _listMove[j + 1]) = (_listMove[j + 1], _listMove[j]);
                    }
                }
            }
        }
        else
        {
            foreach (var i in _map.waypoints)
            {
                if (i.position.y == b) _listMove.Add(i);
            } 
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
        }
        
        foreach (var s in _listMove)
        {
            if (vertical)
            {
                Vector2 position = s.position;
                position.y += c;
                s.position = position; 
            }
            else
            {
                Vector2 position = s.position;
                position.x += c;
                s.position = position; 
            }
           

        }
        
        _tf.transform.SetParent(_tMap.transform); // убираем из родителя
        tileForMove = _listMove[a].gameObject;
        tileForMove.transform.position = Vector3.zero;
        tileForMove.transform.SetParent(this.gameObject.transform,false);
        transform.position = StartTile;
        _listMove.Clear();
        _tf = tileForMove; 
    }
    }
    
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;


public class TileBias : MonoBehaviour
{
    public List<GameObject> findToShift;
    public MIxingMap _map;
    public GameObject tileForMove;
    public Rigidbody2D Player;
    public List<GameObject> shiftOff;
    public int score = 0;
    public Text ScoText;
    public AudioSource audioMoveWall;
    public List<Transform> _listMove;
    public bool stop = false;
    
    private GameObject _tf;
    private Vector2 StartTile;
    private GameObject _tMap;
    private String _directMove;
    private String _koorвinat;
    

    private void Start()
    {
        StartTile = transform.position;
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
        if (stop) return;
        stop = true;
        StartCoroutine(StartTimer());
        DirectionMove();
        if (_directMove == "Error")
        {
            transform.position = StartTile;
            return;
        }

        ListMove();
    }

    private void DirectionMove()
    {
        if (transform.position.x == -1 && transform.position.y <= 6 && transform.position.y >= 0)
        {
            _directMove = "Right";
            return;
        }

        if (transform.position.x == 7 && transform.position.y <= 6 && transform.position.y >= 0)
        {
            _directMove = "Left";
            return;
        }

        if (transform.position.y == -1 && transform.position.x <= 6 && transform.position.x >= 0)
        {
            _directMove = "Up";
            return;
        }

        if (transform.position.y == 7 && transform.position.x <= 6 && transform.position.x >= 0)
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
            StartCoroutine(PlayerMoveRight(y));
            WorkingAnArray(7, y, 1, false);
        }

        if (_directMove == "Left")
        {
            StartCoroutine(PlayerMoveLeft(y));
            WorkingAnArray(0, y, -1, false);
        }

        if (_directMove == "Up")
        {
            StartCoroutine(PlayerMoveUp(x));
            WorkingAnArray(7, x, 1, true);
        }

        if (_directMove == "Down")
        {
            StartCoroutine(PlayerMoveDown(x));
            WorkingAnArray(0, x, -1, true);
        }
    }

    private IEnumerator StartTimer()
    {
        yield return new WaitForSeconds(1.2f);
        stop = false;
    }
    
    private IEnumerator PlayerMoveRight(float y)
    {
        Vector2 positionP = Player.position;
        {
            if (positionP.y == y)
            {
                for (int i = 0; i < 10; i++)
                {
                    if (positionP.x < 6.5f)
                    {
                        positionP.x += 0.1f;
                    }
                    else positionP.x = -0.4f;
                    
                    Player.MovePosition(positionP);
                    yield return new WaitForSeconds(0.1f);
                }
                positionP.x = Mathf.Round(positionP.x);
                Player.MovePosition(positionP);
            }
        }
    }
    
    private IEnumerator PlayerMoveLeft(float y)
    {
        Vector2 positionP = Player.position;
        {
            if (positionP.y == y)
            {
                for (int i = 0; i < 10; i++)
                {
                    if (positionP.x > -0.5f)
                    {
                        positionP.x -= 0.1f;
                    }
                    else positionP.x = 6.4f;
                    
                    Player.MovePosition(positionP);
                    yield return new WaitForSeconds(0.1f);
                }
                positionP.x = Mathf.Round(positionP.x);
                Player.MovePosition(positionP);
            }
        }
    }
    
    private IEnumerator PlayerMoveUp(float x)
    {
        Vector2 positionP = Player.position;
        {
            if (positionP.x == x)
            {
                for (int i = 0; i < 10; i++)
                {
                    if (positionP.y < 6.5f)
                    {
                        positionP.y += 0.1f;
                    }
                    else positionP.y = -0.4f;
                    
                    Player.MovePosition(positionP);
                    yield return new WaitForSeconds(0.1f);
                }
                positionP.y = Mathf.Round(positionP.y);
                Player.MovePosition(positionP);
            }
        }
    }
    
    private IEnumerator PlayerMoveDown(float x)
    {
        Vector2 positionP = Player.position;
        {
            if (positionP.x == x)
            {
                for (int i = 0; i < 10; i++)
                {
                    if (positionP.y > -0.5f)
                    {
                        positionP.y -= 0.1f;
                    }
                    else positionP.y = 6.4f;
                    
                    Player.MovePosition(positionP);
                    yield return new WaitForSeconds(0.1f);
                }
                positionP.y = Mathf.Round(positionP.y);
                Player.MovePosition(positionP);
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
        audioMoveWall.Play();
        
        StartCoroutine(SmoothShift(c, vertical, a));

        HideFind();
       
    }

    private IEnumerator SmoothShift(int c, bool vertical, int a)
    {
        for (float d = 0; d < 10; d++)
        {
            foreach (var s in _listMove)
            {
                if (vertical)
                {
                    Vector2 position = s.position;
                    position.y += c * 0.1f; 
                    s.position = position;
                }
                else
                {
                    Vector2 position = s.position;
                    position.x += c * 0.1f;
                    s.position = position;
                }
            }
            
            yield return new WaitForSeconds(0.1f);
        }
        
        foreach (var s in _listMove)
        {
            Vector2 position = s.position;
            position.y = Mathf.Round(position.y);
            position.x = Mathf.Round(position.x);
            s.position = position;
        }
        
        _tf.transform.SetParent(_tMap.transform); // убираем из родителя
        tileForMove = _listMove[a].gameObject;
        Debug.Log(a);
        tileForMove.transform.position = Vector3.zero;
        tileForMove.transform.SetParent(this.gameObject.transform, false);
        transform.position = StartTile;
        _listMove.Clear();
        _tf = tileForMove;
        score++;
        ScoText.text = "Ходы: " + score.ToString();
       
    }

   

    private void HideFind()
    {
        if (transform.position.y == 1)
        {
            shiftOff[0].SetActive(true);
            shiftOff[1].SetActive(true);
            shiftOff[0] = findToShift[0];
            shiftOff[1] = findToShift[1];
            shiftOff[0].SetActive(false);
            shiftOff[1].SetActive(false);
        }

        if (transform.position.y == 3)
        {
            shiftOff[0].SetActive(true);
            shiftOff[1].SetActive(true);
            shiftOff[0] = findToShift[2];
            shiftOff[1] = findToShift[3];
            shiftOff[0].SetActive(false);
            shiftOff[1].SetActive(false);
        }

        if (transform.position.y == 5)
        {
            shiftOff[0].SetActive(true);
            shiftOff[1].SetActive(true);
            shiftOff[0] = findToShift[4];
            shiftOff[1] = findToShift[5];
            shiftOff[0].SetActive(false);
            shiftOff[1].SetActive(false);
        }

        if (transform.position.x == 1)
        {
            shiftOff[0].SetActive(true);
            shiftOff[1].SetActive(true);
            shiftOff[0] = findToShift[6];
            shiftOff[1] = findToShift[7];
            shiftOff[0].SetActive(false);
            shiftOff[1].SetActive(false);
        }

        if (transform.position.x == 3)
        {
            shiftOff[0].SetActive(true);
            shiftOff[1].SetActive(true);
            shiftOff[0] = findToShift[8];
            shiftOff[1] = findToShift[9];
            shiftOff[0].SetActive(false);
            shiftOff[1].SetActive(false);
        }

        if (transform.position.x == 5)
        {
            shiftOff[0].SetActive(true);
            shiftOff[1].SetActive(true);
            shiftOff[0] = findToShift[10];
            shiftOff[1] = findToShift[11];
            shiftOff[0].SetActive(false);
            shiftOff[1].SetActive(false);
        }
    }
}
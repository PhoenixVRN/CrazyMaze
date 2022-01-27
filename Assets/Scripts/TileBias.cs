using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TileBias : MonoBehaviour
{
    public List<GameObject> findToShift;
    public MIxingMap map;
    public GameObject tileForMove;
    public Rigidbody2D player;
    public List<GameObject> shiftOff;
    public int score = 0;
    public Text scoreText;
    public AudioSource audioMoveWall;
    public List<Transform> listMove;
    public bool stop = false;
    
    private GameObject _tf;
    private Vector2 _startTile;
    private GameObject _tMap;
    private String _directMove;
    private String _coordinates;
    

    private void Start()
    {
        _startTile = transform.position;
        _tMap = GameObject.Find("Tile_Map");
        map = _tMap.GetComponent<MIxingMap>();
        _tf = tileForMove;
        map.waypoints.Add(_tf.transform);
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
            transform.position = _startTile;
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
        Vector2 positionP = player.position;
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
                    
                    player.MovePosition(positionP);
                    yield return new WaitForSeconds(0.1f);
                }
                positionP.x = Mathf.Round(positionP.x);
                player.MovePosition(positionP);
            }
        }
    }
    
    private IEnumerator PlayerMoveLeft(float y)
    {
        Vector2 positionP = player.position;
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
                    
                    player.MovePosition(positionP);
                    yield return new WaitForSeconds(0.1f);
                }
                positionP.x = Mathf.Round(positionP.x);
                player.MovePosition(positionP);
            }
        }
    }
    
    private IEnumerator PlayerMoveUp(float x)
    {
        Vector2 positionP = player.position;
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
                    
                    player.MovePosition(positionP);
                    yield return new WaitForSeconds(0.1f);
                }
                positionP.y = Mathf.Round(positionP.y);
                player.MovePosition(positionP);
            }
        }
    }
    
    private IEnumerator PlayerMoveDown(float x)
    {
        Vector2 positionP = player.position;
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
                    
                    player.MovePosition(positionP);
                    yield return new WaitForSeconds(0.1f);
                }
                positionP.y = Mathf.Round(positionP.y);
                player.MovePosition(positionP);
            }
        }
    }
    
    
    private void WorkingAnArray(int a, float b, int c, bool vertical)
    {
        if (vertical)
        {
            foreach (var i in map.waypoints)
            {
                if (i.position.x == b) listMove.Add(i);
            }

            for (int i = 0; i < listMove.Count; i++)
            {
                for (int j = 0; j < listMove.Count - 1; j++)
                {
                    if (listMove[j].position.y > listMove[j + 1].position.y)
                    {
                        (listMove[j], listMove[j + 1]) = (listMove[j + 1], listMove[j]);
                    }
                }
            }
        }
        else
        {
            foreach (var i in map.waypoints)
            {
                if (i.position.y == b) listMove.Add(i);
            }

            for (int i = 0; i < listMove.Count; i++)
            {
                for (int j = 0; j < listMove.Count - 1; j++)
                {
                    if (listMove[j].position.x > listMove[j + 1].position.x)
                    {
                        (listMove[j], listMove[j + 1]) = (listMove[j + 1], listMove[j]);
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
            foreach (var s in listMove)
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
        
        foreach (var s in listMove)
        {
            Vector2 position = s.position;
            position.y = Mathf.Round(position.y);
            position.x = Mathf.Round(position.x);
            s.position = position;
        }
        
        _tf.transform.SetParent(_tMap.transform); // убираем из родителя
        tileForMove = listMove[a].gameObject;
        Debug.Log(a);
        tileForMove.transform.position = Vector3.zero;
        tileForMove.transform.SetParent(this.gameObject.transform, false);
        transform.position = _startTile;
        listMove.Clear();
        _tf = tileForMove;
        score++;
        scoreText.text = "Ходы: " + score.ToString();
       
    }

   

    private void HideFind()
    {
        if (transform.position.y == 1) Hide(1);

        if (transform.position.y == 3) Hide(3);

        if (transform.position.y == 5) Hide(5);

        if (transform.position.x == 1) Hide(7);

        if (transform.position.x == 3) Hide(9);

        if (transform.position.x == 5) Hide(11);
    }

    private void Hide(int i)
    {
        shiftOff[0].SetActive(true);
        shiftOff[1].SetActive(true);
        shiftOff[0] = findToShift[i-1];
        shiftOff[1] = findToShift[i];
        shiftOff[0].SetActive(false);
        shiftOff[1].SetActive(false);
    }
}
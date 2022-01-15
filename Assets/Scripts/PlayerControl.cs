using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour
{
    private Rigidbody2D _rigidbodyPlayer;
  
      void Start()
      {
          
          _rigidbodyPlayer = GetComponent<Rigidbody2D>();
      }
  
      void Update()
      {
          if (Input.GetKeyDown("d")) MovePlayerRight();
          if (Input.GetKeyDown("a")) MovePlayerLeft();
          if (Input.GetKeyDown("w")) MovePlayerUp();
          if (Input.GetKeyDown("s")) MovePlayerDown();
      }

    

      public void MovePlayerRight()
      {
          RaycastHit2D hit = Physics2D.Raycast((Vector2)transform.position + Vector2.right * 0.4f, Vector2.right, 0.5f);
         
          if (hit.collider != null && hit.collider.gameObject.CompareTag("Wall")) return;
          
              Vector2 position = _rigidbodyPlayer.position;
              position.x += 1;
              _rigidbodyPlayer.MovePosition(position);
          
          
          
      }
      
      public void MovePlayerLeft()
      {
          RaycastHit2D hit = Physics2D.Raycast((Vector2)transform.position + Vector2.left * 0.4f, Vector2.left, 0.5f);
          if (hit.collider != null && hit.collider.gameObject.CompareTag("Wall")) return;
          
          Vector2 position = _rigidbodyPlayer.position;
          position.x -= 1;
          _rigidbodyPlayer.MovePosition(position);
          
      }
      
      public void MovePlayerUp()
      {
          RaycastHit2D hit = Physics2D.Raycast((Vector2)transform.position + Vector2.up * 0.4f, Vector2.up, 0.5f);
          if (hit.collider != null && hit.collider.gameObject.CompareTag("Wall")) return;
          
          Vector2 position = _rigidbodyPlayer.position;
          position.y += 1;
          _rigidbodyPlayer.MovePosition(position);
          
      }
      
      public void MovePlayerDown()
      {
          RaycastHit2D hit = Physics2D.Raycast((Vector2)transform.position + Vector2.down * 0.4f, Vector2.down, 0.5f);
          if (hit.collider != null && hit.collider.gameObject.CompareTag("Wall")) return;
          
          Vector2 position = _rigidbodyPlayer.position;
          position.y -= 1;
          _rigidbodyPlayer.MovePosition(position);
          
      }
}

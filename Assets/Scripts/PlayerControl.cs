
using UnityEngine;


public class PlayerControl : MonoBehaviour
{
    private float _offSet = 0.2f;
    private float _distanc = 0.6f;
    private Rigidbody2D _rigidbodyPlayer;
    private bool _key;
    [SerializeField] private GameObject _pauseMenu;
    
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
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseMenu();
        }
      }

    

      public void MovePlayerRight()
      {
      //    Debug.DrawRay((Vector2)transform.position + Vector2.right * _offSet, Vector2.right*_distanc, Color.red, 3);
          
          RaycastHit2D hit = Physics2D.Raycast((Vector2)transform.position + Vector2.right * _offSet, Vector2.right, _distanc);
         
          if (hit.collider != null && hit.collider.gameObject.CompareTag("Wall")) return;
          
              Vector2 position = _rigidbodyPlayer.position;
              position.x += 1;
              _rigidbodyPlayer.MovePosition(position);
          
          
          
      }
      
      public void MovePlayerLeft()
      {
          Debug.DrawRay((Vector2)transform.position + Vector2.left * _offSet, Vector2.left*_distanc, Color.red, 3);
          
          RaycastHit2D hit = Physics2D.Raycast((Vector2)transform.position + Vector2.left * _offSet, Vector2.left, _distanc);
          if (hit.collider != null && hit.collider.gameObject.CompareTag("Wall")) return;
          
          Vector2 position = _rigidbodyPlayer.position;
          position.x -= 1;
          _rigidbodyPlayer.MovePosition(position);
          
      }
      
      public void MovePlayerUp()
      {
          Debug.DrawRay((Vector2)transform.position + Vector2.up * _offSet, Vector2.up*_distanc, Color.red, 3);
          
          RaycastHit2D hit = Physics2D.Raycast((Vector2)transform.position + Vector2.up * _offSet, Vector2.up, _distanc);
          if (hit.collider != null && hit.collider.gameObject.CompareTag("Wall")) return;
          
          Vector2 position = _rigidbodyPlayer.position;
          position.y += 1;
          _rigidbodyPlayer.MovePosition(position);
          
      }
      
      
      public void MovePlayerDown()
      {
          Debug.DrawRay((Vector2)transform.position + Vector2.down * _offSet, Vector2.down*_distanc, Color.red, 3);
          
          RaycastHit2D hit = Physics2D.Raycast((Vector2)transform.position + Vector2.down * _offSet, Vector2.down, _distanc);
          if (hit.collider != null && hit.collider.gameObject.CompareTag("Wall")) return;
          
          Vector2 position = _rigidbodyPlayer.position;
          position.y -= 1;
          _rigidbodyPlayer.MovePosition(position);
          
      }

    private void PauseMenu()
    {
        _pauseMenu.SetActive(true);
    }
}

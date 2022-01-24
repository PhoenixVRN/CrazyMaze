using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragger : MonoBehaviour
{
  public delegate void DragEndedDelegate(Dragger draggableObject);

  public DragEndedDelegate dragEndedCallback;
  
  private Vector3 _dragOffset;

  private void OnMouseDown()
  {
    _dragOffset = transform.position - GetMousePos();
  }

  private void OnMouseDrag()
  {
    transform.position = GetMousePos() + _dragOffset;
  }

  private void OnMouseUp()
  {
    dragEndedCallback(this);
  }

  Vector3 GetMousePos()
  {
    var mousPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    mousPos.z = 0;
    return mousPos;
  }
}

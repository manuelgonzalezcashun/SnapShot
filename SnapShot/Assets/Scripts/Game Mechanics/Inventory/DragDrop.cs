using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragDrop : MonoBehaviour
{
    Vector2 mousePos;
    void Update()
    {
        FollowMousePos();
    }
    private void OnMouseDrag()
    {
        gameObject.transform.position = mousePos;
    }
    private void FollowMousePos()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}

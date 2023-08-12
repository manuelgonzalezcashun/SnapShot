using System;
using UnityEngine;

public class DragDrop : MonoBehaviour
{
    public static event Action DraggingPicture;
    public static event Action DroppedPicture;
    Vector2 mousePos;

    void Update()
    {
        FollowMousePos();
    }
    private void OnMouseDrag()
    {
        gameObject.transform.position = mousePos;
        DraggingPicture?.Invoke();
    }
    private void OnMouseUp()
    {
        DroppedPicture?.Invoke();
    }
    private void FollowMousePos()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}

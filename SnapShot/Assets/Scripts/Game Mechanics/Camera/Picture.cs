using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Picture : MonoBehaviour
{
    public static event Action<PictureData> onCollectPicture;
    public static event Action pictureCollected;

    public InputAction collectAction;
    public PictureData picData;
    private void Awake()
    {
        gameObject.name = picData.pictureName;

        CameraScript.PhotoCapture += FindPhoto;
        collectAction.Enable();
        collectAction.performed += CollectPicture;

        gameObject.GetComponent<SpriteRenderer>().sprite = picData.picSprite;
        gameObject.SetActive(false);
    }
    private void OnDestroy()
    {
        CameraScript.PhotoCapture -= FindPhoto;
        collectAction.performed -= CollectPicture;
        collectAction.Disable();
    }

    private void FindPhoto(string photoName)
    {
        if (picData.pictureName == photoName)
        {
            gameObject.SetActive(true);
        }
    }
    private void CollectPicture(InputAction.CallbackContext ctx)
    {
        if (gameObject.activeSelf)
        {
            onCollectPicture?.Invoke(picData);
            Destroy(gameObject);
            pictureCollected?.Invoke();
        }
    }
}

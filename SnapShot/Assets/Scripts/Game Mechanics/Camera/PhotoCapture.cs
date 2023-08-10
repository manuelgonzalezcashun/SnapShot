using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PhotoCapture : MonoBehaviour
{
    [Header("Photo Taker")]
    [SerializeField] private Image photoDisplayArea;
    [SerializeField] private GameObject photoFrame;

    private Texture2D screenCapture;
    public SpriteRenderer spriteRenderer;
    public Sprite newSprite;

    IEnumerator CapturePhoto()
    {
        //Camera UI set false

        yield return new WaitForEndOfFrame();

        Rect regionToRead = new Rect(0, 0, Screen.width, Screen.height);

        screenCapture.ReadPixels(regionToRead, 0, 0, false);
        screenCapture.Apply();
        ShowPhoto();
    }

     void ShowPhoto()
    {
        Sprite photoSprite = Sprite.Create(screenCapture, new Rect(0.0f, 0.0f, screenCapture.width, screenCapture.height), new Vector2(0.5f, 0.5f), 100.0f);
        photoDisplayArea.sprite = newSprite;

        photoFrame.SetActive(true);
    }
   
   public void RemovePhoto()
    {
        photoFrame.SetActive(false);
        //CameraUI true 
    }
    public void ChangeSprite()
    {
        spriteRenderer.sprite = newSprite;
    }
}

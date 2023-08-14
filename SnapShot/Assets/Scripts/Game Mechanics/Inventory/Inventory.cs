using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System;
using UnityEngine.InputSystem;

public class Inventory : MonoBehaviour, IDataPersistence
{
    public static event Action<bool> onShowInventory;

    private HashSet<PictureData> pictures = new HashSet<PictureData>();
    private HashSet<SavePictureData> saves = new HashSet<SavePictureData>();

    private SavePictureData savePictureData;

    [SerializeField] private GameObject[] inventorySlots;
    [SerializeField] private InputAction openInventory;

    private bool isInventoryShowing = false;


    private void Awake()
    {
        openInventory.Enable();
        openInventory.performed += OpenInventoryWithController;

        Picture.onCollectPicture += AddInventory;
    }
    private void OnDestroy()
    {
        Picture.onCollectPicture -= AddInventory;
        openInventory.performed -= OpenInventoryWithController;
        openInventory.Disable();
    }

    private void Start()
    {
        gameObject.SetActive(isInventoryShowing);
    }


    // Adds Items into inventory
    public void AddInventory(PictureData pic)
    {
        savePictureData = new SavePictureData(pic);

        pictures.Add(pic);
        saves.Add(savePictureData);

        ShowItems();
    }
    // Shows the Inventory UI
    private void ShowItems()
    {
        int index = 0;
        {
            foreach (PictureData pic in pictures)
            {
                if (pic != null)
                {
                    inventorySlots[index].GetComponentInChildren<Image>().sprite = pic.picSprite;
                }
                index++;
            }
        }
    }
    public void OpenInventory()
    {
        if (!isInventoryShowing)
        {
            isInventoryShowing = true;
        }
        else
        {
            isInventoryShowing = false;
        }

        gameObject.SetActive(isInventoryShowing);
        onShowInventory?.Invoke(isInventoryShowing);
    }

    private void OpenInventoryWithController(InputAction.CallbackContext ctx)
    {
        OpenInventory();
    }

    public void LoadData(GameData data)
    {
        foreach (SavePictureData picData in data.savedPictures)
        {

            PictureData loadPicData = new PictureData();

            loadPicData.pictureName = picData.pictureName;
            loadPicData.picSprite = picData.pictureSprite;

            AddInventory(loadPicData);
        }
    }

    public void SaveData(GameData data)
    {
        data.savedPictures.Clear();
        foreach (SavePictureData savePics in saves)
        {
            if (savePics != null)
            {
               data.savedPictures.Add(savePics);
            }
        }
    }
}

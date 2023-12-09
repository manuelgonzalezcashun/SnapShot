using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour, IDataPersistence
{
    public static event Action<bool> onShowInventory;

    [SerializeField] private GameObject[] inventorySlots;
    [SerializeField] private InputAction openInventory;

    private bool isInventoryShowing = false;
    private Inventory inventory;
    private void Awake()
    {
        inventory = new Inventory();

        openInventory.Enable();
        openInventory.performed += OpenInventoryWithController;
        Picture.onCollectPicture += AddPictures;
    }

    private void OnDestroy()
    {
        Picture.onCollectPicture -= AddPictures;
        openInventory.performed -= OpenInventoryWithController;
        openInventory.Disable();
    }

    public void AddPictures(PictureData picture)
    {
        SavePictureData savePictureData = new SavePictureData(picture);

        foreach (SavePictureData savedPicture in inventory.pictures)
        {
            if (savePictureData.pictureName == savedPicture.pictureName)
            {
                Debug.Log("Already exists! Do not add!");
                return;
            }
        }

        Debug.Log("Adding Pictures");
        inventory.pictures.Add(savePictureData);
    }

    private void Start()
    {
        gameObject.SetActive(isInventoryShowing);
    }
    private void Update()
    {
        ShowItems();
    }
    private void ShowItems()
    {

        for (int i = 0; i < inventory.pictures.Count; i++)
        {
            inventorySlots[i].GetComponentInChildren<Image>().sprite = inventory.pictures[i].pictureSprite;
        }
    }
    private void OpenInventoryWithController(InputAction.CallbackContext ctx)
    {
        OpenInventory();
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

    public void LoadData(GameData data)
    {
        inventory.pictures = data.inventory.pictures;
    }

    public void SaveData(GameData data)
    {
        data.inventory.pictures = inventory.pictures;
    }
}

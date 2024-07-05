using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InventoryUI : MonoBehaviour
{
    [SerializeField] private ShopManager _shopManager;
    [SerializeField] private Transform _inventorySlots;
    [SerializeField] private PlayerClothingManager _clothingManager;

    private void Start()
    {
        PopulateInventorySlot();
    }

    public void PopulateInventorySlot()
    {
        PopulateShopSlots(_shopManager.PlayerInventory.items);
    }

    private void PopulateShopSlots(List<ItemData> items)
    {
        ClearSlots();

        for (int i = 0; i < _inventorySlots.childCount; i++)
        {
            Transform slot = _inventorySlots.GetChild(i);
            Image itemImage = slot.Find("Item").GetComponent<Image>();
            Button button = slot.GetComponent<Button>();

            if (i < items.Count)
            {
                ItemData item = items[i];

                if (item is ClothItem clothItem)
                {
                    itemImage.sprite = clothItem.sprite;
                    ClothItem localItem = clothItem;
                    
                    
                    button.onClick.RemoveAllListeners();
                    button.onClick.AddListener(() => _clothingManager.ChangeClothing(localItem));
                }
                else
                {
                    itemImage.sprite = null;
                }

                itemImage.gameObject.SetActive(true);
            }
            else
            {
                itemImage.gameObject.SetActive(false);
            }
        }
    }

    private void ClearSlots()
    {
        for (int i = 0; i < _inventorySlots.childCount; i++)
        {
            Transform slot = _inventorySlots.GetChild(i);
            Image itemImage = slot.Find("Item").GetComponent<Image>();

            itemImage.sprite = null;
            itemImage.gameObject.SetActive(false);
        }
    }
}

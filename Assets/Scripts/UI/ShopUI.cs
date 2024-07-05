using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopUI : MonoBehaviour
{
    [SerializeField] private ShopManager _shopManager;
    [SerializeField] private Transform _slotsParent;
    [SerializeField] private Text _moneyText;

    private void Start()
    {
        _shopManager.buyItem.AddListener(OnItemBought);
        _shopManager.sellItem.AddListener(OnItemSold);
        PopulateBuySlot();
    }

    private void OnDestroy()
    {
        _shopManager.buyItem.RemoveListener(OnItemBought);
        _shopManager.sellItem.RemoveListener(OnItemSold);
    }

    private void OnItemBought()
    {
        PopulateBuySlot();
    }

    private void OnItemSold()
    {
        PopulateSellSlots();
    }

    public void PopulateBuySlot()
    {
        PopulateShopSlots(_shopManager.ShopInventory.items, BuyItem, "Buy");
    }

    public void PopulateSellSlots()
    {
        PopulateShopSlots(_shopManager.PlayerInventory.items, SellItem, "Sell");
    }

    private void PopulateShopSlots(List<ItemData> items, System.Action<ItemData, Transform> actionCallback, string actionLabel)
    {
        ClearSlots();
        _moneyText.text = _shopManager.PlayerInventory.currency + "$";

        for (int i = 0; i < _slotsParent.childCount; i++)
        {
            Transform slot = _slotsParent.GetChild(i);
            Image itemImage = slot.Find("Image").GetComponent<Image>();
            Button itemButton = slot.Find("Buy").GetComponent<Button>();
            Text buttonText = itemButton.GetComponentInChildren<Text>();

            if (i < items.Count)
            {
                ItemData item = items[i];

                if (buttonText != null)
                {
                    buttonText.text = $"{(actionLabel == "Buy" ? item.buyPrice : item.sellPrice)}$ {actionLabel}";
                }

                if (item is ClothItem clothItem)
                {
                    itemImage.sprite = clothItem.sprite;
                }
                else
                {
                    itemImage.sprite = null;
                }

                itemButton.onClick.RemoveAllListeners();
                itemButton.onClick.AddListener(() => actionCallback(item, slot));

                itemImage.gameObject.SetActive(true);
                itemButton.gameObject.SetActive(true);
            }
            else
            {
                itemImage.gameObject.SetActive(false);
                itemButton.gameObject.SetActive(false);
            }
        }
    }

    private void ClearSlots()
    {
        for (int i = 0; i < _slotsParent.childCount; i++)
        {
            Transform slot = _slotsParent.GetChild(i);
            Image itemImage = slot.Find("Image").GetComponent<Image>();
            Button itemButton = slot.Find("Buy").GetComponent<Button>();

            itemImage.sprite = null;
            itemImage.gameObject.SetActive(false);
            itemButton.gameObject.SetActive(false);
            itemButton.onClick.RemoveAllListeners();
        }
    }

    private void BuyItem(ItemData item, Transform slot)
    {
        _shopManager.BuyItem(item);
    }

    private void SellItem(ItemData item, Transform slot)
    {
        _shopManager.SellItem(item);
    }
}

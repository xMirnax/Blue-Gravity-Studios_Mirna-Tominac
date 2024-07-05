using System;
using UnityEngine;
using UnityEngine.Events;

public class ShopManager : MonoBehaviour
{
    [SerializeField] private Inventory _playerInventorySO;
    [SerializeField] private Inventory _shopInventorySO;

    private Inventory _playerInventory;
    private Inventory _shopInventory;
    public Inventory ShopInventory => _shopInventory;
    public Inventory PlayerInventory => _playerInventory;

    public UnityEvent buyItem;
    public UnityEvent sellItem;
    private void Awake()
    {
        _playerInventory = Instantiate(_playerInventorySO);
        _shopInventory = Instantiate(_shopInventorySO);
    }

    public bool BuyItem(ItemData item)
    {
        if (_playerInventory.currency >= item.buyPrice)
        {
            _playerInventory.currency -= item.buyPrice;
            _shopInventory.currency += item.buyPrice;
            _playerInventory.AddItem(item);
            _shopInventory.RemoveItem(item);
            buyItem?.Invoke();
            Debug.Log($"Bought {item.itemName}. Remaining currency: {_playerInventory.currency}");
            return true;
        }
        else
        {
            Debug.Log("Not enough currency to buy this item.");
            return false;
        }
    }
    
    public bool SellItem(ItemData item)
    {
            _playerInventory.currency += item.sellPrice;
            _shopInventory.currency -= item.sellPrice;
            _playerInventory.RemoveItem(item);
            _shopInventory.AddItem(item);
            sellItem?.Invoke();
            Debug.Log($"Sold {item.itemName}. Remaining currency: {_playerInventory.currency}");
            return true;
    }
}
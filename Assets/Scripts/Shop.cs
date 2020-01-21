using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField]
    private Transform panel;

    [SerializeField]
    private GameObject buttonPrefab;
    [SerializeField]
    private ItemManager itemManager;

    void Start()
    {
        foreach (Item item in itemManager.items)
        {
            GameObject newButton = Instantiate(buttonPrefab, panel);
            newButton.GetComponent<ItemButton>().SetUp(item);
        }
        
    }

    public void BuyItem(Item _item)
    {
        if(CurrentUser.instance.gold >= _item.itemPrice)
        {
            CurrentUser.instance.inventory.Add(_item.itemName);
            CurrentUser.instance.gold -= _item.itemPrice;
            FirebaseManager.Instance.WriteNewUser(CurrentUser.instance);
        }
    }    
}

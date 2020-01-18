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

    public string InventoryList()
    {
        string listString = @"[""";
        for(int i = 0;i < CurrentUser.instance.inventory.Count; i++)
        {
            listString += CurrentUser.instance.inventory[i];
            if (i < CurrentUser.instance.inventory.Count - 1)
                listString += @""",""";
            else listString += @"""]";
        }
        return listString;
    }
}

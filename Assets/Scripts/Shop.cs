﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Shop : MonoBehaviour
{
    [SerializeField]
    private Transform panel;

    [SerializeField]
    private GameObject buttonPrefab;
    [SerializeField]
    private ItemManager itemManager;

    [SerializeField]
    private TMP_Text userGoldAmountText;


    void Start()
    {

        foreach (Item item in itemManager.items)
        {
            GameObject newButton = Instantiate(buttonPrefab, panel);
            newButton.GetComponent<ItemButton>().SetUp(item);
        }

        UpdateShopUI();
    }

    public void BuyItem(Item _item)
    {
        if(CurrentUser.instance.gold >= _item.itemPrice)
        {
            CurrentUser.instance.inventory.Add(_item.itemName);
            CurrentUser.instance.gold -= _item.itemPrice;
            FirebaseManager.Instance.WriteNewUser(CurrentUser.instance);
            UpdateShopUI();
        }
    }

    public void UpdateShopUI()
    {
        userGoldAmountText.text = CurrentUser.instance.gold.ToString() + " BOLDS";
    }
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryButton : MonoBehaviour
{
    private Item item;

    [SerializeField]
    private TMP_Text itemName;

    [SerializeField]
    private Image itemImage;

    [SerializeField]
    private TMP_Text itemText;

    [SerializeField]
    //private TMP_Text itemGame;




    public void SetUp(Item _item)
    {
        item = _item;
        itemImage.sprite = item.itemSprite;
        itemName.text = item.itemName;
        //itemGame.text = item.itemGame;
        itemText.text = item.itemText.ToString();

        GetComponentInChildren<Button>().onClick.AddListener(() => OnClick());
    }

    public void OnClick()
    {
        FindObjectOfType<InventoryPopup>().SetUp(item);
    }

}

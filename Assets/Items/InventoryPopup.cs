using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryPopup : MonoBehaviour
{
    [SerializeField]
    private TMP_Text itemName;

    [SerializeField]
    private TMP_Text itemText;

    [SerializeField]

    private TMP_Text itemGame;

    [SerializeField]
    private TMP_Text itemPrice;

    [SerializeField]
    private Image itemImage;



    [SerializeField]
    private GameObject panel;

    private Item item;

    public void SetUp(Item _item)
    {
        item = _item;
        itemName.text = item.itemName;
        itemText.text = item.itemText;
        itemPrice.text = item.itemPrice.ToString();
        itemImage.sprite = item.itemSprite;
        itemGame.text = item.itemGame;
        panel.SetActive(true);

    }

    public void UseItemButton()
    {
        //FindObjectOfType<Shop>().BuyItem(item);
    }

}

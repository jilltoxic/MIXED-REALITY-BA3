using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemButton : MonoBehaviour
{
    private Item item;

    [SerializeField]
    private TMP_Text itemName;

    [SerializeField]
    private TMP_Text itemGame;

    [SerializeField]
    private TMP_Text itemPrice;




    public void SetUp(Item _item)
    {
        item = _item;
        GetComponent<Image>().sprite = item.itemSprite;
        itemName.text = item.itemName;
        itemGame.text = item.itemGame;
        itemPrice.text = item.itemPrice.ToString();

        GetComponent<Button>().onClick.AddListener(() => OnClick());
    }

    public void OnClick()
    {
        FindObjectOfType<ShopPopup>().SetUp(item);
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

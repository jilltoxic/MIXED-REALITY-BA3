using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemButton : MonoBehaviour
{
    private Item item;

    public void SetUp(Item _item)
    {
        item = _item;
        GetComponent<Image>().sprite = item.itemSprite;
        GetComponent<Button>().onClick.AddListener(() => OnClick());
    }

    public void OnClick()
    {
        Debug.Log("asdad");
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

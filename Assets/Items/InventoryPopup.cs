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
    private Camera stageCam;
 
    [SerializeField]
    private GameObject panel;

    [SerializeField]
    private GameObject newModel;

    private Item item;

    private void Start()
    {
        foreach(Camera cam in Camera.allCameras)
        {
            if(cam.gameObject.name == "Stage Camera")
            {
                stageCam = cam;
            }
        }
            
    }

    public void SetUp(Item _item)
    {
        Destroy(newModel);
        item = _item;
        itemName.text = item.itemName;
        itemText.text = item.itemText;
        itemPrice.text = item.itemPrice.ToString();
        //itemImage.sprite = item.itemSprite;
        newModel = Instantiate(item.modelPrefab, stageCam.transform);    
        itemGame.text = item.itemGame;
        panel.SetActive(true);

    }

    public void UseItemButton()
    {
        FindObjectOfType<InventoryScript>().UseItem(item);
    }

}

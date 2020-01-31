using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using TMPro;

public class InventoryScript : MonoBehaviour
{
    [SerializeField]
    private InventoryPopup inventoryPopup;
    
    private List<Item> items;
    public ItemManager itemManager;

    [SerializeField]
    private GameObject itemPrefab;

    [SerializeField]
    private Transform itemPanel;

    [SerializeField]
    private GameObject emptyInventoryText;

    void Start()
    {

        UpdateInventoryUI();
        Debug.Log(items.Count);

        foreach(Item item in items)
        {
            Debug.Log(item.itemName);
        }
    }


    public void UpdateInventoryUI()
    {

        items = new List<Item>();

        foreach (string name in CurrentUser.instance.inventory)
        {
            items.Add(itemManager.items.Find(x => x.itemName == name));
        }

        foreach(Transform child in itemPanel)
        {
            Destroy(child.gameObject);
        }

        foreach (Item item in items)
        {
            GameObject newButton = Instantiate(itemPrefab, itemPanel);
            newButton.GetComponent<InventoryButton>().SetUp(item, inventoryPopup);
        }

        if (items.Count == 0)
        {
            emptyInventoryText.SetActive(true);
        }
        else
        {
            emptyInventoryText.SetActive(false);
        }

    }

    public void UseItem(Item _item)
    {
        CurrentUser.instance.inventory.Remove(_item.itemName);
        items.Remove(_item);
         
        
        FirebaseManager.Instance.WriteNewUser(CurrentUser.instance);
        UpdateInventoryUI();
        
    }
}

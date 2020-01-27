using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class InventoryScript : MonoBehaviour
{
    private List<Item> items;
    public ItemManager itemManager;

    [SerializeField]
    private GameObject itemPrefab;

    [SerializeField]
    private Transform itemPanel;

    void Start()
    {
        UpdateInventoryUI();
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void UpdateInventoryUI()
    {
        items = new List<Item>();

        foreach (string name in CurrentUser.instance.inventory)
        {
            items.Add(itemManager.items.Find(x => x.itemName == name));
        }

        foreach (Item item in items)
        {
            GameObject newButton = Instantiate(itemPrefab, itemPanel);
            newButton.GetComponent<ItemButton>().SetUp(item);
        }
    }
}

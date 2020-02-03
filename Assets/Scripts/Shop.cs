using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Shop : MonoBehaviour
{
    [SerializeField]
    private Transform panel;

    [SerializeField]
    private GameObject buttonPrefab;
    [SerializeField]
    private ItemManager itemManager;

    [SerializeField]
    private GameObject noMoneyPanel;

    [SerializeField]
    private TMP_Text userGoldAmountText;


    void Start()
    {

        noMoneyPanel.SetActive(false);

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
        else
        {
            noMoneyPanel.SetActive(true);
        }
        
    }

    public void UpdateShopUI()
    {
        userGoldAmountText.text = CurrentUser.instance.gold.ToString() + " BOLDS";
    }

    public void ExitButton()
    {
        SceneManager.LoadScene("UI");
    }
}

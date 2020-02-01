using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Item")]
public class Item : ScriptableObject
{
    public string itemName;
    public string itemText;
    public int itemPrice;
    public string itemGame;
    public Sprite itemSprite;
    public GameObject modelPrefab;
    //public Transform modelParent;
}
    

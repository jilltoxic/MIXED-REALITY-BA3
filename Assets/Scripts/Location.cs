using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Location")]
public class Location : ScriptableObject
{
    public int locationID;
    public string locationName;
    public string locationText;
    public double locationCooldown;
    public Sprite locationSprite;

}

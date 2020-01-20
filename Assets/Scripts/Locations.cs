using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Location")]
public class Locations : ScriptableObject
{
    public string locationName;
    public string locationText;
    public float locationCooldown;
    public Sprite locationSprite;
}

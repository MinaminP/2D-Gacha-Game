using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Weapon")]
public class ScriptableWeapon : ScriptableObject
{
    public Sprite weapImage;
    public string weapName;
    public int weapAtk;
    public string weapEffect;
    public Rarity weapRarity;
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Character", menuName = "Character")]
public class ScriptablePlayer : ScriptableObject
{
    public Sprite charaImage;
    public string charaName;
    public int charaAtk;
    public int charaHP;
    public int charaDef;
    public Rarity charaRarity;
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using MyPooler;

public class GachaDisplay : MonoBehaviour, IPooledObject
{
    public ScriptableWeapon weapon;
    public ScriptablePlayer player;
    public Image itemImage;
    public TextMeshProUGUI itemName;
    public TextMeshProUGUI itemDescription;
    public bool isActive = false;

    // Start is called before the first frame update
    void LateUpdate()
    {
        if(weapon != null)
        {
            GachaItemGet(weapon.weapImage, weapon.name, "Attack : " + weapon.weapAtk + "\n" +
                                                        "Effect : " + weapon.weapEffect + "\n" +
                                                        "Rarity : " + weapon.weapRarity.ToString());
            /*itemImage.sprite = weapon.weapImage;
            itemName.text = weapon.name;
            itemDescription.text = "Attack : " + weapon.weapAtk + "\n" +
                                   "Effect : " + weapon.weapEffect + "\n" +
                                   "Rarity : " + weapon.weapRarity.ToString();*/
        } else if (player != null)
        {
            GachaItemGet(player.charaImage, player.charaName, "Attack : " + player.charaAtk + "\n" +
                                                              "HP : " + player.charaHP + "\n" +
                                                              "Def : " + player.charaDef + "\n" +
                                                              "Rarity : " + player.charaRarity.ToString());
            /*itemImage.sprite = player.charaImage;
            itemName.text = player.charaName;
            itemDescription.text = "Attack : " + player.charaAtk + "\n" +
                                   "HP : " + player.charaHP + "\n" +
                                   "Def : " + player.charaDef + "\n" +
                                   "Rarity : " + player.charaRarity.ToString();*/
        }
    }

    public void GachaItemGet(Sprite img, string name, string desc)
    {
        itemImage.sprite = img;
        itemName.text = name;
        itemDescription.text = desc;
    }
    public void OnRequestedFromPool()
    {
        isActive = true;
    }

    public void DiscardToPool()
    {
        ObjectPooler.Instance.ReturnToPool("GachaDisplay", this.gameObject);
        isActive = false;
    }
}

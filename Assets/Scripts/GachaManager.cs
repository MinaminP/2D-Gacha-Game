using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using MyPooler;

public class GachaManager : MonoBehaviour
{
    [SerializeField] private GachaRate[] rate;
    public ScriptablePlayer[] pullCharacter;
    public ScriptableWeapon[] pullWeapon;
    GachaDisplay gachaDisplay;
    [SerializeField] private Transform layoutA, layoutB;
    [SerializeField] private GameObject gachaUIPrefab;
    GameObject gachaUI;
    public GameObject gachaPanel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SinglePull()
    {
        gachaPanel.SetActive(true);
        InstantiateGachaUI(layoutA);

        int randomCharaWeap = UnityEngine.Random.Range(1, 11);
        int getItem = UnityEngine.Random.Range(1, 101);
        Debug.Log(getItem.ToString());

        for (int i = 0; i< rate.Length; i++)
        {
            if(randomCharaWeap >= 5)
            {
                gachaDisplay.weapon = null;
                if (getItem <= rate[i].pullRate)
                {
                    gachaDisplay.player = CharaGet(rate[i]._rarity);
                    return;
                }
            }
            else if (randomCharaWeap < 5) 
            {
                gachaDisplay.player = null;
                if (getItem <= rate[i].pullRate)
                {
                    gachaDisplay.weapon = WeapGet(rate[i]._rarity);
                    return;
                }
            }
        }
    }

    public void MultiplePullsGacha(int pullAmount)
    {
        gachaPanel.SetActive(true);
        for (int i = 0; i < pullAmount; i++)
        {
            if(i <= 4)
            {
                InstantiateGachaUI(layoutA);
            } else
            {
                InstantiateGachaUI(layoutB);
            }

            int randomCharaWeap = UnityEngine.Random.Range(1, 11);
            int getItem = UnityEngine.Random.Range(1, 101);
            Debug.Log(getItem.ToString());

            for (int j = 0; j < rate.Length; j++)
            {
                if (randomCharaWeap >= 5)
                {
                    gachaDisplay.weapon = null;
                    if (getItem <= rate[j].pullRate)
                    {
                        gachaDisplay.player = CharaGet(rate[j]._rarity);
                        break;
                    }
                }
                else if (randomCharaWeap < 5)
                {
                    gachaDisplay.player = null;
                    if (getItem <= rate[j].pullRate)
                    {
                        gachaDisplay.weapon = WeapGet(rate[j]._rarity);
                        break;
                    }
                }
            }
        }
    }

    public void CloseGachaPanel()
    {
            GachaDisplay[] gachaDisplay = FindObjectsOfType<GachaDisplay>();
            for (int i = 0; i < gachaDisplay.Length; i++)
            {
                //Destroy(gachaDisplay[i].gameObject);
                gachaDisplay[i].DiscardToPool();
            }

        gachaPanel.SetActive(false);
    }

    private void InstantiateGachaUI(Transform spawnPos)
    {
        //gachaUI = Instantiate(gachaUIPrefab, spawnPos.position, Quaternion.identity) as GameObject;
        gachaUI =  ObjectPooler.Instance.GetFromPool("GachaDisplay", spawnPos.position, Quaternion.identity) as GameObject;
        gachaUI.transform.SetParent(spawnPos);
        gachaUI.transform.localScale = new Vector3(1, 1, 1);
        gachaDisplay = gachaUI.GetComponent<GachaDisplay>();
    }

    ScriptablePlayer CharaGet(Rarity rarity)
    {
        ScriptablePlayer[] reward = Array.FindAll(pullCharacter, r => r.charaRarity == rarity);
        int result = UnityEngine.Random.Range(0, reward.Length);
        return reward[result];
    }

    ScriptableWeapon WeapGet(Rarity rarity) 
    {
        ScriptableWeapon[] reward = Array.FindAll(pullWeapon, r => r.weapRarity == rarity);
        int result = UnityEngine.Random.Range(0, reward.Length);
        return reward[result];
    }

    public int Rates(Rarity rarity)
    {
        GachaRate gr = Array.Find(rate, rt => rt._rarity == rarity);
        if (gr != null)
        {
            return gr.pullRate;
        }
        else
        {
            return 0;
        }
    }
}
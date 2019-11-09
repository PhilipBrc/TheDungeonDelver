using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour
{
    int gold;
    int weapon;
    bool hasAttackStrike = false;
    bool hasBlockStrike = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public int getGold()
    {
        return gold;
    }
    public int getWep()
    {
        return weapon;
    }
    public void setGold(int x)
    {
        gold = x;
    }
    public void setWep(int x)
    {
        weapon = x;
    }
    public void plusGold(int x)
    {
        if (x >= 0)
        {
            gold = gold + x;
            Debug.Log("Gold Plus: " + getGold());
        }
        else
        {
            gold = 0;
            Debug.Log("Gold set 0: " + getGold());
        }
    }

    public void plusWeapon(int x)
    {
        if (x >= 0)
        {
            weapon = weapon + x;
        }
        else
        {
            weapon = 0;
        }
    }
    public void learnatkStrike()
    {
        bool hasAttackStrike = true;
    }

    public void learnblockStrike()
    {
        bool hasBlockStrike = true;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Stat
{
    [SerializeField] private int STR;
    [SerializeField] private int AGI;
    [SerializeField] private int CON;
    [SerializeField] private int armor;
    [SerializeField] private int hp;
    [SerializeField] private int minDamage;
    [SerializeField] private int maxDamage;
    [SerializeField] private int level;
    [SerializeField] private int xp;
    [SerializeField] private int money;

    //reset values function (nextlevel)
    public void InitStat()
    {
        STR = 20;
        AGI = 20;
        CON = 20;
        armor = 150;
        hp = 100;
        GetMinMaxDamage();
        level = 1;
        xp = 400;
        money = 100;
    }

    public float getHitChance(int target)
    {
        float chance;

        chance = (75 + AGI - target) / 100;
        return chance;
    }

    public void GetMinMaxDamage()
    {
        minDamage = STR / 2;
        maxDamage = minDamage + 4;
    }

    public int GetBaseDamage()
    {
        int baseDamage = Random.Range(minDamage, maxDamage);
        return (baseDamage);
    }

    public void getDamaged(int dam)
    {
        if (hp > 0)
        {
            Debug.Log("hp " + hp);
            hp -= dam;
            if (hp <= 0)
            {
                //dead
            }
        }
    }

    public int getSTR { get { return STR; } }
    public int getAGI { get { return AGI; } }
    public int getCON { get { return CON; } }
    public int getArmor { get { return armor; } }
    public int getHp { get { return hp; } }
    public int getMinDamage { get { return minDamage; } }
    public int getMaxDamage { get { return maxDamage; } }
    public int getLevel { get { return level; } }
    public int getXp { get { return xp; } }
    public int getMoney { get { return money; } }

    public int setSTR { set {STR = value; } }
    public int setAGI { set {AGI = value; } }
    public int setCON { set {CON = value; } }
    public int setArmor { set {armor = value; } }

    public int setHp { set {hp = value; } }
    public int setMinDamage { set {minDamage = value; } }
    public int setMaxDamage { set {maxDamage = value; } }
    public int setLevel { set {level = value; } }
    public int setXp { set {xp = value; } }
    public int setMoney { set {money = value; } }



    //[SerializeField]
    //private int baseValue;

    //private List<int> modifiers = new List<int>();
    //public int GetValue()
    //{
    //    int finalValue = baseValue;
    //    modifiers.ForEach(x => finalValue += x)
    //             return finalValue;
    //}

    //public void AddModifier (int modifier)
    //{
    //    if (modifier != 0)
    //        modifiers.Add(modifier);
    //}

    //public void RemoveModifier(int modifier)
    //{
    //    if (modifier != 0)
    //        modifiers.Remove(modifier);
    //}
}

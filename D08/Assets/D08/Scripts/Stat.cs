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
    [SerializeField] private float hp;
    [SerializeField] private int minDamage;
    [SerializeField] private int maxDamage;
    [SerializeField] private int level;
    [SerializeField] private float xp;
    [SerializeField] private int money;

    //reset values function (nextlevel)
    public void InitStat()
    {
        STR = Random.Range(10, 20);
        AGI = Random.Range(10, 20);
        CON = Random.Range(10, 20);
        armor = 150;
        hp = 5 * CON;
        minDamage = STR / 2;
        maxDamage = minDamage + 4;
        level = 1;
        xp = 0;
        money = 100;
    }

    public float getHitChance(int target)
    {
        float chance;

        chance = (75 + AGI - target) / 100;
        return chance;
    }

    public int getBaseDamage()
    {
        int baseDamage = Random.Range(minDamage, maxDamage);
        return (baseDamage);
    }

    public int getFinalDamage(int baseDamage, int target)
    {
        int finalDamage = baseDamage * (1 - (target / 200));
        return (finalDamage);
    }

    public int getSTR { get { return STR; } }
    public int getAGI { get { return AGI; } }
    public int getCON { get { return CON; } }
    public int getArmor { get { return armor; } }
    public float getHp { get { return Mathf.Clamp(hp, 0, 500); } }
    public int getMinDamage { get { return minDamage; } }
    public int getMaxDamage { get { return maxDamage; } }
    public int getLevel { get { return level; } }
    public float getXp { get { return xp; } }
    public int getMoney { get { return money; } }

    public int setSTR { set {STR = value; } }
    public int setAGI { set {AGI = value; } }
    public int setCON { set {CON = value; } }
    public int setArmor { set {armor = value; } }

    public float setHp { set {hp = value; } }
    public int setMinDamage { set {minDamage = value; } }
    public int setMaxDamage { set {maxDamage = value; } }
    public int setLevel { set {level = value; } }
    public float setXp { set {xp = value; } }
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

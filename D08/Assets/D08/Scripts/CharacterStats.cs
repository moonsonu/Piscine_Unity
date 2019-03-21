using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth { get; private set; }
    public Stat damage;
    public Stat armor;

    private void Awake()
    {
        currentHealth = maxHealth;
    }


    private void TakeDamage (int dam)
    {
        dam -= armor.GetValue();
        dam = Mathf.Clamp(dam, 0, int.MaxValue);
        currentHealth -= dam;
        Debug.Log(transform.name + "takes " + damage + " damage.");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public virtual void Die()
    {
        //die in some way
        //this method is meant to be overwritten
        Debug.Log(transform.name + "died.");
    }
}

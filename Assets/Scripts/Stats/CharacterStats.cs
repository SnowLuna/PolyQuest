using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharacterStats : MonoBehaviour {

    public string playerName = "Player";
    public float maxHealth = 100;
    public float currentHealth { get; private set; }
    public float maxMana = 100;
    public float currentMana { get; private set; }
    public Stat damage;
    public Stat armor;
    public Image healthBar;
    public Image manaBar;
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI manaText;
    public TextMeshProUGUI nameText;

    //Makes it so there can only be a single instance of the player
    #region Singleton
    public static CharacterStats instance;
    void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of Player found!");
            return;
        }
        instance = this;

        currentHealth = maxHealth;
        currentMana = maxMana;
        nameText.text = string.Format("< {0} >", playerName);
    }
    #endregion

    void Update()
    {
        //For test purposes
        if (Input.GetKeyDown(KeyCode.T))
        {
            TakeDamage(10);
            CastSpell(15);
        }
        healthText.text = string.Format("{0} / {1}", currentHealth, maxHealth);
        manaText.text = string.Format("{0} / {1}", currentMana, maxMana);
    }

    public void RecoverHealth(int recoveredHealth)
    {
        currentHealth += recoveredHealth;
        if (currentHealth >= maxHealth)
            currentHealth = maxHealth;
        healthBar.fillAmount = currentHealth / maxHealth;
    }

    public void RecoverMana(int recoveredMana)
    {
        currentMana += recoveredMana;
        if (currentMana >= maxMana)
            currentMana = maxMana;
        manaBar.fillAmount = currentMana / maxMana;
    }

    public void TakeDamage(int damage)
    {
        damage -= armor.GetValue();
        damage = Mathf.Clamp(damage, 0, int.MaxValue);  //Damage can only be positive

        currentHealth -= damage;
        //Debug.Log(transform.name + " takes " + damage + " damamge.");

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Die();
        }
        healthBar.fillAmount = currentHealth / maxHealth;
    }

    //Currently has an integer as argument, could be changed for Spell type later on
    public void CastSpell(int manaCost)
    {
        currentMana -= manaCost;
        if (currentMana <= 0)
        {
            currentMana = 0;
            OutOfMana();
        }
        manaBar.fillAmount = currentMana / maxMana;
    }

    public virtual void Die()
    {
        Debug.Log(transform.name + " died.");
    }

    public virtual void OutOfMana()
    {
        Debug.Log(transform.name + " is out of mana.");
    }
}

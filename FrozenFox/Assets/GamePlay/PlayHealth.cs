using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayHealth : MonoBehaviour
{
    // Start is called before the first frame update
    public int maxHealth = 3;
    public int currentHealth;
    public Text health;
    
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        healthText.text = currentHealth.toString();
    }

    public void TakeDamage(int damage){
        currentHealth -= damage;
        Update();

        if(currentHealth <= 0){
            Die();
        }
    }

    void Die(){
        Debug.log("Player died");
    }

    public void Heal(int amount){
        currentHealth += amount;
        currentHealth = Mathf.Min(currentHealth, maxHealth);
        Update();
    }


}

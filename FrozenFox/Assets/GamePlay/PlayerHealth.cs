using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerHealth : MonoBehaviour
{
    // Start is called before the first frame update
    public int maxHealth = 3;
    public int currentHealth = 3;
    private Image circle1, circle2, circle3;

    private GameObject GameOverText;
    
    void Start()
    {
        circle1 = GameObject.FindGameObjectWithTag("Health1").GetComponent<Image>();
        circle2 = GameObject.FindGameObjectWithTag("Health2").GetComponent<Image>();
        circle3 = GameObject.FindGameObjectWithTag("Health3").GetComponent<Image>();
        GameOverText = GameObject.Find("GameOverText");
        GameOverText.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if(currentHealth == 1){
            circle1.enabled = true;
            circle2.enabled = false;
            circle3.enabled = false;
        }
        else if(currentHealth == 2)
        {
            circle1.enabled = true;
            circle2.enabled = true;
            circle3.enabled = false;
        }
        else if(currentHealth == 3){
            circle1.enabled = true;
            circle2.enabled = true;
            circle3.enabled = true;
        }
        else{
            circle1.enabled = false;
            circle2.enabled = false;
            circle3.enabled = false;
        }
    }

    public void TakeDamage(int damage){
        currentHealth -= damage;
        Update();

        if(currentHealth <= 0){
            Die();
        }
    }

    void Die(){
        Debug.Log("Player died");
        Time.timeScale = 0;
        GameOverText.SetActive(true);
        // Destroy(gameObject);
    }

    public void Heal(int amount){
        currentHealth += amount;
        currentHealth = Mathf.Min(currentHealth, maxHealth);
        Update();
    }


}

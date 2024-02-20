using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerHealth : MonoBehaviour
{
    // Start is called before the first frame update
    public int maxHealth = 3;
    public int currentHealth = 3;
    private GameObject circle1, circle2, circle3;
    
    void Start()
    {
        circle1 = GameObject.Find("Circle1");
        circle2 = GameObject.Find("Circle2");
        circle3 = GameObject.Find("Circle3");

        if (circle1 == null || circle2 == null || circle3 == null)
        {
            Debug.LogError("Failed to find circles!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        circle1.SetActive(currentHealth >= 1);
        circle2.SetActive(currentHealth >= 2);
        circle3.SetActive(currentHealth == 3);
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
    }

    public void Heal(int amount){
        currentHealth += amount;
        currentHealth = Mathf.Min(currentHealth, maxHealth);
        Update();
    }


}

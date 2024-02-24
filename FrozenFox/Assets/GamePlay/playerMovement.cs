using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class playerMovement : MonoBehaviour
{

    private Rigidbody2D rb;
    [SerializeField] private float speed;
    [SerializeField] private float jumpPower;
    public Vector2 boxSize;
    public float castDistance;
    public LayerMask groundLayer;
    public bool isFreeze;
    private float horinzontalInput;
    private float totalFreezeTime;
    public GameObject WinText;
    private float startTime, endTime;
    private Image star1, star2, star3;
    public PlayerHealth playerHealth;
    // Start is called before the first frame update
    void Start()
    {
        WinText = GameObject.Find("WinText");
        WinText.SetActive(false);
        rb = GetComponent<Rigidbody2D>();
        playerHealth = GetComponent<PlayerHealth>();
        FindObjectOfType<AudioManager>().Play("BGM");    //Play BGM
        speed = 3f;
        jumpPower = 25f;
        isFreeze = false;
        totalFreezeTime = 3f;
        startTime = Time.time;
        star1 = GameObject.FindGameObjectWithTag("Star1").GetComponent<Image>();
        star1.enabled = false;
        star2 = GameObject.FindGameObjectWithTag("Star2").GetComponent<Image>();
        star2.enabled = false;
        star3 = GameObject.FindGameObjectWithTag("Star3").GetComponent<Image>();
        star3.enabled = false;
        if (star1 == null || star2 == null || star3 == null)
        {
            Debug.Log("Stars not found");
        }
    }

    // Update is called once per frame
    void Update()
    {
        horinzontalInput = Input.GetAxisRaw("Horizontal");


        if (Input.GetKeyDown(KeyCode.W) && isGround())
        {
            rb.velocity = new Vector3(0, jumpPower, 0);
        }
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(horinzontalInput * speed, rb.velocity.y);
        if (Input.GetKeyDown(KeyCode.Z))
        {
            playerHealth.TakeDamage(1);
        }

        // if (Input.GetKeyDown(KeyCode.X))
        // {
        //     playerHealth.Heal(1);
        // }

        if (isFreeze)
        {
            totalFreezeTime -= Time.deltaTime;
            jumpPower = 0;
            speed = 0;
            if (totalFreezeTime <= 0)
            {
                totalFreezeTime = 3;
                isFreeze = false;
            }
        }
        else if (!isFreeze)
        {
            jumpPower = 25f;
            speed = 3f;
        }
    }

    public bool isGround()
    {
        if (Physics2D.BoxCast(transform.position, boxSize, 0, -transform.up, castDistance, groundLayer))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position - transform.up * castDistance, boxSize);
    }

    // void OnCollisionEnter2D(Collision2D collision)
    // {
    //     if(collision.gameObject.CompareTag("Treat")){
    //         Debug.Log("collision");
    //         playerHealth.Heal(1);
    //         Destroy(collision.gameObject);
    //     }
    // }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Treat"))
        {
            //FindObjectOfType<AudioManager>().Play("Collision");    //Play have treat sound
            playerHealth.Heal(1);
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("SnowBall"))
        {
            isFreeze = true;
            playerHealth.TakeDamage(1);
            Destroy(other.gameObject);
        }

        if (other.CompareTag("WinSign"))
        {
            Debug.Log("Win");
            WinText.SetActive(true);
            endTime = Time.time;
            float totalTime = endTime - startTime;
            Debug.Log("Total time: " + totalTime);
            if (totalTime <= 5)
            {
                star3.enabled = true;
                star2.enabled = true;
                star1.enabled = true;
            }
            else if (totalTime <= 20)
            {
                star2.enabled = true;
                star1.enabled = true;
            }
            else
            {
                star1.enabled = true;
            }
            Time.timeScale = 0;

        }
    }

}

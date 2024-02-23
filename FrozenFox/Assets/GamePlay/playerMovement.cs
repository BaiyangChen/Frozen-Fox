using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{

    private Rigidbody2D rb;
    [SerializeField] private float speed = 3;
    public Vector2 boxSize;
    public float castDistance;
    public LayerMask groundLayer;

    public PlayerHealth playerHealth;

    public GameObject WinText;

    private float startTime, endTime;

    public GameObject star1, star2, star3;

    // Start is called before the first frame update
    void Start()
    {
        WinText = GameObject.Find("WinText");
        rb = GetComponent<Rigidbody2D>();
        playerHealth = GetComponent<PlayerHealth>();
        WinText.SetActive(false);
        FindObjectOfType<AudioManager>().Play("BGM");    //Play BGM
        startTime = Time.time;
        star1 = GameObject.Find("Star1");
        star1.SetActive(false);
        star2 = GameObject.Find("Star2");
        star2.SetActive(false);
        star3 = GameObject.Find("Star3");
        star3.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {

        float horinzontalInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(horinzontalInput * speed, rb.velocity.y);

        if (Input.GetKeyDown(KeyCode.W) && isGround())
        {
            rb.AddForce(new Vector2(rb.velocity.x, 600));
        }

        if(Input.GetKeyDown(KeyCode.Z))
        {
            playerHealth.TakeDamage(1);
        }

        if(Input.GetKeyDown(KeyCode.X))
        {
            playerHealth.Heal(1);
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
        if (other.CompareTag("WinSign"))
        {
            Debug.Log("Win");
            WinText.SetActive(true);
            endTime = Time.time;
            float totalTime = endTime - startTime;
            Debug.Log("Total time: " + totalTime);
            if(totalTime <= 5){
                star3.SetActive(true);
                star2.SetActive(true);
                star1.SetActive(true);
            }
            else if(totalTime <= 20){
                star2.SetActive(true);
                star1.SetActive(true);
            }
            else{
                star1.SetActive(true);
            }
            Time.timeScale = 0f;
            
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowBallMovement : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rb;
    private GameObject target;
    //private GameObject player;
    public float force;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // target = GameObject.FindGameObjectWithTag("target1");
        // Vector2 targetV2 = (Vector2)target.transform.position;
        // Vector2 direction = targetV2 - (Vector2)transform.position;//rigidbody2D.transform.position;
        // rigidbody2D.velocity = new Vector2(direction.x, direction.y).normalized * force;
    }

    void Update()
    {
        rb.AddForce(Vector2.up * 10);
    }
    // Update is called once per frame



    void OnTriggerEnter2D(Collider2D other)
    {            //for collision detecting
        //playerMovement e = other.collider.GetComponent<playerMovement>();
        //if(e != null){    
        Destroy(gameObject); //fix the enermy if collide
        //}
    }
}

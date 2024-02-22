using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowBallMovement : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rigidbody2D;
    private GameObject target;
    //private GameObject player;
    public float force;
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();   
        target = GameObject.FindGameObjectWithTag("target1"); 
        Vector2 targetV2 =  (Vector2)target.transform.position;
        Vector2 direction = targetV2-(Vector2)transform.position;//rigidbody2D.transform.position;
        Debug.Log("direction is : " + direction);
        rigidbody2D.velocity = new Vector2(direction.x,direction.y).normalized*force;
    }

    
    // Update is called once per frame
    void Update()
    {       //remember to adjust the destory frame depends on the map size
        if(transform.position.magnitude > 120.0f){
            Destroy(gameObject);
        }
    }

    
    //void OntriggerEnter2D(Collision2D other){
    void OnCollisionEnter2D( Collision2D other){            //for collision detecting
        playerMovement e = other.collider.GetComponent<playerMovement>();
        if(e != null){
            
            Destroy(gameObject); //fix the enermy if collide
        }
        /*if (other.gameObject.name=="target1"){
            Destroy(gameObject);
        } */
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowBallShooter : MonoBehaviour
{
    public GameObject SnowBall;
    public Transform snowballPos;
    private float timer;
    //Rigidbody2D rigidbody2d;
    private playerMovement playerScript;
    private bool canShoot;

    // Start is called before the first frame update
    void Start()
    {
        //rigidbody2d = GetComponent<Rigidbody2D>();
        playerScript = FindObjectOfType<playerMovement>();
        canShoot = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerScript.isFreeze == true)
        {
            if (canShoot)
            {
                canShoot = false;
                StartCoroutine(wait(6));
            }
        }
        else
        {
            timer += Time.deltaTime;
            if (canShoot && timer > 3)
            {
                timer = 0;
                shoot();
            }
        }
    }

    void shoot()
    {
        GameObject projectileObject = Instantiate(SnowBall, snowballPos.position, Quaternion.identity);

    }

    IEnumerator wait(float delay)
    {
        Debug.Log("start counting");
        yield return new WaitForSeconds(delay);
        Debug.Log("itis been 6 second");
        canShoot = true;
    }


}

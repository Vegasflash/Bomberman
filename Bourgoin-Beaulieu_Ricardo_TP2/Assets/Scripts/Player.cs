using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public UnitController unitCon;
    public HealthMotor health;
    public Enemy enemy;

    int playerDirection = 0;
    float enemyDelay = 0.5f;

    void Update()
    {
        Move();

    }

    // left = 1
    // right = 2
    // down = 3
    // up = 4


    private void Move()
    {
        Vector3 playerPos = gameObject.transform.position;
        
        if (Input.GetKeyDown("a") && playerPos.x > -2)
        {
            playerDirection = 1;
            unitCon.CharacterMovement(playerDirection);
        }
        if (Input.GetKeyDown("d") && playerPos.x < 2)
        {
            playerDirection = 2;
            unitCon.CharacterMovement(playerDirection);
            Invoke("enemy.MoveEnemy", enemyDelay);

        }
        if (Input.GetKeyDown("s") && playerPos.y > -2)
        {
            playerDirection = 3;
            unitCon.CharacterMovement(playerDirection);
            Invoke("enemy.MoveEnemy", enemyDelay);

        }
        if (Input.GetKeyDown("w") && playerPos.y < 2)
        {
            playerDirection = 4;
            unitCon.CharacterMovement(playerDirection);
            Invoke("enemy.MoveEnemy", enemyDelay);

        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Explosion"))
        {
            Debug.Log("breakthisshit");

            BoxCollider2D boxCol = collision.gameObject.GetComponent<BoxCollider2D>();
            boxCol.isTrigger = true;
            DamagePlayer(1);
        }
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("hit player");
        }
        Debug.Log("entering in trigger but...");
    }

    public void DamagePlayer(int damage)
    {
        health.DecreasePlayerHealth();
    }
}

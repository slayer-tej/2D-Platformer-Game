using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    public GameObject Heart1, Heart2, Heart3;
    public static int health;

    private void Start()
    {
        health = 3;
        Heart1.gameObject.SetActive(true);
        Heart2.gameObject.SetActive(true);
        Heart3.gameObject.SetActive(true);
    }

    private void Update()
    {
        if(health == 2)
        {
            Destroy(Heart3);
        }
        if(health == 1)
        {
            Destroy(Heart2);
        }
        if (health == 0)
        {
            Destroy(Heart1);
            PlayerController playerController = gameObject.GetComponent<PlayerController>();
            playerController.killPlayer();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<EnemyController>() != null)
        {
            Debug.Log("Collision");
            health -= 1;
        }
    }

    
}

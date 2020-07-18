using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public PlayerController playerController;
    public float speed;
    private float direction = 1.0f;
    public int damage;

    private void Update()
    {
        EnemyMovement();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<PlayerController>() != null)
        {
            playerController.UpdateLives(damage);
        }
    }
    private void EnemyMovement()
    {
        Vector2 position = transform.position;
        position.x += direction * speed * Time.deltaTime;
        transform.position = position;
    }
    public void ChangeDirection()
    {
        direction = -direction;
        Vector2 scale = transform.localScale;
        scale.x = -scale.x;
        transform.localScale = scale;
    }
}

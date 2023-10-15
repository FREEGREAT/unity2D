using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Danya : Entity
{
    private float speed = 3.5f;
    private Vector3 dir;
    private SpriteRenderer sprite;
    private int lives = 1;
    [SerializeField] private AudioSource knockSound;

    private void Awake()
    {
        sprite = GetComponentInChildren<SpriteRenderer>();
    }

    private void Start()
    {
        dir = transform.right;
    }

    private void Update()
    {
        Move();
    }

    private Vector3 overlapCirclePosition;
    private float overlapCircleRadius = 0.1f;

    private void Move()
    {
        overlapCirclePosition = transform.position + transform.up * 0.5f + transform.right * dir.x * 0.7f;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(overlapCirclePosition, overlapCircleRadius);
        if (colliders.Length > 0)
        {
         
            if (colliders[0].gameObject != hero.Instance.gameObject)
            {
                dir *= -1f;
                
            }
        }
        transform.position = Vector3.MoveTowards(transform.position, transform.position + dir, speed * Time.deltaTime);
        sprite.flipX = dir.x >= 0.0f;
       
    }




    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject == hero.Instance.gameObject)
        {
            knockSound.Play();
        }
    }
}

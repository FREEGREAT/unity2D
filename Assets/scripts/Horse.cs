using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Horse : Entity
{
    [SerializeField] private int lives = 1;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == hero.Instance.gameObject)
        {
            hero.Instance.GetDamage();
        }
        

    }
    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject == hero.Instance.gameObject)
        {
            lives--;
        }
        if (lives == 0)
        {
            Die();
        }

    }

}

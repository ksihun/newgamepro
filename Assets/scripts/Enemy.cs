﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public int health;
    public Sprite[] sprites;

    SpriteRenderer spriteRenderer;
    Rigidbody2D rigid;


    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigid = GetComponent<Rigidbody2D>();
        rigid.velocity = Vector2.down * speed;


    }

    void OnHit(int dmg)
    {
        health -= dmg;
        spriteRenderer.sprite = sprites[1];
        Invoke("Returnsprite", 0.3f);

        if (health <= 0)
        {
            Destroy(gameObject);

        }
    }
    void Returnsprite()

    {
        spriteRenderer.sprite = sprites[0];
 
        



        }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "BorderAttack")
            Destroy(gameObject);
        else if (collision.gameObject.tag == "playerattack"){
            Attack attack = collision.gameObject.GetComponent<Attack>();
            OnHit(attack.dmg);

            Destroy(collision.gameObject);

        }
            
        


        





    }

}




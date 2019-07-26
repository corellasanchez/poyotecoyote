﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerController : MonoBehaviour
{
    public float speed;

    private Rigidbody2D rb2d;

    private int count;

    public Text countText;

    public Text winText;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        count = 0;
        setCountText();
        winText.text =  "" ;
    }


    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);

        rb2d.AddForce(movement * speed);
    }

    public bool characterInInQuicksand;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("pickup"))
        {
            other.gameObject.SetActive(false);
            count += 1;
            setCountText();
        }
    }

    void setCountText()
    {
       countText.text = "Count: " + count.ToString();
        if(count >= 12)
        {
            winText.text = "You Win";
        }
    }
}


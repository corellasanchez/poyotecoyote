using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyController : MonoBehaviour
{
    private Vector2 target;
    private Vector2 position;
    private float speed = 0.2f;
    
    void Start()
    {
        //ESTE CODIGO LO HACE BALA
        GameObject player = GameObject.Find("Player");
        Transform playerTransform = player.GetComponent<Transform>();
        target = playerTransform.position;

        position = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //ESTE CODIGO LO HACE ENEMIGO
        // GameObject player = GameObject.Find("Player");
        // Transform playerTransform = player.GetComponent<Transform>();
        // target = playerTransform.position;

        transform.position = Vector2.MoveTowards(transform.position, target, speed);
    }
}

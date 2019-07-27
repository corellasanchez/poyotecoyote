using System.Collections;
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
    private bool touchStart = false;
    private Vector2 pointA;
    private Vector2 pointB;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        count = 0;
        setCountText();
        winText.text =  "" ;
    }

    void Update(){
        if(Input.GetMouseButtonDown(0)){
            pointA = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z));
            // circle.transform.position = pointA * -1;
            // outerCircle.transform.position = pointA * -1;
            // circle.GetComponent<SpriteRenderer>().enabled = true;
            // outerCircle.GetComponent<SpriteRenderer>().enabled = true;
        }
        if(Input.GetMouseButton(0)){
            touchStart = true;
            pointB = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z));
        }else{
            touchStart = false;
        }
    }


    void FixedUpdate()
    {
        if(touchStart){ 
            Vector2 offset = pointA - pointB;
            Vector2 direction = Vector2.ClampMagnitude(offset, 1.0f);
            moveCharacter(direction * -1);
            // circle.transform.position = new Vector2(pointA.x + direction.x, pointA.y + direction.y) * -1;
        }else{
            rb2d.velocity = Vector2.zero;
            // circle.GetComponent<SpriteRenderer>().enabled = false;
            // outerCircle.GetComponent<SpriteRenderer>().enabled = false;
        }
    }

    void moveCharacter(Vector2 direction){
        rb2d.AddForce(direction * speed * Time.deltaTime);
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


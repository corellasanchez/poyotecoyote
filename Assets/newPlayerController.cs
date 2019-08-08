using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newPlayerController : MonoBehaviour
{
    private bool moving(){
        if (Input.GetKey(KeyCode.LeftArrow))
            return true;
        if (Input.GetKey(KeyCode.RightArrow))
            return true;
        if (Input.GetKey(KeyCode.UpArrow))
            return true;
        if (Input.GetKey(KeyCode.DownArrow))
            return true;
        return false;
    }

    private float speed = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float y = Input.GetAxis("Vertical");
        float x = Input.GetAxis("Horizontal");

        if (moving()){
            transform.Translate(x, y, speed);
        }else{

        }
    }
}

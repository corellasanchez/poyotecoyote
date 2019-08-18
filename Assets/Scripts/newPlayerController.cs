using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newPlayerController : MonoBehaviour
{

    public Joystick joystick;

    private bool moving()
    {
        if (joystick.Horizontal >= .2f)
        {
            Debug.Log("Right");
            return true;
        }

        if (joystick.Horizontal <= -.2f)
        {
            Debug.Log("Left");
            return true;
        }

        if (joystick.Vertical >= .2f)
        {
            Debug.Log("Top");
            return true;
        }

        if (joystick.Vertical <= -.2f)
        {
            Debug.Log("Down");
            return true;
        }
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

        if (moving())
        {
            transform.Translate(joystick.Horizontal, joystick.Vertical, 0);
            // speed
        }
        else
        {

        }
    }
}

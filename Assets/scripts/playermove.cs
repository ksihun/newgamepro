using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermove : MonoBehaviour
{

    public float speed;
    public bool isTouchtop;
    public bool isTouchbottom;
    public bool isTouchright;
    public bool isTouchleft;
    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        if((isTouchright && h == 1) || (isTouchleft && h == -1))
                h = 0;
    
        float v = Input.GetAxisRaw("Vertical");
        if ((isTouchtop && v == 1) || (isTouchbottom && v == -1))
                v = 0;

        Vector3 curPos = transform.position;
        Vector3 nextPos = new Vector3(h, v, 0) * speed * Time.deltaTime;

        transform.position = curPos + nextPos;

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Border")
        {
            switch (collision.gameObject.name)
            {
                case "top":
                    isTouchtop = true;
                    break;
                case "bottom":
                    isTouchbottom = true;
                    break;
                case "right":
                    isTouchright = true;
                    break;
                case "left":
                    isTouchleft= true;
                    break;

            }

        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Border")
        {
            switch (collision.gameObject.name)
            {
                case "top":
                    isTouchtop = false;
                    break;
                case "bottom":
                    isTouchbottom = false;
                    break;
                case "right":
                    isTouchright = false;
                    break;
                case "left":
                    isTouchleft = false;
                    break;

            }

        }
    }
}

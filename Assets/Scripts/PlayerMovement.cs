using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float xMove;
    public float speed = 10;
    bool jumpKey = false;
    Rigidbody2D rb;

    //jumpCount
    float jumpDelay = 1;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        xMove = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(xMove* speed, rb.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpKey = true;
        }
    }

    private void FixedUpdate()
    {

        if ((jumpKey) && (jumpDelay <= 2))
        {
            rb.velocity = new Vector2(rb.velocity.x, speed);
            jumpKey = false;
            jumpDelay += 1;
            Debug.Log(jumpDelay);
        }
        else {
            jumpDelay = 1;
        }
        
    }
}

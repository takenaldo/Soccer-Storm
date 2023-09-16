using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        reset();
    }

    // Update is called once per frame
    void Update()
    {
        if (InputManager.onMouseDown)
        {
            rb.isKinematic = false;
            rb.velocity = new Vector2(0, 5);
        }
    }
    

    void reset(){
        rb.isKinematic = true;
        rb.velocity = Vector2.zero;
        rb.angularDrag = 0;
        rb.angularVelocity = 0;
    }
}

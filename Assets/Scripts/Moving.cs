using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour
{
    public Rigidbody2D rb;

    private float _game_score = 0;

    // Start is called before the first frame update
    void Start()
    {
            rb = GetComponent<Rigidbody2D>();
            rb.velocity = Vector2.left * GameManager.instance.speed;
    }
}

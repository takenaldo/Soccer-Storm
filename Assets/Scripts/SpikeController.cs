using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeController : MonoBehaviour
{
    Rigidbody2D rb;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("destroy_checker"))
            Destroy(gameObject);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("destroy_checker"))
            Destroy(gameObject);
        else
        {
            if (collision.gameObject.CompareTag("ball"))
            {
                Destroy(collision.gameObject);
                if(Helper.isVibrationON())
                    Handheld.Vibrate();
                GameManager.instance.isGameOver = true;
            }

            if (gameObject.CompareTag("spike_wall_top"))
                gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 2);
            else if (gameObject.CompareTag("spike_wall_bottom"))
                gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -2);
        }
    }
}

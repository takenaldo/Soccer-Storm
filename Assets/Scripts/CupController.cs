using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CupController : MonoBehaviour
{
    private TextMeshProUGUI txtScore;
    // Start is called before the first frame update
    void Start()
    {
        txtScore = GameObject.FindGameObjectWithTag("txt_score").GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ball")){
            GameManager.instance.score += GameManager.CUP_POINTS;
            txtScore.text = GameManager.instance.score + "";
            gameObject.SetActive(false);
        }
    }
}

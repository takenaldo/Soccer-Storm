using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Localization.Settings;
using TMPro;


public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int score = 0;

    public float speed = 0.7f;
    public float starting_speed = 0.7f;


    public static int DOWN_WARD = 2;
    public  static int UP_WARD = 3;
    public static int CUP_POINTS = 1;


    public bool isGameOver;
    private bool repeated = false;


    public TextMeshProUGUI txtHighScore;

    public GameObject lastWallTop;
    public GameObject lastWallBottom;

    
    public bool scoreUpgrade = false;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        loadHighScore();
    }



    // Update is called once per frame
    void Update()
    {
        if (isGameOver)
        {
            if (!repeated)
            {
                if (isHighScoreAchieved())
                    updateHighSCore(score);

                saveLatestScore();
                showGameOverScreen();
                repeated = true;
            }
        }
        checkScoreAndSpeed();
    }



    private void saveLatestScore()
    {
        PlayerPrefs.SetInt(Helper.LATEST_SCORE, score);
    }

    private void showGameOverScreen()
    {
        Helper.gotoScene("GameOver");
    }

    private bool isHighScoreAchieved()
    {
        return score >  PlayerPrefs.GetInt(Helper.HIGH_SCORE, 0);
    }

    private void updateHighSCore(int newHighScore)
    {
        PlayerPrefs.SetInt(Helper.HIGH_SCORE, newHighScore);
        
    }

    private int old_div = 0;
    private int scoreBreak = 10; // the rate for the score where the speed of the game should upgrade everytime
    void checkScoreAndSpeed()
    {
        if ((int)score / scoreBreak != old_div && score > 0)
        {
            old_div = score / scoreBreak;
            float to_add = (float)old_div / 10f;
            

            speed = starting_speed + to_add;

            // set the new speed for all moving objects
            Moving[] movingObjects = GameObject.FindObjectsOfType<Moving>();
            foreach (Moving moving in movingObjects)
            {
                Rigidbody2D rb = moving.GetComponent<Rigidbody2D>();
                rb.velocity =
                rb.velocity = Vector2.left * GameManager.instance.speed;
            }
        }
    }

    private void loadHighScore()
    {
        if (LocalizationSettings.SelectedLocale.LocaleName == "Russian (ru)")
            txtHighScore.text = "лучший: " + Helper.getHighScore() + "";
        else
            txtHighScore.text = "Best: " + Helper.getHighScore() + "";

    }
}

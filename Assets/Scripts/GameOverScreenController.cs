using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Localization.Settings;

public class GameOverScreenController : MonoBehaviour
{
    public TextMeshProUGUI txtScore;
    public TextMeshProUGUI txtHighScore;
    // Start is called before the first frame update
    void Start()
    {
        loadScoreInformation();

    }

    // Update is called once per frame
    void Update()
    {
    }

    private void loadScoreInformation()
    {
        

        if (LocalizationSettings.SelectedLocale.LocaleName == "Russian (ru)")
        {
            txtScore.text = "счёт: " + Helper.getLatestScore();
            txtHighScore.text = "лучший счёт: " + Helper.getHighScore();
        }
        else
        {
            txtScore.text = "SCORE: " + Helper.getLatestScore();
            txtHighScore.text = "BEST SCORE: " + Helper.getHighScore();
        }
    }
}

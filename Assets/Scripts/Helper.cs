using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Helper : MonoBehaviour
{
    public static string SETTING_VIBRATION = "setting_vibration";
    public static string SETTING_MUSIC     = "setting_music";

    public static string STATUS_ON = "on";
    public static string STATUS_OFF = "off";

    public static string HIGH_SCORE = "user_highscore";
    public static string LATEST_SCORE = "user_latest_score";
    public static string LANGUAGE = "user_language";

    public void LoadScene(string name)
    {
        SceneManager.LoadScene(name);
    }

    public static void gotoScene(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void pause()
    {
        Time.timeScale = 0;
    }

    public void resume()
    {
        Time.timeScale = 1;
    }



    public void triggMusicSetting()
    {
        AudioSource[] allAudioSources = getAllAudioSources();
         if (PlayerPrefs.GetString(SETTING_MUSIC, STATUS_ON) == STATUS_ON)
        {
            PlayerPrefs.SetString(SETTING_MUSIC, STATUS_OFF);
            foreach (AudioSource audioSource in allAudioSources)
                audioSource.Stop();
        }
        else if (PlayerPrefs.GetString(SETTING_MUSIC, STATUS_ON) == STATUS_OFF)
        {
            PlayerPrefs.SetString(SETTING_MUSIC, STATUS_ON);
            GetComponent<AudioSource>().Play();
            DontDestroyOnLoad(gameObject);
        }
    }





    public AudioSource[] getAllAudioSources()
    {
      return  GameObject.FindObjectsOfType<AudioSource>();
    }


    public void changeVibrationSetting()
    {
        if(PlayerPrefs.GetString(SETTING_VIBRATION, STATUS_ON) == STATUS_ON)
            PlayerPrefs.SetString(SETTING_VIBRATION, STATUS_OFF);
        else
            PlayerPrefs.SetString(SETTING_VIBRATION, STATUS_ON);
    }


    public static int getHighScore()
    {
        return PlayerPrefs.GetInt(HIGH_SCORE, 0);
    }

    public static bool isMusicON()
    {
        return PlayerPrefs.GetString(Helper.SETTING_MUSIC, Helper.STATUS_ON) == Helper.STATUS_ON;
    }

    public static int getLatestScore()
    {
        return PlayerPrefs.GetInt(Helper.LATEST_SCORE, 0);
    }

    public static bool isVibrationON()
    {
        return PlayerPrefs.GetString(Helper.SETTING_VIBRATION, Helper.STATUS_ON) == Helper.STATUS_ON;
    }

    public static float getRandom()
    {
        return new System.Random().Next();
    }

    public static float getRandom(int max)
    {
        return getRandom() % max;
    }

    public void show(GameObject dialog)
    {
        dialog.SetActive(true);
    }

    public void hide(GameObject dialog)
    {
        dialog.SetActive(false);
    }

    public bool isPaused()
    {
        return Time.timeScale != 0;
    }

    public void timer(float waitingTime)
    {
        StartCoroutine(waiter(waitingTime));
    }

    private IEnumerator waiter(float waitingTimeInsec)
    {
        yield return new WaitForSeconds(waitingTimeInsec);
    }

}

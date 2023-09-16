using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettignButtonController : MonoBehaviour
{
    public Sprite ON;
    public Sprite OFF;

    // Start is callend before the first frame update
    void Start()
    {
        if (CompareTag("btn_setting_sound"))
        {
            if (Helper.isMusicON())
                GetComponent<Image>().sprite = ON;
            else
                GetComponent<Image>().sprite = OFF;
        }
        else if (CompareTag("btn_setting_vibration"))
        {
            if (Helper.isVibrationON())
                GetComponent<Image>().sprite = ON;
            else
                GetComponent<Image>().sprite = OFF;

        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ButtoHelper : MonoBehaviour
{

    public Sprite spriteON, spriteOFF;


    // for buttons that has only two options like on and off
    public void SwitchButtonONOFF()    {
        Image image = gameObject.GetComponent<Image>();
        if (image.sprite == spriteON)
            image.sprite = spriteOFF;
        else
            image.sprite = spriteON;
    }
}

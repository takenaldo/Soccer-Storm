using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SplashScreenManager : MonoBehaviour
{
    public string nextScene= "Main";

    private float startTime;
    public float waitingSeconds = 5;

    public GameObject progressBar;
    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        float now = Time.time;
        
        if (now - startTime > waitingSeconds)
            SceneManager.LoadScene(nextScene);

        progressBar.gameObject.transform.Rotate( 0, 0, 1* 100);
    }

}

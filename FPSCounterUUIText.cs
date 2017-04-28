using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FPSCounterUUIText : MonoBehaviour
{
    private const float UpdateInterval = 0.1f;

    private Text _text;

    #region Calc vars
    private float accum = 0.0f;
    private int frames = 0;
    private float timeleft;
    private int qty;
    private float fps;
    private float avgFps;
    #endregion

    private void Start()
    {
        _text = GetComponent<Text>();
    }

    private void Update()
    {
        timeleft -= Time.deltaTime;
        accum += Time.timeScale / Time.deltaTime;
        ++frames;

        if (timeleft <= 0.0)
        {
            fps = (accum / frames);
            timeleft = UpdateInterval;
            accum = 0f;
            frames = 0;
        }

        qty++;

        avgFps += (fps - avgFps) / qty;

        string str = string.Format("FPS: {0} \nAvg FPS: {1}", fps.ToString("f2"), avgFps.ToString("f2"));
        _text.text = str;
    }
}

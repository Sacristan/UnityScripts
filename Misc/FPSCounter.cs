using UnityEngine;

namespace Sacristan.Utils
{
    public class FPSCounter : MonoBehaviour
    {
        private const float UpdateInterval = 0.1f;

        #region Calc vars
        private float accum = 0.0f;
        private int frames = 0;
        private float timeleft;
        private int qty;
        private float fps;
        private float avgFps;
        #endregion

        void Update()
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
        }

        void OnGUI()
        {
            GUI.Label(new Rect(Screen.width - 72, 0, 150, 20), "FPS: " + fps.ToString("f2"));
            GUI.Label(new Rect(Screen.width - 100, 25, 150, 20), "Avg FPS: " + avgFps.ToString("f2"));
        }

    }
}

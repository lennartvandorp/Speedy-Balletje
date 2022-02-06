using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.SceneManagement;

namespace MyAnalytics
{
    public class WinOrLossAnalytics : MonoBehaviour
    {

        // Start is called before the first frame update
        void Start()
        {
            GameManager.Instance.finishGame += OnWin;
            GameManager.Instance.failGame += OnFail;
        }


        void OnWin()
        {
            PushAnalytic("Win");
        }

        private void OnFail()
        {
            PushAnalytic("Fail");
        }

        void PushAnalytic(string outcome)
        {
            string levelName = SceneManager.GetActiveScene().name;

            AnalyticsResult result =
                Analytics.CustomEvent(levelName + "Result", new Dictionary<string, object>{
                    {"Result", outcome }
            });
            Debug.Log("result: " + result);

        }


    }
}

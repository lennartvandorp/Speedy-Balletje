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
            AnalyticsResult result = Analytics.CustomEvent("LevelResult", new Dictionary<string, object> {
            {SceneManager.GetActiveScene().name, 1 }
            }
                );
        }

        private void OnFail()
        {
            AnalyticsResult result = Analytics.CustomEvent("LevelResult", new Dictionary<string, object> {
            {SceneManager.GetActiveScene().name, 0 } 
            
            });
        }
    }
}

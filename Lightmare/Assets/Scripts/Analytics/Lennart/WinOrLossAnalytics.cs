using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.SceneManagement;

namespace MyAnalytics
{
    public class WinOrLossAnalytics : MonoBehaviour
    {
        [SerializeField] GameObject winPrefab;
        [SerializeField] GameObject failPrefab;

        // Start is called before the first frame update
        void Start()
        {
            GameManager.Instance.finishGame += OnWin;
            GameManager.Instance.failGame += OnFail;
        }


        void OnWin()
        {
            Instantiate<GameObject>(winPrefab);
            AnalyticsResult result =
                Analytics.CustomEvent("levelResultAnalytic", new Dictionary<string, object>
            { { "Level", SceneManager.GetActiveScene().name },
               {"Result", 1 }
            });
            Debug.Log("result: " + result);

        }

        private void OnFail()
        {
            Instantiate<GameObject>(failPrefab);


            /*AnalyticsResult result = Analytics.CustomEvent("levelFail", new Dictionary<string, object> {
            {"Level", SceneManager.GetActiveScene().name }
            });*/

            AnalyticsResult result =
                Analytics.CustomEvent("levelResultAnalytic", new Dictionary<string, object>
            { { "Level", SceneManager.GetActiveScene().name },
               {"Result", 0 }
            });
            Debug.Log("result: " + result);
        }


    }
}

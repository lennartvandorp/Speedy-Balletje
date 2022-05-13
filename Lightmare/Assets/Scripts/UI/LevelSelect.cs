using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class LevelSelect : MonoBehaviour
{
    [SerializeField] private GameObject button;
    [SerializeField] private SelectableLevel[] sceneList;

    // Start is called before the first frame update
    void Start()
    {
        float buttonHeight = 1.7f;
        for (int i = 0; i < sceneList.Length; i++)
        {
            GameObject newbtn = Instantiate(button);
            newbtn.transform.SetParent(transform);
            newbtn.transform.rotation = transform.rotation;
            newbtn.transform.position = transform.position + new Vector3(0f, -i * buttonHeight, 0f);
            newbtn.GetComponentInChildren<TextMeshProUGUI>().text = sceneList[i].sceneTitle;
            string levelString = sceneList[i].sceneName;
            newbtn.GetComponent<Button>().onClick.AddListener(() => { OnClick(levelString); });
        }
    }

     void OnClick(string levelName) {
        SceneManager.LoadScene(levelName);
    }

}

[System.Serializable]
class SelectableLevel
{
    [SerializeField] public string sceneName;
    [SerializeField] public string sceneTitle;
}
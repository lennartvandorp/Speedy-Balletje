using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject onVictoryGroup;
    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.finishGame += EnableVictoryUI;
        GameManager.Instance.restart += DisableVictoryGroup;
        DisableVictoryGroup();
    }

    void EnableVictoryUI()
    {
        onVictoryGroup.active = true;
    }

    void DisableVictoryGroup()
    {
        onVictoryGroup.active = false;
    }

    public void ResetGame()
    {
        GameManager.Instance.Restart();//This should not be fail
    }
}

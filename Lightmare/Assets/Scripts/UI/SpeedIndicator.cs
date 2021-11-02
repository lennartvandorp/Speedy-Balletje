using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class SpeedIndicator : MonoBehaviour
{
    TextMeshProUGUI tmp;
    Rigidbody playerRb;
    // Start is called before the first frame update
    void Start()
    {
        tmp = GetComponent<TextMeshProUGUI>();
        if(tmp == null) { Debug.Log("Nope"); }


        playerRb = GameManager.Instance().Player().GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        tmp.text = Mathf.Round(playerRb.velocity.z).ToString() + " m/s";//Rounds the z speed of the player and displays it to the text. 
    }
}

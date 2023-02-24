using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectToggler : MonoBehaviour
{
    public void ToggleObject()
    {
        bool isItActive = gameObject.active;
        gameObject.SetActive(!isItActive);
    }
}

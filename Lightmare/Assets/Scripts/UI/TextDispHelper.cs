using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextDispHelper : MonoBehaviour
{
    [HideInInspector] public TextMeshProUGUI text;

    // Start is called before the first frame update
    public virtual void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    public string GetText() { return text.text.ToString(); }
    public void SetText(string textToAdd) { text.text = textToAdd; }
}

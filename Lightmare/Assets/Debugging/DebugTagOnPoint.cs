using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace DIYDebug
{
    public class DebugTagOnPoint : MonoBehaviour
    {
        GameObject tag;
        TextMeshPro text;

        public DebugTagOnPoint(GameObject _tag, string tagText)
        {
            tag = Instantiate(_tag);
            text = tag.GetComponentInChildren<TextMeshPro>();
            text.text = tagText;
        }
        public void updateTag(Vector3 pos)
        {
        }
    }
}

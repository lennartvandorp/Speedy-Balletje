using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ObserverPattern
{
    public class Observer : MonoBehaviour
    {
        public virtual void OnNotify() { }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Scriptable Values", menuName = "Scriptable Values/Bool Value")]
[System.Serializable]
public class BoolValue : ScriptableObject
{
    public bool initialValue;
    public bool runtimeValue;
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Scriptable Values", menuName = "Scriptable Values/Int Value")]
[System.Serializable]
public class IntValue : ScriptableObject
{
    public int initialValue;
    public int runtimeValue;
}

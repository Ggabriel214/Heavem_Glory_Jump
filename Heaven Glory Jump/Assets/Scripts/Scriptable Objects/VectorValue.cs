using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Scriptable Values", menuName = "Scriptable Values/Vector Value")]
[System.Serializable]
public class VectorValue : ScriptableObject, ISerializationCallbackReceiver
{
    public Vector3 initalValue;
    public Vector3 defaultValue;

    public void OnAfterDeserialize()
    {
        initalValue = defaultValue;
    }

    public void OnBeforeSerialize()
    {

    }
}

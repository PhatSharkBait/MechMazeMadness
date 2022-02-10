using UnityEngine;

[CreateAssetMenu]
public class Vector3SO : ScriptableObject {
    public Vector3 value;

    public void SetVectorValue(Vector3 data) {
        value = data;
    }
}

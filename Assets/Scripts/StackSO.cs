using UnityEngine;
[CreateAssetMenu]
public class StackSO : ScriptableObject {
    public Stack Data;

    public void SetData(Stack newData) {
        Data = newData;
    }
}

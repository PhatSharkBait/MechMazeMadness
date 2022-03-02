using UnityEngine;

public class BasicInteractable : InteractableBase {
    private void Awake() {
        interactionText = "Click to Get";
    }

    protected override void OnRangeEnter() {
        base.OnRangeEnter();
    }

    protected override void OnRangeExit() {
        base.OnRangeExit();
    }

    protected override void OnInteract() {
        Debug.Log("ya did that didn't you");
    }
}

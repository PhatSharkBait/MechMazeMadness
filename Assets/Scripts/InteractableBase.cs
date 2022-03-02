using System;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public abstract class InteractableBase : MonoBehaviour {
    public GameObject textPivotPrefab;
    
    private float interactionRange = 2.5f;
    private SphereCollider rangeSphere;
    private GameObject _textPivot;
    private TextMesh _textMesh;
    private MeshRenderer _meshRenderer;
    private bool inRange;
    private GameObject player;

    protected string interactionText = "default text";

    private void Start() {
        //Physics
        gameObject.layer = 10;
        rangeSphere = GetComponent<SphereCollider>();

        //get avg scale of object, divide interaction range by new scale
        var lossyScale = transform.lossyScale;
        var newScale = (Mathf.Abs(lossyScale.x) + Mathf.Abs(lossyScale.y) + Mathf.Abs(lossyScale.z))/3;
        Debug.Log(newScale);
        rangeSphere.radius = interactionRange/newScale;
        rangeSphere.isTrigger = true;
        
        //Text
        _textPivot = Instantiate(textPivotPrefab, gameObject.transform);
        _textPivot.transform.localPosition = Vector3.zero;
        _textMesh = _textPivot.GetComponentInChildren<TextMesh>();
        _textMesh.text = interactionText;

        _meshRenderer = _textPivot.GetComponentInChildren<MeshRenderer>();
        _meshRenderer.enabled = false;
    }

    private void Update() {
        if (inRange) {
            // Determine which direction to rotate towards
            Vector3 targetDirection = player.transform.position - _textPivot.transform.position;
            _textPivot.transform.rotation = Quaternion.LookRotation(targetDirection);
            if (Input.GetButtonDown("Fire1")) {
                OnInteract();
            }
        }
    }

    private void OnTriggerEnter(Collider other) {
        player = other.gameObject;
        OnRangeEnter();
    }

    private void OnTriggerExit(Collider other) {
        OnRangeExit();
    }

    protected virtual void OnRangeEnter() {
        inRange = true;
        _meshRenderer.enabled = true;
    }

    protected virtual void OnRangeExit() {
        inRange = false;
        player = null;
        _meshRenderer.enabled = false;
    }

    protected virtual void OnInteract() {
        throw new NotImplementedException();
    }
}

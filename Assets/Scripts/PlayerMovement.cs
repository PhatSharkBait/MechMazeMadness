using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    private Rigidbody _rigidbody;
    private float moveSpeed = 5f;

    private void Start() {
        _rigidbody = GetComponent<Rigidbody>();
    }


    private void FixedUpdate() {
        float xVal = Input.GetAxis("Horizontal");
        float zVal = Input.GetAxis("Vertical");
        float yVal = Input.GetAxis("Jump");
        
        var moveDir = new Vector3(xVal, yVal, zVal).normalized * (Time.deltaTime * moveSpeed) + gameObject.transform.position;
        //transform.Translate(moveDir);
        _rigidbody.MovePosition(moveDir);
    }
}

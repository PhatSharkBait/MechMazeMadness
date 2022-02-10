using UnityEngine;

public class PlayerLook : MonoBehaviour {
    public float mouseSensitivity;
    public Transform playerBody;

    private float xRotation = 0f;

    private void Start() {
        Cursor.lockState = CursorLockMode.Confined;
    }

    void Update() {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation =  Mathf.Clamp(xRotation, -90f, 90f);
        
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }
}

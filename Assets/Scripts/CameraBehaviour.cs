using UnityEngine;

public class FreeCameraController : MonoBehaviour
{
    public float sensitivity = 2.0f;
    public float moveSpeed = 15.0f;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        transform.Rotate(Vector3.up * mouseX * sensitivity, Space.World);
        transform.Rotate(Vector3.left * mouseY * sensitivity, Space.Self);

        float horizontalMovement = Input.GetAxis("Horizontal");
        float verticalMovement = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(horizontalMovement, 0.0f, verticalMovement).normalized;
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime, Space.Self);
    }
}

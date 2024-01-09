using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float rotationSpeed = 10f;

    void Start ()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    float GetSpeed()
    {
        float moveSpeed = 5f;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            return moveSpeed * 2;
        }

        return moveSpeed;
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        float moveSpeed = GetSpeed();

        Vector3 moveDirection = (Camera.main.transform.forward * verticalInput + Camera.main.transform.right * horizontalInput).normalized;
        moveDirection.y = 0;

        transform.Translate(moveDirection * Time.deltaTime * moveSpeed, Space.World);

        if (moveDirection != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(moveDirection, Vector3.up);
            transform.rotation = Quaternion.Lerp(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }

    }
}

using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotationSpeed = 10f;

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 moveDirection = (Camera.main.transform.forward * verticalInput + Camera.main.transform.right * horizontalInput).normalized;
        moveDirection.y = 0;

        transform.Translate(moveDirection * Time.deltaTime, Space.World);

        if (moveDirection != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(moveDirection, Vector3.up);
            transform.rotation = Quaternion.Lerp(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
    }
}

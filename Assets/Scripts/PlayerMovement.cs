using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float rotationSpeed = 10f;
    private Animator animator;
    private float defaultSpeed = 5f;
    private float runningMultiplier = 2f;

    void Start ()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        animator = GetComponent<Animator>();
    }

    float GetSpeed()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            return defaultSpeed * runningMultiplier;
        }

        return defaultSpeed;
    }

    void Update()
    {
        animator.SetBool("isMoving", false);
        animator.SetBool("isRunning", false);
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        float moveSpeed = GetSpeed();

        Vector3 moveDirection = (Camera.main.transform.forward * verticalInput + Camera.main.transform.right * horizontalInput).normalized;
        moveDirection.y = 0;

        transform.Translate(moveDirection * Time.deltaTime * moveSpeed, Space.World);


        if (moveDirection != Vector3.zero)
        {
            animator.SetBool("isMoving", true);
            if (moveSpeed > defaultSpeed)
            {
                animator.SetBool("isRunning", true);
            }

            Quaternion toRotation = Quaternion.LookRotation(moveDirection, Vector3.up);
            transform.rotation = Quaternion.Lerp(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
    }
}

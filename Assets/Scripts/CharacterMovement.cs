using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class CharacterMovement : MonoBehaviour
{
    [Header("Movimiento")]
    [SerializeField] private float speed = 5.0f;
    [SerializeField] private float gravity = -9.81f;

    private CharacterController controller;
    private Vector3 velocity;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        float dt = Time.deltaTime;

        if (controller.isGrounded && velocity.y < 0f)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        Vector3 moveInput = transform.right * x + transform.forward * z;

        if (moveInput.sqrMagnitude > 1f)
        {
            moveInput.Normalize();
        }

        velocity.x = moveInput.x * speed;
        velocity.z = moveInput.z * speed;
        velocity.y += gravity * dt;

        controller.Move(velocity * dt);
    }
}
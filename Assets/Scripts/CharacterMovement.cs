using System;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    float moveSpeed;
    private CharacterController chController;

    void Start()
    {
        chController = GetComponent<CharacterController>();
    }

    void Update()
    {
        Move();

    }

    private void Move()
    {
        // 1
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 input = new Vector3(horizontal, 0, vertical);
        input = Vector3.ClampMagnitude(input, 1.0f);

        //Velocidad movimiento
        Vector3 targetVelocity = input * moveSpeed;

        //6
        chController.Move(input * Time.deltaTime);
    }
}
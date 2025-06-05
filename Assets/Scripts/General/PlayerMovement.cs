using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 10;

    InputAction moveAction;

    private void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
    }

    private void Update()
    {
        Vector2 moveValue = moveAction.ReadValue<Vector2>();

        transform.Translate(new Vector3(moveValue.x, moveValue.y, 0) * moveSpeed * Time.deltaTime);
    }
}

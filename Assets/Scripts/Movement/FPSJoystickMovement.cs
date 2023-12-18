using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FPSJoystickMovement : MonoBehaviour
{
    PlayerControls controls;

    Vector2 move;

    private void Start()
    {
        controls = new PlayerControls();

/*        controls.Gameplay.MoveUp.performed += ctx => move = ctx.ReadValue<Vector2>();
        controls.Gameplay.MoveUp.canceled += ctx => move = Vector2.zero;
        controls.Gameplay.MoveRight.performed += ctx => move = ctx.ReadValue<Vector2>();
        controls.Gameplay.MoveRight.canceled += ctx => move = Vector2.zero;
        controls.Gameplay.MoveDown.performed += ctx => move = ctx.ReadValue<Vector2>();
        controls.Gameplay.MoveDown.canceled += ctx => move = Vector2.zero;
        controls.Gameplay.MoveLeft.performed += ctx => move = ctx.ReadValue<Vector2>();
        controls.Gameplay.MoveLeft.canceled += ctx => move = Vector2.zero;*/
    }

    private void Update()
    {
        Vector2 m = new Vector2(move.x, move.y) * Time.deltaTime;
        transform.Translate(m, Space.World);
    }
}

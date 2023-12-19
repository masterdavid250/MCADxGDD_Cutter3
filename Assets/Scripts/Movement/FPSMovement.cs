using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class FPSMovement : MonoBehaviour
{
    public float movementSpeed = 5f;
    public float deadzoneThreshold = 0.5f;

    private Rigidbody rb;

    private void Awake()
    {
        JoystickMasterScript.instance.PlayerSetup(this.gameObject.transform, this.GetComponentInChildren<Camera>()); 
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    void FixedUpdate()
    {
        float horizontalMovement = Input.GetAxis("Horizontal");
        float verticalMovement = Input.GetAxis("Vertical");

        if (Mathf.Abs(horizontalMovement) < deadzoneThreshold)
            horizontalMovement = 0f;

        if (Mathf.Abs(verticalMovement) < deadzoneThreshold)
            verticalMovement = 0f;

        Vector3 moveDirection = new Vector3(horizontalMovement, 0f, verticalMovement).normalized;

        rb.MovePosition(rb.position + transform.TransformDirection(moveDirection) * movementSpeed * Time.fixedDeltaTime);

        if (moveDirection != Vector3.zero)
        {
            SoundManager.instance.PlayFootstepSound();
        }

        Vector3 currentRotation = transform.rotation.eulerAngles;
        transform.rotation = Quaternion.Euler(0f, currentRotation.y, 0f);
    }
}

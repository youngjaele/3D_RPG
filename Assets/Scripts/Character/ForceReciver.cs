using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceReciver : MonoBehaviour
{
    [SerializeField] private CharacterController controller;
    [SerializeField] private float drag = 0.3f;

    private Vector3 dampingVelocity;
    private Vector3 impact;
    private float vericalVelocity;

    public Vector3 Movement => impact + Vector3.up * vericalVelocity;

    void Update()
    {
        if (vericalVelocity < 0.0f && controller.isGrounded)
        {
            vericalVelocity = Physics.gravity.y * Time.deltaTime;
        }
        else
        {
            vericalVelocity += Physics.gravity.y * Time.deltaTime;
        }

        impact = Vector3.SmoothDamp(impact, Vector3.zero, ref dampingVelocity, drag);
    }

    public void Reset()
    {
        impact = Vector3.zero;
        vericalVelocity = 0.0f;
    }

    public void AddForce(Vector3 force)
    {
        impact += force;
    }

    public void Jump(float jumpForce)
    {
        vericalVelocity += jumpForce;
    }
}

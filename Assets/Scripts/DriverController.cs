using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
[RequireComponent(typeof(Rigidbody), typeof(BoxCollider))]

public class DriverController : MonoBehaviour
{
    [SerializeField]
    private Rigidbody rb;
    [SerializeField]
    private FixedJoystick joyStick;
    [SerializeField]
    private float altitude;

    private void FixedUpdate()
    {
        rb.velocity = new Vector3(rb.velocity.x, joyStick.Vertical * altitude, rb.velocity.z);
    }
}

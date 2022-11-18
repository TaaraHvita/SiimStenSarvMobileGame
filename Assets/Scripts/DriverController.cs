using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody), typeof(BoxCollider))]

public class DriverController : MonoBehaviour
{
    [SerializeField]
    private Rigidbody rb;
    [SerializeField]
    private Joystick joyStick;
    [SerializeField]
    private float altitude;

    

    private void FixedUpdate()
    {
        rb.velocity = new Vector3(rb.velocity.x, joyStick.Vertical * altitude, rb.velocity.z);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Car")
        {
            Destroy(gameObject); //destroys player car
            Debug.Log("Crashed.");
            FindObjectOfType<DrivingLevelController>().EndGame();
            
        }
    }
}

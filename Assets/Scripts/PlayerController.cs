using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(Rigidbody), typeof(BoxCollider))]
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private Rigidbody rb;
    [SerializeField]
    private FixedJoystick joyStick;
    [SerializeField]
    private Animator animator;
    [SerializeField] 
    private float moveSpeed;

    private void Start()
    {
        animator = GetComponent<Animator>();
        Debug.Log(animator);
        
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector3(joyStick.Horizontal * moveSpeed, rb.velocity.y, joyStick.Vertical * moveSpeed);

        if (joyStick.Horizontal != 0 || joyStick.Vertical != 0)
        {
            transform.rotation = Quaternion.LookRotation(rb.velocity);
            animator.SetBool("isRunning", true);
            animator.SetBool("idle", false);
        }
        else
        {
            animator.SetBool("isRunning", false);
            animator.SetBool("idle", true);
        }
    }

    public void Attack()
    {
        Debug.Log("Attack");
        animator.SetTrigger("isShooting");
    }
}

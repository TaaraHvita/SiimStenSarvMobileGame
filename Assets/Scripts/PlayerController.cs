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
    private Joystick joyStick;
    [SerializeField]
    private Animator animator;
    [SerializeField] 
    private float moveSpeed;

    public GameObject GameOverMenu;
    public float health;
    public Slider HealthBar;

    private void Awake()
    {
        Time.timeScale = 1f;
    }
    private void Start()
    {
        HealthBar.value = health;
        animator = GetComponent<Animator>();
        Debug.Log(animator);
        
    }

    private void Update()
    {
        if(health == 0)
        {
            Die();
        }
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
        animator.SetTrigger("isShooting");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer.Equals(11))
        {
            health -= 10;
            HealthBar.value = health;
        }
    }

    void Die()
    {
        Debug.Log("You're dead");
        Destroy(gameObject);
        Time.timeScale = 0f;
        EnableGameOverMenu();
        
    }

    public void EnableGameOverMenu()
    {
        GameOverMenu.SetActive(true);
    }

    public void Heal(float amount)
    {
        health += amount;
        HealthBar.value = health;
    }
}

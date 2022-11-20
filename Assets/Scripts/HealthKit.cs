using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthKit : MonoBehaviour
{
    [SerializeField] private Vector3 _rotation;
    public float amount = 50;
    void Update()
    {
        transform.Rotate(_rotation * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerController health = other.GetComponent<PlayerController>();
        if (health)
        {
            health.Heal(amount);
            Destroy(gameObject);
        }
    }
}

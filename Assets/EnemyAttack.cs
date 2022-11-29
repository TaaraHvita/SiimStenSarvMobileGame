using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public GameObject hitEffect;
    public float Deletebullet = 2;


    void Awake()
    {
        Destroy(gameObject, Deletebullet);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<PlayerController>(out PlayerController player))
        {
            player.TakeDamage();
        }
    }
}

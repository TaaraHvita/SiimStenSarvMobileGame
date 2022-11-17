using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public GameObject hitEffect;
    public float Deletebullet = 2;
    public int EnemyDamage;

    void Awake()
    {
        Destroy(gameObject, Deletebullet);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.TryGetComponent<EnemyController>(out EnemyController enemyComponent))
        {
            enemyComponent.TakeDamage(1);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float Deletebullet = 2;
    public int EnemyDamage;

    void Awake()
    {
        Destroy(gameObject, Deletebullet);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Enemy")
        {

            Destroy(collision.gameObject);

            gameObject.SetActive(false);
            
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public Vector3 hitPoint;
    public float Deletebullet;
    public int bulletSpeed;

    void Start()
    {
        this.GetComponent<Rigidbody>().AddForce((hitPoint - this.transform.position).normalized * bulletSpeed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
            Destroy(this.gameObject);
            
        }
        else
        {
            Destroy(this.gameObject);
        }

        Destroy(this.gameObject);
    }
}

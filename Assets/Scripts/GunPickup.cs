using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GunPickup : MonoBehaviour
{
    public GameObject gun;
    public Transform player, gunContainer;
    PlayerController PlayerController;
    [SerializeField] private Vector3 _rotation;
    public int bulletInventory;

    void Update()
    {
        transform.Rotate(_rotation * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            
            GetGun();
            GameObject gunPrefab = Instantiate(gun, gunContainer);
            gunPrefab.transform.parent = GameObject.Find("Gun Container").transform;
            Destroy(this.gameObject);
        }
    }

    public void GetGun()
    {
        Debug.Log("Weapon GET!");

    }
}

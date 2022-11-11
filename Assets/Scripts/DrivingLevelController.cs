using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrivingLevelController : MonoBehaviour
{
    public float speed = 2;
    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using TMPro;

public class GunScript : MonoBehaviour
{
    public float shootForce, upwardForce, timeBetweenShooting, spread, range, reloadTime, timeBetweenShots;
    public int magazineSize, bulletsPerTap;
    public bool allowButtonHold;
    int bulletsLeft, bulletsShot;

    bool shooting, readyToShoot, reloading;

    public Transform attackPoint;
    private Ray ray;
    public RaycastHit rayHit;
    public GameObject bullet;
    public ParticleSystem muzzleFlash;
    public TextMeshProUGUI text;

    [SerializeField] LayerMask layermask;
    public AudioSource gunshotaudio;

    public bool allowInvoke = true;


    private void Awake()
    {
        //make sure magazine size is full
        bulletsLeft = magazineSize;
        readyToShoot = true;
    }

    private void Update()
    {
        Debug.DrawRay(transform.position, transform.up * 50f, Color.red);
        
        if (text != null)
            text.SetText(bulletsLeft / bulletsPerTap + " / " + magazineSize / bulletsPerTap);
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.up), out RaycastHit hitinfo, 20f, layermask))
        {
            
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.up) * hitinfo.distance, Color.green);
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.up) * 20f, Color.yellow);

        }

        if (reloading)
        {
            return;
        }

        if (bulletsLeft <= 0)
        {
            StartCoroutine(Reload());
            readyToShoot = false;
        }

    }

    public void ShootBullet()
    {
        if(bulletsLeft != 0)
        {
            Shoot();
        }
        
    }

    public void WeaponReload()
    {
        StartCoroutine(Reload());
    }

    void Shoot()
    {
        readyToShoot = false;

        Ray ray = new Ray(transform.position, transform.TransformDirection(Vector3.up));
        RaycastHit hit;

        Vector3 targetPoint;
        if (Physics.Raycast(ray, out hit))
            targetPoint = hit.point;
        else
            targetPoint = ray.GetPoint(75);

        //Calculate direction from attackPoint to targetPoint
        Vector3 directionWithoutSpread = targetPoint - attackPoint.position;

        //Calculate spread
        float x = Random.Range(-spread, spread);
        float y = Random.Range(-spread, spread);

        //Calculate new direction with spread
        Vector3 directionWithSpread = directionWithoutSpread + new Vector3(x, y, 0);

        //Instantiate bullet/projectile
        GameObject currentBullet = Instantiate(bullet, attackPoint.position, Quaternion.identity);
        //Rotate bullet to shoot direction
        currentBullet.transform.forward = directionWithSpread.normalized;

        //Add forces to bullet
        currentBullet.GetComponent<Rigidbody>().AddForce(directionWithSpread.normalized * shootForce, ForceMode.Impulse);
        currentBullet.GetComponent<Rigidbody>().AddForce(attackPoint.transform.up * upwardForce, ForceMode.Impulse);
        //create muzzleflash
        muzzleFlash.Play();
        //create audio
        gunshotaudio.Play();

        bulletsLeft--;
        bulletsShot++;

        //Invoke resetShot function (if not already invoked), with your timeBetweenShooting
        if (allowInvoke)
        {
            Invoke("ResetShot", timeBetweenShooting);
            allowInvoke = false;
        }
        //if more than one bulletsPerTap make sure to repeat shoot function
        if (bulletsShot < bulletsPerTap && bulletsLeft > 0)
            Invoke("Shoot", timeBetweenShots);

    }

    private void ResetShot()
    {
        //Allow shooting and invoking again
        readyToShoot = true;
        allowInvoke = true;
    }

    IEnumerator Reload()
    {
        reloading = true;
        Debug.Log("Reloading...");
        yield return new WaitForSeconds(reloadTime);
        Invoke("ReloadFinished", reloadTime);
    }

    private void ReloadFinished()
    {
        bulletsLeft = magazineSize;
        reloading = false;
    }
}

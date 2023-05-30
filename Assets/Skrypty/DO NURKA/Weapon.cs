using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float firerate;
    float nextfire;
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();

        }
    }
    void Shoot()
    {
        if (Time.time > nextfire)
        {
            nextfire = Time.time + firerate;
            Debug.Log(nextfire);
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            anim.Play("reloadanimation");
        }
        

    }


}

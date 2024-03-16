using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeLauncher : MonoBehaviour
{
    private const int LeftMouseButton = 0;
    [SerializeField] private Transform bulletPos;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private AudioSource shootingSound;
    //[SerializeField] private Animation animShooting;
    public float bulletSpeed;
    public Animator anim;



    private void Update()
    {
        if (Input.GetMouseButtonDown(LeftMouseButton))
        {
            ShootBullet();
        }
    }

    private void ShootBullet() => anim.SetTrigger("Shoot");
    
    public void PlayFireSound() => shootingSound.Play();

    public void AddProjectile()
    {
        GameObject bullet = Instantiate(bulletPrefab, bulletPos.position,
                                        bulletPos.rotation);
        bullet.GetComponent<Rigidbody>().velocity = -bulletPos.forward * bulletSpeed;

    }

}

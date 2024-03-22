using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.Events;

public class AutomaticShooting : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private int rpm;
    [SerializeField] private AudioSource shootSound;
    [SerializeField] private GameObject hitMarkerPrefab;
    [SerializeField] private Camera aimingCamera;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private UnityEvent onShoot; 

    private float lastShot;
    private float interval;

    private void Start() => interval = 60f / rpm;
    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            UpdateFiring();
        }
    }
    private void UpdateFiring()
    {
        if(Time.time - lastShot >= interval)
        {
            Shot();
            lastShot = Time.time;
            PerformRaycasting();
            onShoot.Invoke();
        }
    }
    private void Shot()
    {
        anim.Play("Shot", layer: -1, normalizedTime: 0);
        shootSound.Play();
    }

    private void PerformRaycasting()
    {
        Ray aimingRay = new Ray(aimingCamera.transform.position, aimingCamera.transform.forward);
        if(Physics.Raycast(aimingRay, out RaycastHit hitInfo, 1000f, layerMask))
        {
            Quaternion effectRotation = Quaternion.LookRotation(hitInfo.normal);
            Instantiate(hitMarkerPrefab, hitInfo.point, effectRotation);
        }
    }
}

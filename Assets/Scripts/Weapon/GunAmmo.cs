using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GunAmmo : MonoBehaviour
{
    [SerializeField] private int magSize;
    public GrenadeLauncher gun;
    public Animator anim;
    public UnityEvent loadedAmmoChanged;
    public AudioSource[] reloadSound;
    private int _loadedAmmo;
    public int LoadedAmmo
    {
        get => _loadedAmmo;
        set
        {
            _loadedAmmo = value;
            loadedAmmoChanged.Invoke();
            if (_loadedAmmo <= 0)
            {
                Reload();
            }
            else
            {
                UnlockShooting();
            }
        }
    }
    private void Start() => RefillAmmo();
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Reload();
        }
    }
    private void Reload()
    {
        anim.SetTrigger("Reload");
        RefillAmmo();
        LockShooting();
        UnlockShooting();
    }
    public void AddAmmo()
    {
        RefillAmmo();
    }  
    public void SingleFireAmmoCounter() => LoadedAmmo--;
    private void LockShooting() => gun.enabled = false;
    private void UnlockShooting() => gun.enabled = true;
    private void RefillAmmo() => LoadedAmmo = magSize;
    //public void OnGunSelected() => UpdateShootingLock();
    //private void UpdateShootingLock() => gun.enabled = _loadedAmmo > 0;
    public void PlayReloadPart1Sound() => reloadSound[0].Play();
    public void PlayReloadPart2Sound() => reloadSound[1].Play();
    public void PlayReloadPart3Sound() => reloadSound[2].Play();
    public void PlayReloadPart4Sound() => reloadSound[3].Play();
    public void PlayReloadPart5Sound() => reloadSound[4].Play();
}

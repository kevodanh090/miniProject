using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AmmoTextBinder : MonoBehaviour
{
    public TMP_Text loadedAmmoText;
    public GunAmmo gunAmmo;

    private void Start()
    {
        gunAmmo.loadedAmmoChanged.AddListener(UpdateGunAmmo);
        UpdateGunAmmo();

    }

    public void UpdateGunAmmo() => loadedAmmoText.text = gunAmmo.LoadedAmmo.ToString();
}

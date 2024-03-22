using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunMuzzle : MonoBehaviour
{
    [SerializeField] private Transform muzzleImage;
    public float duration;
    private void Start() => HideMuzzle();

    public void ShowMuzzle()
    {
        muzzleImage.gameObject.SetActive(true);
        float angle = Random.Range(0f, 360f);
        muzzleImage.localEulerAngles = new Vector3(0,0,angle);
        CancelInvoke();
        Invoke(nameof(HideMuzzle), duration);
    }

    public void HideMuzzle() => muzzleImage.gameObject.SetActive(false);
}

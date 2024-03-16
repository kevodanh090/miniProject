using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateByMouse : MonoBehaviour
{
    [SerializeField] private Transform cameraHolder;
    public float angleRotate;
    public float minPitch;
    public float maxPitch;


    private float pitch;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    private void Update()
    {
        updateYaw();
        updatePitch();
    }

    private void updateYaw()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float yaw = mouseX * angleRotate * Time.deltaTime;
        transform.Rotate(0, yaw, 0);
    }
    private void updatePitch()
    {
        float mouseY = Input.GetAxis("Mouse Y");
        float deltaPitch = -mouseY * angleRotate * Time.deltaTime;
        pitch = Mathf.Clamp(pitch + deltaPitch, minPitch, maxPitch);
        cameraHolder.localEulerAngles = new Vector3(pitch, 0, 0);
        
    } 
}

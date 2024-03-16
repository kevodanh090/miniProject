using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyExplosion : MonoBehaviour
{
    private int leftTime = 5;

    public void Start()
    {
        Destroy(gameObject, leftTime);
    }
}

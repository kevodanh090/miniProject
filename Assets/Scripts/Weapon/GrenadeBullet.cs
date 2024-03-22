using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeBullet : MonoBehaviour
{
    [SerializeField] private GameObject explosionPrefab;
    [SerializeField] private float explosionRadius;
    [SerializeField] private float explosionForce;
    
    public void OnCollisionEnter(Collision collision)
    {
        Instantiate(explosionPrefab, transform.position, transform.rotation);
        Destroy(gameObject);
    }
    private void BlowObject()
    {
        Collider[] effectedObject = Physics.OverlapSphere(transform.position, explosionRadius);
        for( int i = 0; i < effectedObject.Length; i++ )
        {
            Rigidbody rigidbody = effectedObject[i].attachedRigidbody;
            if (rigidbody)
            {
                rigidbody.AddExplosionForce(explosionForce,transform.position, explosionRadius,1,ForceMode.Impulse);
            }
        }
    }
}

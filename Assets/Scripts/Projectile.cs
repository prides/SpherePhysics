using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour
{
    private Rigidbody mRigidbody;

    public float fireForce = 250.0f;

    private void Awake()
    {
        mRigidbody = GetComponent<Rigidbody>();
        if (null == mRigidbody)
        {
            Debug.LogError(this.gameObject.name + ": don't have a Rigidbody");
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            mRigidbody.AddForce(Vector3.up * fireForce);
        }
    }
}

using UnityEngine;
using System.Collections;

public class SimpleGravityBody : MonoBehaviour
{
    private Rigidbody mRigidbody;
    private Transform mTransform;

    private void Awake()
    {
        mRigidbody = GetComponent<Rigidbody>();
        if (null == mRigidbody)
        {
            Debug.LogError(this.gameObject.name + ": don't have a Rigidbody");
        }
        mTransform = GetComponent<Transform>();

        if (null != mRigidbody)
        {
            mRigidbody.useGravity = false;
        }
    }

    public Rigidbody getRigidbody()
    {
        return mRigidbody;
    }

    public Transform getTransform()
    {
        return mTransform;
    }
}

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SimpleGravityPoint : MonoBehaviour
{
    public float gravity = -9.8f;
    public List<SimpleGravityBody> gravityBody = new List<SimpleGravityBody>();

    private void Awake()
    {
        gravityBody.AddRange(FindObjectsOfType<SimpleGravityBody>());
    }

    public void AddGravityBody(SimpleGravityBody body)
    {
        gravityBody.Add(body);
    }

    private void Update()
    {
        if (gravityBody.Count > 0)
        {
            Vector3 gravityUp;
            Vector3 bodyUp;
            Transform bodyTrans;
            Rigidbody bodyRigid;
            Quaternion targetRotation;
            foreach (SimpleGravityBody gravbod in gravityBody)
            {
                if (null == gravbod)
                {
                    continue;
                }

                bodyTrans = gravbod.getTransform();
                bodyRigid = gravbod.getRigidbody();
                gravityUp = (bodyTrans.position - transform.position).normalized;
                bodyUp = bodyTrans.up;

                bodyRigid.AddForce(gravityUp * gravity);

                targetRotation = Quaternion.FromToRotation(bodyUp, gravityUp) * bodyTrans.rotation;
                bodyTrans.rotation = Quaternion.Slerp(bodyTrans.rotation, targetRotation, 50 * Time.deltaTime);
            }
        }
    }
}

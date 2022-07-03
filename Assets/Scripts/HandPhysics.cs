using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandPhysics : MonoBehaviour
{
    public Transform target;
    private Rigidbody rb;
    private Collider[] handColliders;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        handColliders = GetComponentsInChildren<Collider>();
    }

    public void ToggleHandColliderCaller(bool enable)
    {
        float delay = 0f;

        if(enable)
            delay = 0.4f;

        StartCoroutine(ToggleHandCollider(enable, delay));
    }

    public IEnumerator ToggleHandCollider(bool enable, float delayInSeconds)
    {
        if(delayInSeconds > 0)
            yield return new WaitForSeconds(delayInSeconds);

        foreach (Collider collider in handColliders)
        {
            collider.enabled = enable;
        }
    }

    void FixedUpdate()
    {
        rb.velocity = (target.position - transform.position)/Time.fixedDeltaTime;
        Quaternion rotationDifference = target.rotation * Quaternion.Inverse(transform.rotation);
        rotationDifference.ToAngleAxis(out float angleInDegree, out Vector3 rotationAxis);

        Vector3 rotationDifferenceInDegrees = angleInDegree * rotationAxis;

        rb.angularVelocity = (rotationDifferenceInDegrees * Mathf.Deg2Rad / Time.fixedDeltaTime);
    }
}

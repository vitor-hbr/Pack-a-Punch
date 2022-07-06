using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandPhysics : MonoBehaviour
{
    public Transform target;
    private Rigidbody rb;
    private Collider[] handColliders;
    [SerializeField] float extraForceOnVelocity = 5;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        handColliders = GetComponentsInChildren<Collider>();
    }

    public void ToggleHandColliderCaller(bool enable)
    {
        float delay = 0f;

        if(enable)
            delay = 0.7f;

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

    private void OnCollisionEnter(Collision collision)
    {
        Rigidbody collidedBody = collision.gameObject.GetComponentInChildren<Rigidbody>();
        
        if (collision == null || collidedBody == null)
            return;

        Vector3 averagePoint = Vector3.zero;
        foreach(ContactPoint p in collision.contacts)
        {
            averagePoint += p.point;
        }

        averagePoint /= collision.contacts.Length;

        Vector3 direction = (averagePoint - transform.position).normalized;

        StartCoroutine(applyDelayedForce(collidedBody, direction* Mathf.Pow(rb.velocity.magnitude, extraForceOnVelocity)));
    }

    IEnumerator applyDelayedForce(Rigidbody body, Vector3 directionWithForce)
    {
        yield return new WaitForSeconds(0.05f);
        body.AddForce(directionWithForce);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] float distance = 500f;
    [SerializeField] Material OriginalMaterial;
    [SerializeField] Material FrozenMaterial;
    private bool isFrozen;
    private Vector3 initialPosition;
    private Rigidbody rb;
    private MeshRenderer meshRenderer;

    public void toggleFreeze()
    {
        isFrozen = !isFrozen;
        if (!isFrozen)
        {
            rb.constraints = RigidbodyConstraints.None;
            meshRenderer.material = OriginalMaterial;
        }
        else
        {
            rb.constraints = RigidbodyConstraints.FreezeAll;
            meshRenderer.material = FrozenMaterial;
        }
    }
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        meshRenderer = GetComponent<MeshRenderer>();
        initialPosition = transform.localPosition;
    }
    void Update()
    {
        if (Vector3.Distance(transform.localPosition, initialPosition) > distance)
            Object.Destroy(transform.gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (isFrozen)
            toggleFreeze();
    }
}

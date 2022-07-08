using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] float distance = 500f;
    [SerializeField] Material OriginalMaterial;
    [SerializeField] Material FrozenMaterial;
    private SoundController freezeSound;
    private SoundController hitSound;
    private bool isFrozen;
    private Vector3 initialPosition;
    private Rigidbody rb;
    private MeshRenderer meshRenderer;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        meshRenderer = GetComponent<MeshRenderer>();
        hitSound = GetComponent<SoundController>();
        freezeSound = transform.parent.gameObject.GetComponent<SoundController>();
        initialPosition = transform.localPosition;
    }
    void Update()
    {
        if (Vector3.Distance(transform.localPosition, initialPosition) > distance)
            Object.Destroy(transform.gameObject);
    }
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
            freezeSound.play();
            rb.constraints = RigidbodyConstraints.FreezeAll;
            meshRenderer.material = FrozenMaterial;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        hitSound.play();
        if (isFrozen)
            toggleFreeze();
    }
}

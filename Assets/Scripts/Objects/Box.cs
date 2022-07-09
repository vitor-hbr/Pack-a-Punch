using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    [SerializeField] GameObject explosionPrefab;
    [SerializeField] float timeInSecondsRemoveExplosion = 1.5f;
    private GameObject explosionObject;
    ParticleSystem ps;
    MeshRenderer meshRenderer;

    public delegate void RemovedBox();
    public static event RemovedBox onRemoveBox;

    private void Start()
    {
        explosionObject = Object.Instantiate(explosionPrefab, transform.position, transform.rotation);
        ps = explosionObject.GetComponent<ParticleSystem>();
        meshRenderer = GetComponent<MeshRenderer>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (onRemoveBox != null)
            onRemoveBox();

        ps.Play();
        meshRenderer.enabled = false;
        GetComponent<Rigidbody>().detectCollisions = false;
        Object.Destroy(explosionObject, timeInSecondsRemoveExplosion);
        Object.Destroy(transform.gameObject, timeInSecondsRemoveExplosion);
    }
}

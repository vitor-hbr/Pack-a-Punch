using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    [SerializeField] GameObject explosionPrefab;
    [SerializeField] int timeInSecondsRemoveExplosion = 1;
    private GameObject explosionObject;
    ParticleSystem ps;

    public delegate void RemovedBox();
    public static event RemovedBox onRemoveBox;

    private void Start()
    {
        explosionObject = Object.Instantiate(explosionPrefab, transform.position, transform.rotation);
        ps = explosionObject.GetComponent<ParticleSystem>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (onRemoveBox != null)
            onRemoveBox();

        ps.Play();
        Object.Destroy(transform.gameObject);
        StartCoroutine(destroyExplosionObject());
    }

    private IEnumerator destroyExplosionObject()
    {
        yield return new WaitForSeconds(timeInSecondsRemoveExplosion);
        Object.Destroy(explosionObject);
    }
}

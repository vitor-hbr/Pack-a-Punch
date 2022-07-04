using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] float destroyHeight = -50f;
    void Update()
    {
        if (transform.localPosition.y < destroyHeight)
            Object.Destroy(transform.gameObject);
    }
}

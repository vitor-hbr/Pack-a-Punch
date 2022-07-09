using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour
{
    [SerializeField] float rotationSpeed = Mathf.PI / 80;
    void Update()
    {
        transform.Rotate(0, rotationSpeed, 0);
    }
}

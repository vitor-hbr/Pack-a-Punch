using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallGenerator : MonoBehaviour
{
    [SerializeField] GameObject BallPrefab;
    [SerializeField] int MaxNumberOfBalls;
    [SerializeField] float force;
    [SerializeField] Vector3 direction;

    public void generateBall()
    {
        if(transform.childCount > MaxNumberOfBalls)
        {
            Object.Destroy(transform.GetChild(0).gameObject);
        }
        GameObject newBall = Object.Instantiate(BallPrefab, transform);
        newBall.GetComponent<Rigidbody>().AddForce(direction * force);
    }

}

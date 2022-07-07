using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxGenerator : MonoBehaviour
{
    [SerializeField] int maxNumberOfBoxes = 5;
    [SerializeField] float maxDistance = 8;
    [SerializeField] float minDistance = 4;
    public GameObject BoxPrefab;

    private void OnEnable()
    {
        Box.onRemoveBox += buildNewBox;
    }

    private void OnDisable()
    {
        Box.onRemoveBox -= buildNewBox;
    }

    void Start()
    {
        for (int iterator = 0; iterator < maxNumberOfBoxes; iterator++)
        {
            buildNewBox();
        }
    }

    public void buildNewBox()
    {
        Vector3 randomPosition = new Vector3(
                Random.Range(minDistance, maxDistance) * randomSign(),
                Random.Range(minDistance, maxDistance),
                Random.Range(minDistance, maxDistance) * randomSign()
            );

        GameObject newBox = Object.Instantiate(BoxPrefab, randomPosition, Quaternion.identity);
        newBox.transform.localScale.Set(1, 1, 1);
        newBox.transform.LookAt(Vector3.zero);
    }

    private float randomSign()
    {
        return (float) Random.Range(0, 2) * 2 - 1;
    }
}

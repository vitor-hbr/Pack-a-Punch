using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnablePage : MonoBehaviour
{
    private GameObject[] pages;

    private void Start()
    {
        int childrenNumber = transform.childCount;
        pages = new GameObject[childrenNumber];
        for (int i = 0; i < childrenNumber; ++i)
           pages[i] = transform.GetChild(i).gameObject;
    }

    public void activatePage(int pageIndex)
    {
        for (int i = 0; i < pages.Length; i++)
        {
            if(i == pageIndex)
                pages[i].SetActive(true);
            else
                pages[i].SetActive(false);
        }
    }
}

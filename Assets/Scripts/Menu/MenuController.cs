using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    [SerializeField] GameObject menuGO;
    private bool isShowing = false;

    public void toggleMenu()
    {
        isShowing = !isShowing;
        menuGO.SetActive(isShowing);
    }
}

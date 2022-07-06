using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class CharacterMoverHelper : MonoBehaviour
{
    private XROrigin xrOrigin;
    private CharacterController characterController;
    private CharacterControllerDriver driver;
    protected virtual void UpdateCharacterController()
    {
        if (xrOrigin == null || characterController == null)
            return;

        var height = Mathf.Clamp(xrOrigin.CameraInOriginSpaceHeight, driver.minHeight, driver.maxHeight);

        Vector3 center = xrOrigin.CameraInOriginSpacePos;
        center.y = height / 2f + characterController.skinWidth;

        characterController.height = height;
        characterController.center = center;
    }

    private void Start()
    {
        xrOrigin = GetComponent<XROrigin>();
        characterController = GetComponent<CharacterController>();
        driver = GetComponent<CharacterControllerDriver>();

    }

    // Update is called once per frame
    void Update()
    {
        UpdateCharacterController();
    }
}

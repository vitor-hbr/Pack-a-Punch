using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class HandPresence : MonoBehaviour
{
    public InputDeviceCharacteristics controllerCharacteristics;    
    public Animator handAnimator;
    private InputDevice targetDevice;
    private XRDirectInteractor xrDirectInteractor;

    void Start()
    {
        TryInitialize();
        xrDirectInteractor = gameObject.GetComponentInParent<XRDirectInteractor>();
    }

    void TryInitialize()
    {
        List<InputDevice> devices = new List<InputDevice>();

        InputDevices.GetDevicesWithCharacteristics(controllerCharacteristics, devices);
        if (devices.Count > 0)
        {
            targetDevice = devices[0];
        }
    }

    void UpdateHandAnimation()
    {
        if(targetDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue))
        {
            handAnimator.SetFloat("Trigger", triggerValue);
        }
        else
        {
            handAnimator.SetFloat("Trigger", 0);
        }

        if (targetDevice.TryGetFeatureValue(CommonUsages.grip, out float gripValue))
        {
            if (gripValue > 0.85)
            {
                StartCoroutine(checkIfSelecting());
            }
            else
            {
                xrDirectInteractor.allowSelect = true;
            }
            handAnimator.SetFloat("Grip", gripValue);
        }
        else
        {
            handAnimator.SetFloat("Grip", 0);
        }
    }

    IEnumerator checkIfSelecting()
    {
        yield return new WaitForSeconds(0.5f);
        if (!xrDirectInteractor.hasSelection && !xrDirectInteractor.hasHover)
        {
            xrDirectInteractor.allowSelect = false;
        }
    }
    void Update()
    {
        if(!targetDevice.isValid)
        {
            TryInitialize();
        }
        else
        {
            UpdateHandAnimation();
        }
    }
}

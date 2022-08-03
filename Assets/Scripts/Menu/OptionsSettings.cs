using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsSettings : MonoBehaviour
{
    public enum MovementEnum {
        continuous,
        teleport
    }
    public enum TurningEnum
    {
        smooth,
        snap
    }

    [SerializeField] GameObject continuousToggleGO;
    Toggle continuousToggle;
    [SerializeField] GameObject TeleportToggleGO;
    Toggle TeleportToggle;
    [SerializeField] GameObject SmoothToggleGO;
    Toggle SmoothToggle;
    [SerializeField] GameObject SnapToggleGO;
    Toggle SnapToggle;

    [SerializeField] GameObject turningAmountGO;
    Slider turningAmountSlider;
    [SerializeField] GameObject volumeSFXGO;
    Slider volumeSFXSlider;
    [SerializeField] GameObject volumeMusicGO;
    Slider volumeMusicSlider;


    MovementEnum movement = MovementEnum.continuous;
    TurningEnum turning = TurningEnum.smooth;
    float turningAmount = 50f;
    float volumeSFX = 0.25f;
    float volumeMusic = 0.18f;

    private void Start()
    {
        continuousToggle = continuousToggleGO.GetComponent<Toggle>();
        continuousToggle.isOn = movement == MovementEnum.continuous;

        TeleportToggle = TeleportToggleGO.GetComponent<Toggle>();
        TeleportToggle.isOn = movement == MovementEnum.teleport;

        SmoothToggle = SmoothToggleGO.GetComponent<Toggle>();
        SmoothToggle.isOn = turning == TurningEnum.smooth;

        SnapToggle = SnapToggleGO.GetComponent<Toggle>();
        SnapToggle.isOn = turning == TurningEnum.snap;

        turningAmountSlider = turningAmountGO.GetComponent<Slider>();
        turningAmountSlider.value = turningAmount;

        volumeSFXSlider = volumeSFXGO.GetComponent<Slider>();
        volumeSFXSlider.value = volumeSFX;

        volumeMusicSlider = volumeMusicGO.GetComponent<Slider>();
        volumeMusicSlider.value = volumeMusic;
    }

    public void setMovementcontinuous(bool value)
    {
        continuousToggle.isOn = value;
        TeleportToggle.isOn = !value;
        if (value)
        {
            movement = MovementEnum.continuous;
            PlayerPrefs.SetInt("movement", (int)movement);
        }
    }
    public void setMovementTeleport(bool value)
    {
        TeleportToggle.isOn = value;
        continuousToggle.isOn = !value;
        if(value)
        {
            movement = MovementEnum.teleport;
            PlayerPrefs.SetInt("movement", (int)movement);
        }
    }
    public void setTurningSmooth(bool value)
    {
        SmoothToggle.isOn = value;
        SnapToggle.isOn = !value;
        if (value)
        {
            turning = TurningEnum.smooth;
            PlayerPrefs.SetInt("turning", (int)turning);
        }
    }
    public void setTurningSnap(bool value)
    {
        SnapToggle.isOn = value;
        SmoothToggle.isOn = !value;
        if (value)
        {
            turning = TurningEnum.snap;
            PlayerPrefs.SetInt("turning", (int)turning);
        }
    }

    public void setTurningAmount(float value)
    {
        turningAmount = value;
        PlayerPrefs.SetFloat("turningAmount", turningAmount);
    }

    public void setSFXVolume(float value)
    {
        volumeSFX = value;
        PlayerPrefs.SetFloat("volumeSFX", volumeSFX);
    }
    public void setMusicVolume(float value)
    {
        volumeMusic = value;
        PlayerPrefs.SetFloat("volumeMusic", volumeMusic);
    }

    public void loadSettings()
    {
       turningAmount = PlayerPrefs.GetFloat("turningAmount", turningAmount);
       volumeSFX = PlayerPrefs.GetFloat("volumeSFX", volumeSFX);
       volumeMusic = PlayerPrefs.GetFloat("volumeMusic", volumeMusic);
       movement = (MovementEnum) PlayerPrefs.GetInt("movement", (int) movement);
       turning = (TurningEnum) PlayerPrefs.GetInt("turning", (int) turning);
    }
}

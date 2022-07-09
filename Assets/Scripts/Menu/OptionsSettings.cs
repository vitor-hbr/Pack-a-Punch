using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsSettings : MonoBehaviour
{
    public enum MovementEnum {
        continous,
        teleport
    }
    public enum TurningEnum
    {
        smooth,
        snap
    }

    [SerializeField] GameObject ContinousToggleGO;
    Toggle ContinousToggle;
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


    MovementEnum movement = MovementEnum.continous;
    TurningEnum turning = TurningEnum.smooth;
    float turningAmount = 50f;
    float volumeSFX = 0.25f;
    float volumeMusic = 0.18f;

    private void Start()
    {
        ContinousToggle = ContinousToggleGO.GetComponent<Toggle>();
        ContinousToggle.isOn = movement == MovementEnum.continous;

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

    public void setMovementContinous(bool value)
    {
        movement = MovementEnum.continous;
        ContinousToggle.isOn = value;
        TeleportToggle.isOn = !value;
    }
    public void setMovementTeleport(bool value)
    {
        movement = MovementEnum.continous;
        TeleportToggle.isOn = value;
        ContinousToggle.isOn = !value;
    }
    public void setTurningSmooth(bool value)
    {
        turning = TurningEnum.smooth;
        SmoothToggle.isOn = value;
        SnapToggle.isOn = !value;
    }
    public void setTurningSnap(bool value)
    {
        turning = TurningEnum.snap;
        SnapToggle.isOn = value;
        SmoothToggle.isOn = !value;
    }

    public void setTurningAmount(float value)
    {
        turningAmount = value;
    }

    public void setSFXVolume(float value)
    {
        volumeSFX = value;
    }
    public void setMusicVolume(float value)
    {
        volumeMusic = value;
    }
    public void saveSettings()
    {
        PlayerPrefs.SetFloat("turningAmount", turningAmount);
        PlayerPrefs.SetFloat("volumeSFX", volumeSFX);
        PlayerPrefs.SetFloat("volumeMusic", volumeMusic);
        PlayerPrefs.SetInt("movement", (int) movement);
        PlayerPrefs.SetInt("turning", (int) turning);
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

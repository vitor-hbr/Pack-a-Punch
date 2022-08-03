using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class MenuController : MonoBehaviour
{
    [SerializeField] GameObject menuGO;
    [SerializeField] GameObject Locomotion;
    [SerializeField] GameObject leftRayInteractor;
    [SerializeField] GameObject rightRayInteractor;
    [SerializeField] GameObject musicGO;

    [SerializeField] InputActionReference toggleReference;
    TeleportationProvider teleportationProvider;
    ActionBasedContinuousMoveProvider continuousMovementProvider;
    ActionBasedContinuousTurnProvider continuousTurnProvider;
    ActionBasedSnapTurnProvider snapTurnProvider;
    AudioSource musicAudioSource;

    private bool isShowing = false;

    private void OnEnable()
    {
        toggleReference.action.started += toggleMenuRef;
    }

    private void OnDisable()
    {
        toggleReference.action.started -= toggleMenuRef;
    }

    private void Start()
    {
        teleportationProvider = Locomotion.GetComponent<TeleportationProvider>();
        continuousMovementProvider = Locomotion.GetComponent<ActionBasedContinuousMoveProvider>();
        continuousTurnProvider = Locomotion.GetComponent<ActionBasedContinuousTurnProvider>();
        snapTurnProvider = Locomotion.GetComponent<ActionBasedSnapTurnProvider>();
        musicAudioSource = musicGO.GetComponent<AudioSource>();
    }
    public void toggleMenuRef(InputAction.CallbackContext context)
    {
        toggleMenu();
    }

    public void toggleMenu()
    {
        isShowing = !isShowing;
        menuGO.SetActive(isShowing);
        toggleLocomotion(!isShowing);
        toggleRayInteractor(isShowing);
    }
    void toggleLocomotion(bool enable)
    {
        continuousMovementProvider.enabled = false;
        teleportationProvider.enabled = false;

        OptionsSettings.MovementEnum movement = (OptionsSettings.MovementEnum) PlayerPrefs.GetInt("movement");

        if (movement == OptionsSettings.MovementEnum.continuous)
        {
            continuousMovementProvider.enabled = enable;
        } else
        {
            teleportationProvider.enabled = enable;
        }
    }
    void toggleRayInteractor(bool enable)
    {
        OptionsSettings.MovementEnum movement = (OptionsSettings.MovementEnum)PlayerPrefs.GetInt("movement");

        if (movement == OptionsSettings.MovementEnum.teleport || enable)
        {
            leftRayInteractor.SetActive(true);
            rightRayInteractor.SetActive(true);
        }
        else
        {
            leftRayInteractor.SetActive(false);
            rightRayInteractor.SetActive(false);
        }
    }
    public void toggleTurning(bool smooth)
    {
        setTurningAmount();
        if (smooth)
        {
            continuousTurnProvider.enabled = true;
            snapTurnProvider.enabled = false;
        }
        else
        {
            snapTurnProvider.enabled = true;
            continuousTurnProvider.enabled = false;
        }
    }

    public void setTurningAmount()
    {
        float turningAmount = PlayerPrefs.GetFloat("turningAmount");
        continuousTurnProvider.turnSpeed = turningAmount * 1.5f;
        snapTurnProvider.turnAmount = turningAmount;
    }
    public void setVolume()
    {
        float sfxVolume = PlayerPrefs.GetFloat("volumeSFX");
        float musicVolume = PlayerPrefs.GetFloat("volumeMusic");
        musicAudioSource.volume = musicVolume;
        AudioListener.volume = sfxVolume;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static OptionsSettings;

public class ChangeScene : MonoBehaviour
{
    MovementEnum movement = MovementEnum.continous;
    TurningEnum turning = TurningEnum.smooth;
    float turningAmount = 50f;
    float volumeSFX = 0.25f;
    float volumeMusic = 0.18f;

    [SerializeField] string SceneName;
    [SerializeField] LoadSceneMode mode = LoadSceneMode.Single;
    public void changeScene()
    {
        SceneManager.LoadScene(SceneName, mode);
    }
    public void saveDefaultSettings()
    {
        turningAmount = PlayerPrefs.GetFloat("turningAmount", turningAmount);
        volumeSFX = PlayerPrefs.GetFloat("volumeSFX", volumeSFX);
        volumeMusic = PlayerPrefs.GetFloat("volumeMusic", volumeMusic);
        movement = (MovementEnum)PlayerPrefs.GetInt("movement", (int)movement);
        turning = (TurningEnum)PlayerPrefs.GetInt("turning", (int)turning);

        PlayerPrefs.SetFloat("turningAmount", turningAmount);
        PlayerPrefs.SetFloat("volumeSFX", volumeSFX);
        PlayerPrefs.SetFloat("volumeMusic", volumeMusic);
        PlayerPrefs.SetInt("movement", (int)movement);
        PlayerPrefs.SetInt("turning", (int)turning);
    }
}

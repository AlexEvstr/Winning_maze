using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField] private GameObject _soundOn;
    [SerializeField] private GameObject _soundOff;
    [SerializeField] private GameObject _effectsOn;
    [SerializeField] private GameObject _effectsOff;

    private int _isEffects;

    private void Start()
    {
        AudioListener.volume = PlayerPrefs.GetFloat("SoundStatus", 1);
        if (AudioListener.volume == 1)
        {
            TurnOnSound();
        }
        else
        {
            TurnOffSound();
        }

        _isEffects = PlayerPrefs.GetInt("Effects", 1);
        if (_isEffects == 1)
        {
            EnableEffects();
        }
        else
        {
            DisableEffects();
        }
    }

    public void PlayButton()
    {
        SceneManager.LoadScene("Game");
    }

    public void OpenPrivacyPolicy()
    {
        Application.OpenURL("https://www.google.com/?client=safari");
    }

    public void TurnOffSound()
    {
        _soundOn.SetActive(false);
        _soundOff.SetActive(true);
        AudioListener.volume = 0;
        PlayerPrefs.SetFloat("SoundStatus", 0);
    }

    public void TurnOnSound()
    {
        _soundOff.SetActive(false);
        _soundOn.SetActive(true);
        AudioListener.volume = 1;
        PlayerPrefs.SetFloat("SoundStatus", 1);
    }

    public void DisableEffects()
    {
        _effectsOn.SetActive(false);
        _effectsOff.SetActive(true);
        _isEffects = 0;
        PlayerPrefs.SetInt("Effects", _isEffects);
    }

    public void EnableEffects()
    {
        _effectsOff.SetActive(false);
        _effectsOn.SetActive(true);
        _isEffects = 1;
        PlayerPrefs.SetInt("Effects", _isEffects);
    }
}

using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField] private GameObject _soundOn;
    [SerializeField] private GameObject _soundOff;
    [SerializeField] private GameObject _effectsOn;
    [SerializeField] private GameObject _effectsOff;
    [SerializeField] private AudioClip _clickSound;
    private AudioSource _audioSource;

    public static int _isEffects;

    private void Start()
    {
        Screen.orientation = ScreenOrientation.Portrait;
        _audioSource = GetComponent<AudioSource>();
        AudioListener.volume = PlayerPrefs.GetFloat("SoundStatus", 1);
        if (AudioListener.volume == 1)
        {
            _soundOff.SetActive(false);
            _soundOn.SetActive(true);
        }
        else
        {
            _soundOn.SetActive(false);
            _soundOff.SetActive(true);
        }

        _isEffects = PlayerPrefs.GetInt("Effects", 1);
        if (_isEffects == 1)
        {
            _effectsOff.SetActive(false);
            _effectsOn.SetActive(true);
        }
        else
        {
            _effectsOn.SetActive(false);
            _effectsOff.SetActive(true);
        }
    }

    public void PlayButton()
    {
        _audioSource.PlayOneShot(_clickSound);
        StartCoroutine(WaitForSound());
    }

    private IEnumerator WaitForSound()
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("Game");
    }

    public void TurnOffSound()
    {
        _soundOn.SetActive(false);
        _soundOff.SetActive(true);
        AudioListener.volume = 0;
        PlayerPrefs.SetFloat("SoundStatus", 0);
        _audioSource.PlayOneShot(_clickSound);
    }

    public void TurnOnSound()
    {
        _soundOff.SetActive(false);
        _soundOn.SetActive(true);
        AudioListener.volume = 1;
        PlayerPrefs.SetFloat("SoundStatus", 1);
        _audioSource.PlayOneShot(_clickSound);
    }

    public void DisableEffects()
    {
        _effectsOn.SetActive(false);
        _effectsOff.SetActive(true);
        _isEffects = 0;
        PlayerPrefs.SetInt("Effects", _isEffects);
        _audioSource.PlayOneShot(_clickSound);
    }

    public void EnableEffects()
    {
        _effectsOff.SetActive(false);
        _effectsOn.SetActive(true);
        _isEffects = 1;
        PlayerPrefs.SetInt("Effects", _isEffects);
        _audioSource.PlayOneShot(_clickSound);
    }
}

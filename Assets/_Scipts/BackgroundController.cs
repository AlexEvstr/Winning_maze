using UnityEngine;
using UnityEngine.UI;

public class BackgroundController : MonoBehaviour
{
    [SerializeField] private Image _backgroundImage;
    [SerializeField] private Sprite[] _backgroundSprites;
    [SerializeField] private AudioClip _clickSound;
    private AudioSource _audioSource;
    private int _backgroundIndex;

    private void OnEnable()
    {
        _audioSource = GetComponent<AudioSource>();
        _backgroundIndex = PlayerPrefs.GetInt("ChoosenBG", 0);
        _backgroundImage.sprite = _backgroundSprites[_backgroundIndex];
    }

    public void ChangeBackground()
    {
        _backgroundIndex++;
        if (_backgroundIndex == _backgroundSprites.LongLength)
        {
            _backgroundIndex = 0;
        }
        _backgroundImage.sprite = _backgroundSprites[_backgroundIndex];
        PlayerPrefs.SetInt("ChoosenBG", _backgroundIndex);
        _audioSource.PlayOneShot(_clickSound);
    }
}
using UnityEngine;

public class GameSounds : MonoBehaviour
{
    private AudioSource _audioSource;
    [SerializeField] private AudioClip _click;
    [SerializeField] private AudioClip _star;
    [SerializeField] private AudioClip _win;
    [SerializeField] private AudioClip _firework;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void PlayClick()
    {
        _audioSource.PlayOneShot(_click);
    }

    public void PlayStar()
    {
        _audioSource.PlayOneShot(_star);
    }

    public void PlayWin()
    {
        _audioSource.PlayOneShot(_win);
    }

    public void PlayFirework()
    {
        _audioSource.PlayOneShot(_firework);
    }
}
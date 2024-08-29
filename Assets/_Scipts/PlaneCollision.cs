using UnityEngine;

public class PlaneCollision : MonoBehaviour
{
    [SerializeField] private LevelCounter _levelCounter;
    [SerializeField] private GameObject _pickupStarEffect;
    [SerializeField] private GameSounds _gameSounds;
    
    private int _isEffects;

    private int _starsCount;

    private void Start()
    {
        _isEffects = PlayerPrefs.GetInt("Effects", 1);
        _starsCount = 0;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Star"))
        {
            collision.gameObject.SetActive(false);
            _starsCount++;
            _gameSounds.PlayStar();

            if (_isEffects == 1)
            {
                GameObject starEffect = Instantiate(_pickupStarEffect);
                starEffect.transform.position = collision.gameObject.transform.position;
                Destroy(starEffect, 2);
            }


            if (_starsCount == 3)
            {
                _levelCounter.UnlockFinish();
                _starsCount = 0;
            }
        }
        else if (collision.gameObject.CompareTag("Finish"))
        {
            _levelCounter.IncreaseLevel();
        }
    }
}
using UnityEngine;

public class PlaneCollision : MonoBehaviour
{
    [SerializeField] private LevelCounter _levelCounter;
    private int _starsCount;

    private void Start()
    {
        _starsCount = 0;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Star"))
        {
            collision.gameObject.SetActive(false);
            _starsCount++;
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
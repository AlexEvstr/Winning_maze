using UnityEngine;

public class PlaneCollision : MonoBehaviour
{
    [SerializeField] private LevelCounter _levelCounter;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Star"))
        {
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("Finish"))
        {
            _levelCounter.IncreaseLevel();
        }
    }
}
using UnityEngine;

public class BallControl : MonoBehaviour
{
    public float bounceForce = 10f;
    public float unstuckThreshold = 0.1f;
    public float unstuckForce = 5f;
    [SerializeField] private AudioClip _ballSound;
    [SerializeField] private AudioSource _audioSource;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (rb.velocity.magnitude < unstuckThreshold && MenuController._isEffects == 1)
        {
            Vector2 randomDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
            rb.AddForce(randomDirection * unstuckForce, ForceMode2D.Impulse);
            _audioSource.PlayOneShot(_ballSound);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (rb.velocity.y <= 0 && MenuController._isEffects == 1)
        {
            Vector2 bounceDirection = new Vector2(rb.velocity.x, 1f).normalized;

            rb.velocity = new Vector2(rb.velocity.x, 0);
            rb.AddForce(bounceDirection * bounceForce, ForceMode2D.Impulse);

            _audioSource.PlayOneShot(_ballSound);
        }
    }
}
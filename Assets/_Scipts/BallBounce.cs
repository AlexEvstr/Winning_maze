using UnityEngine;

public class BallControl : MonoBehaviour
{
    public float bounceForce = 10f; // Сила отскока
    public float unstuckThreshold = 0.1f; // Порог скорости для определения застревания
    public float unstuckForce = 5f; // Сила для выталкивания мяча

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Проверка застревания мяча
        if (rb.velocity.magnitude < unstuckThreshold)
        {
            // Применение случайного импульса для выталкивания мяча
            Vector2 randomDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
            rb.AddForce(randomDirection * unstuckForce, ForceMode2D.Impulse);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Проверка, если мяч летит вниз (скорость по оси Y отрицательная)
        if (rb.velocity.y <= 0)
        {
            // Создаем вектор направления отскока вверх
            Vector2 bounceDirection = new Vector2(rb.velocity.x, 1f).normalized;

            // Применяем отскок, добавляя вертикальную скорость
            rb.velocity = new Vector2(rb.velocity.x, 0); // Обнуляем текущую вертикальную скорость
            rb.AddForce(bounceDirection * bounceForce, ForceMode2D.Impulse); // Применяем силу вверх
        }
    }
}

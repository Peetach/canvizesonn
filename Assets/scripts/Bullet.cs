using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    public int damage = 20;

    private void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            // Yakýn saldýrý düþmanýna hasar ver
            if (collision.TryGetComponent<MeleeEnemy>(out MeleeEnemy meleeEnemy))
            {
                meleeEnemy.TakeDamage(damage);
            }

            // Uzak saldýrý düþmanýna hasar ver
            if (collision.TryGetComponent<ArcherEnemy>(out ArcherEnemy archerEnemy))
            {
                archerEnemy.TakeDamage(damage);
            }

            Destroy(gameObject); // Mermiyi yok et
        }
    }
}

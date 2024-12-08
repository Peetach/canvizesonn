using UnityEngine;

public class MeleeEnemy : MonoBehaviour
{
    public int health = 50; // D��man�n can�
    public Transform player; // Oyuncunun Transform'u
    public float speed = 2f; // Hareket h�z�
    public float attackRange = 1.5f; // Sald�r� menzili
    public int damage = 10; // Verdi�i hasar
    public float attackCooldown = 1f; // Sald�r� bekleme s�resi
    private float attackTimer; // Sald�r� i�in geri say�m

    private void Update()
    {
        if (player == null) return;

        float distance = Vector2.Distance(transform.position, player.position);

        // Oyuncuya do�ru hareket et
        if (distance > attackRange)
        {
            Vector2 direction = (player.position - transform.position).normalized;
            transform.position += (Vector3)direction * speed * Time.deltaTime;
        }

        // Sald�r� yap
        if (distance <= attackRange && attackTimer <= 0)
        {
            Attack();
            attackTimer = attackCooldown;
        }

        attackTimer -= Time.deltaTime;
    }

    private void Attack()
    {
        if (player.TryGetComponent<PlayerHealth>(out PlayerHealth playerHealth))
        {
            playerHealth.TakeDamage(damage);
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject); // D��man �l�r
        }
    }
}

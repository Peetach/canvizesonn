using UnityEngine;

public class MeleeEnemy : MonoBehaviour
{
    public int health = 50; // Düþmanýn caný
    public Transform player; // Oyuncunun Transform'u
    public float speed = 2f; // Hareket hýzý
    public float attackRange = 1.5f; // Saldýrý menzili
    public int damage = 10; // Verdiði hasar
    public float attackCooldown = 1f; // Saldýrý bekleme süresi
    private float attackTimer; // Saldýrý için geri sayým

    private void Update()
    {
        if (player == null) return;

        float distance = Vector2.Distance(transform.position, player.position);

        // Oyuncuya doðru hareket et
        if (distance > attackRange)
        {
            Vector2 direction = (player.position - transform.position).normalized;
            transform.position += (Vector3)direction * speed * Time.deltaTime;
        }

        // Saldýrý yap
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
            Destroy(gameObject); // Düþman ölür
        }
    }
}

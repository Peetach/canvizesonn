using UnityEngine;

public class MeleeEnemy : MonoBehaviour
{
   
    public Transform player; // Oyuncunun Transform'u
    public float speed = 2f; // Hareket h�z�
    public float attackRange = 1.5f; // Sald�r� menzili
    public int damage = 10; // Verdi�i hasar
    public float attackCooldown = 1f; // Sald�r� bekleme s�resi
    private float attackTimer; // Sald�r� i�in geri say�m
    public float health = 100f; // D��man sa�l���



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
        health -= damage; // Sa�l�ktan hasar ��kar
        if (health <= 0)
        {
            Die(); // Sa�l�k 0 veya daha azsa �l
        }
    }

    void Die()
    {
        // �l�m animasyonu eklemek isterseniz buraya yazabilirsiniz
        Destroy(gameObject); // D��man� yok et
    }
}


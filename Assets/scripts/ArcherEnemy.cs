using UnityEngine;

public class ArcherEnemy : MonoBehaviour
{
    public int health = 30;
    public Transform player;
    public GameObject arrowPrefab;
    public float speed = 1.5f;
    public float attackRange = 5f;
    public float stopRange = 3f;
    public float fireRate = 2f;
    private float fireCooldown;

    private void Update()
    {
        if (player == null) return;

        float distance = Vector2.Distance(transform.position, player.position);

        // Oyuncuya doðru hareket et
        if (distance > stopRange)
        {
            Vector2 direction = (player.position - transform.position).normalized;
            transform.position += (Vector3)direction * speed * Time.deltaTime;
        }

        // Ok fýrlat
        if (distance <= attackRange && fireCooldown <= 0)
        {
            FireArrow();
            fireCooldown = fireRate;
        }

        fireCooldown -= Time.deltaTime;
    }

    private void FireArrow()
    {
        GameObject arrow = Instantiate(arrowPrefab, transform.position, Quaternion.identity);
        Arrow arrowScript = arrow.GetComponent<Arrow>();
        if (arrowScript != null)
        {
            arrowScript.SetTarget(player.position);
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}

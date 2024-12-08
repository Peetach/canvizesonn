using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5f;
    public GameObject bulletPrefab; // Prefab'imiz
    public Transform firePoint; // Merminin ��kaca�� nokta
    private Rigidbody2D rb;
    private Vector2 moveInput;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        moveInput.x = Input.GetAxis("Horizontal");
        moveInput.y = Input.GetAxis("Vertical");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    void FixedUpdate()
    {
        rb.linearVelocity = moveInput * speed;
    }

    void Shoot()
    {
        // Bullet prefab'ini olu�tur
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}

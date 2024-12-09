using System.Collections.Generic;
using UnityEngine;

public class KeyDoorSystem : MonoBehaviour
{
    // Oyuncunun topladığı anahtarlar
    private HashSet<string> collectedKeys = new HashSet<string>();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Anahtar mı toplandı?
        if (collision.gameObject.CompareTag("Key"))
        {
            string keyName = collision.gameObject.name; // Anahtar ismini al
            if (!collectedKeys.Contains(keyName))
            {
                collectedKeys.Add(keyName);
                Debug.Log(keyName + " alındı!");
                Destroy(collision.gameObject); // Anahtarı yok et
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Kapıya mı çarpıldı?
        if (collision.gameObject.CompareTag("Door"))
        {
            string doorName = collision.gameObject.name; // Kapının ismini al
            if (CanOpenDoor(doorName))
            {
                Debug.Log(doorName + " açıldı!");
                Destroy(collision.gameObject); // Kapıyı yok et
            }
            else
            {
                Debug.Log(doorName + " için doğru anahtara sahip değilsiniz!");
            }
        }
    }

    // Kapının açılabilir olup olmadığını kontrol et
    private bool CanOpenDoor(string doorName)
    {
        switch (doorName)
        {
            case "kapı1":
                return collectedKeys.Contains("key1");
            case "kapı2":
                return collectedKeys.Contains("key2");
            case "kapı3":
                return collectedKeys.Contains("key3");
            default:
                return false;
        }
    }
}
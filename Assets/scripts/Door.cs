using UnityEngine;

public class KeyAndDoor : MonoBehaviour
{
    public GameObject kap�1; // Kap�y� temsil eden GameObject
    private bool hasKey = false; // Anahtar�n al�n�p al�nmad���n� kontrol etmek i�in

    void OnTriggerEnter(Collider other)
    {
        // Anahtar al�nd���nda
        if (other.CompareTag("key1"))
        {
            hasKey = true;
            Destroy(other.gameObject); // Anahtar� yok et
            Debug.Log("Anahtar al�nd�!");
        }

        // Kap�ya ula��rsa ve anahtar varsa
        if (other.CompareTag("kap�1") && hasKey)
        {
            Destroy(kap�1); // Kap�y� yok et
            Debug.Log("Kap� a��ld�!");
        }
    }
}
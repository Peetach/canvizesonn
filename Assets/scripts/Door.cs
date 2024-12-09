using UnityEngine;

public class KeyAndDoor : MonoBehaviour
{
    public GameObject kapý1; // Kapýyý temsil eden GameObject
    private bool hasKey = false; // Anahtarýn alýnýp alýnmadýðýný kontrol etmek için

    void OnTriggerEnter(Collider other)
    {
        // Anahtar alýndýðýnda
        if (other.CompareTag("key1"))
        {
            hasKey = true;
            Destroy(other.gameObject); // Anahtarý yok et
            Debug.Log("Anahtar alýndý!");
        }

        // Kapýya ulaþýrsa ve anahtar varsa
        if (other.CompareTag("kapý1") && hasKey)
        {
            Destroy(kapý1); // Kapýyý yok et
            Debug.Log("Kapý açýldý!");
        }
    }
}
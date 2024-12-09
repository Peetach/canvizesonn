using UnityEngine;
using UnityEngine.SceneManagement; // Sahne geçişi için gerekli

public class SceneChanger : MonoBehaviour
{
    [SerializeField] private string targetScene; // Geçiş yapmak istediğiniz sahnenin adı

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Oyuncu sandığa dokunduysa
        if (collision.CompareTag("Player"))
        {
            SceneManager.LoadScene(targetScene); // Belirtilen sahneye geçiş yap
        }
    }
}

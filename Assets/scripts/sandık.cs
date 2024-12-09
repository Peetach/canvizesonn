using UnityEngine;
using UnityEngine.SceneManagement; // Sahne değiştirmek için gerekli

public class ChestInteraction : MonoBehaviour
{
    // Sandığa tıklama olayı
    void OnMouseDown()
    {
        // Sahne adı veya indeksiyle geçiş
        SceneManager.LoadScene("GameScene"); // "GameScene" yerine kendi oyun sahnenizin adını yazın.
    }
}

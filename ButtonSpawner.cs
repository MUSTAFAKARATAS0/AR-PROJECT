using UnityEngine;

public class ButtonSpawner : MonoBehaviour
{
    public GameObject buttonPrefab;      // Buton prefab'�n�z
    public int buttonCount = 5;            // Olu�turulacak buton say�s�
    public Vector3 spawnAreaSize = new Vector3(2, 2, 2);  // Rastgele konumlar�n da��l�m alan�

    void Start()
    {
        SpawnButtons();
    }

    void SpawnButtons()
    {
        for (int i = 0; i < buttonCount; i++)
        {
            // Rastgele konum olu�turma (AR ortam�n�z�n koordinat sistemine g�re ayarlay�n)
            Vector3 randomPos = new Vector3(
                Random.Range(-spawnAreaSize.x / 2, spawnAreaSize.x / 2),
                Random.Range(-spawnAreaSize.y / 2, spawnAreaSize.y / 2),
                Random.Range(-spawnAreaSize.z / 2, spawnAreaSize.z / 2)
            );
            // Buton instantiate etme
            Instantiate(buttonPrefab, randomPos, Quaternion.identity, transform);
        }
    }
}

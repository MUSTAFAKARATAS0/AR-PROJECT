using UnityEngine;

public class ButtonSpawner : MonoBehaviour
{
    public GameObject buttonPrefab;      // Buton prefab'ýnýz
    public int buttonCount = 5;            // Oluþturulacak buton sayýsý
    public Vector3 spawnAreaSize = new Vector3(2, 2, 2);  // Rastgele konumlarýn daðýlým alaný

    void Start()
    {
        SpawnButtons();
    }

    void SpawnButtons()
    {
        for (int i = 0; i < buttonCount; i++)
        {
            // Rastgele konum oluþturma (AR ortamýnýzýn koordinat sistemine göre ayarlayýn)
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

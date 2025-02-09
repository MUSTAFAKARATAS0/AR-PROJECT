using UnityEngine;

public class DistanceCalculator : MonoBehaviour
{
    // Bu fonksiyonu, bir butona týklandýðýnda veya belirli bir olay tetiklendiðinde çaðýrabilirsiniz.
    public float CalculateMaxDistance()
    {
        GameObject[] buttons = GameObject.FindGameObjectsWithTag("Button");
        float maxDistance = 0f;

        // Tüm buton çiftleri arasýndaki mesafeleri hesaplayýn
        for (int i = 0; i < buttons.Length; i++)
        {
            for (int j = i + 1; j < buttons.Length; j++)
            {
                float distance = Vector3.Distance(buttons[i].transform.position, buttons[j].transform.position);
                if (distance > maxDistance)
                {
                    maxDistance = distance;
                }
            }
        }
        Debug.Log("En uzun mesafe: " + maxDistance);
        return maxDistance;
    }
}

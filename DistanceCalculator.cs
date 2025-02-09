using UnityEngine;

public class DistanceCalculator : MonoBehaviour
{
    // Bu fonksiyonu, bir butona t�kland���nda veya belirli bir olay tetiklendi�inde �a��rabilirsiniz.
    public float CalculateMaxDistance()
    {
        GameObject[] buttons = GameObject.FindGameObjectsWithTag("Button");
        float maxDistance = 0f;

        // T�m buton �iftleri aras�ndaki mesafeleri hesaplay�n
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

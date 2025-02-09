using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonBehavior : MonoBehaviour, IPointerClickHandler
{
    public DistanceCalculator distanceCalculator;  // Sahnedeki DistanceCalculator referansý

    public void OnPointerClick(PointerEventData eventData)
    {
        // Butona týklanýldýðýnda DistanceCalculator içindeki hesaplama fonksiyonunu çaðýrabilirsiniz.
        float longestDistance = distanceCalculator.CalculateMaxDistance();
        // Örneðin; týklanan buton çiftinin mesafesi uzun mesafeye eþitse, oyunu kazanmýþ sayabilirsiniz.
        // Bu kýsmý kendi mantýðýnýza göre geniþletebilirsiniz.
        Debug.Log(gameObject.name + " týklandý. Hesaplanan en uzun mesafe: " + longestDistance);
        // Eðer kazanma koþulu saðlanýyorsa:
        if (/* týklanan buton çiftinin mesafesi == longestDistance */ false)
        {
            Debug.Log("Oyunu kazandýnýz!");
            // Oyun yeniden baþlatýlabilir:
            UnityEngine.SceneManagement.SceneManager.LoadScene(
                UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
        }
    }
}

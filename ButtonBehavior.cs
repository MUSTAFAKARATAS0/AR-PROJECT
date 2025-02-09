using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonBehavior : MonoBehaviour, IPointerClickHandler
{
    public DistanceCalculator distanceCalculator;  // Sahnedeki DistanceCalculator referans�

    public void OnPointerClick(PointerEventData eventData)
    {
        // Butona t�klan�ld���nda DistanceCalculator i�indeki hesaplama fonksiyonunu �a��rabilirsiniz.
        float longestDistance = distanceCalculator.CalculateMaxDistance();
        // �rne�in; t�klanan buton �iftinin mesafesi uzun mesafeye e�itse, oyunu kazanm�� sayabilirsiniz.
        // Bu k�sm� kendi mant���n�za g�re geni�letebilirsiniz.
        Debug.Log(gameObject.name + " t�kland�. Hesaplanan en uzun mesafe: " + longestDistance);
        // E�er kazanma ko�ulu sa�lan�yorsa:
        if (/* t�klanan buton �iftinin mesafesi == longestDistance */ false)
        {
            Debug.Log("Oyunu kazand�n�z!");
            // Oyun yeniden ba�lat�labilir:
            UnityEngine.SceneManagement.SceneManager.LoadScene(
                UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
        }
    }
}

# AR-PROJECT
Bu proje, AR teknolojisini kullanarak çocukların öğrenme deneyimini etkileşimli ve eğlenceli hale getirmeyi amaçlayan bir projedir. Bu proje, Orevly uygulamasıyla geliştirilmiş olup Unity platformunda çalışmaktadır.

Proje Genel Bakışı
Hedef Kitle: Çocuklar
Platform: Artırılmış Gerçeklik (AR) tabanlı eğitim uygulaması
Geliştirme Ortamı: Unity + Orevly Uygulaması
Amaç: AR teknolojisi ile etkileşimli öğrenme deneyimi sunarak, çocukların tarih ve diğer eğitici konuları keşfetmelerini sağlamak.
Temel Özellikler
Interaktif AR Oyunları:
Çocukların eğlenceli ve öğretici deneyimler yaşamalarını sağlayan dinamik AR oyunları.

Dinamik Buton Mekaniği:
Uygulamada, belirlenen alanda rastgele yerleştirilen butonlar arasında mesafe hesaplaması yapılır.

Kazanan Buton:
Buton çiftleri arasındaki mesafeler hesaplanır. Tıklanan buton çifti, hesaplanan en uzun mesafeye eşit olduğunda oyuncu "Kazandınız" ekranına yönlendirilir.
Kaybeden Buton:
Diğer durumlarda, oyuncu "Kaybettiniz" ekranına yönlendirilir.
Rastgele Buton Dağılımı:
ButtonSpawner scripti ile butonlar, belirlenen spawn alanı içerisinde rastgele konumlandırılır.

Mesafe Hesaplaması:
DistanceCalculator scripti, sahnedeki tüm butonlar arasındaki mesafeleri hesaplayarak en uzun mesafeyi belirler.

Kullanıcı Dostu Arayüz:
Çocukların kolayca kullanabilmesi için renkli ve sezgisel bir tasarım sunar.

Kod Bileşenleri
ButtonBehavior.cs
Bu script, her bir butonun tıklanma olayını yönetir. Kullanıcı butona tıkladığında, DistanceCalculator kullanılarak buton çiftleri arasındaki en uzun mesafe hesaplanır. Eğer tıklanan buton çifti bu mesafeye eşitse, oyunun kazanıldığı kabul edilir; aksi halde kaybetme durumu işlenir.

csharp
Kopyala
Düzenle
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonBehavior : MonoBehaviour, IPointerClickHandler
{
    public DistanceCalculator distanceCalculator;  // DistanceCalculator referansı

    public void OnPointerClick(PointerEventData eventData)
    {
        // En uzun mesafe hesaplanır.
        float longestDistance = distanceCalculator.CalculateMaxDistance();
        Debug.Log(gameObject.name + " tıklandı. Hesaplanan en uzun mesafe: " + longestDistance);
        
        // Örnek kazanma koşulu: tıklanan buton çiftinin mesafesi hesaplanan en uzun mesafeye eşitse.
        // (Buraya kendi mantığınızı ekleyebilirsiniz.)
        if (/* tıklanan buton çiftinin mesafesi == longestDistance */ false)
        {
            Debug.Log("Oyunu kazandınız!");
            // Örneğin, kazanma ekranına yönlendirme veya sahnenin yeniden yüklenmesi:
            UnityEngine.SceneManagement.SceneManager.LoadScene(
                UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
        }
        else
        {
            Debug.Log("Oyunu kaybettiniz!");
            // Kaybetme durumunda farklı işlemler yapılabilir.
        }
    }
}
ButtonSpawner.cs
Bu script, belirlenen alan içerisinde rastgele konumlarda butonlar oluşturur. Butonlar, oyunun başlangıcında spawn edilir.

csharp
Kopyala
Düzenle
using UnityEngine;

public class ButtonSpawner : MonoBehaviour
{
    public GameObject buttonPrefab;      // Buton prefab'ı
    public int buttonCount = 5;            // Oluşturulacak buton sayısı
    public Vector3 spawnAreaSize = new Vector3(2, 2, 2);  // Rastgele konumların dağılım alanı

    void Start()
    {
        SpawnButtons();
    }

    void SpawnButtons()
    {
        for (int i = 0; i < buttonCount; i++)
        {
            // AR ortamına uygun rastgele konum belirleniyor.
            Vector3 randomPos = new Vector3(
                Random.Range(-spawnAreaSize.x / 2, spawnAreaSize.x / 2),
                Random.Range(-spawnAreaSize.y / 2, spawnAreaSize.y / 2),
                Random.Range(-spawnAreaSize.z / 2, spawnAreaSize.z / 2)
            );
            // Buton instantiate ediliyor.
            Instantiate(buttonPrefab, randomPos, Quaternion.identity, transform);
        }
    }
}
DistanceCalculator.cs
Bu script, sahnedeki tüm butonlar arasındaki mesafeleri hesaplar ve en uzun olan mesafeyi belirler. Hesaplanan değer, buton tıklama olayında referans olarak kullanılır.

csharp
Kopyala
Düzenle
using UnityEngine;

public class DistanceCalculator : MonoBehaviour
{
    public float CalculateMaxDistance()
    {
        GameObject[] buttons = GameObject.FindGameObjectsWithTag("Button");
        float maxDistance = 0f;

        // Tüm buton çiftleri arasındaki mesafeler hesaplanır.
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
Kullanılan Teknolojiler ve Araçlar
Unity: AR uygulamasının geliştirilmesinde kullanılan ana platform.
Orevly Uygulaması: Projenin AR bileşenlerini entegre etmek için kullanılan araç.
C#: Kodlama dili.
AR Teknolojisi: Çocuklara yönelik etkileşimli deneyim sunmak için kullanılan teknoloji.
Kurulum ve Çalıştırma
Projeyi Klonlayın:
GitHub üzerindeki depodan projeyi bilgisayarınıza klonlayın.

Unity Editor ile Açın:
Klonladığınız projeyi Unity Editor içerisinde açın.

Orevly Entegrasyonu:
Projeyi Orevly uygulamasıyla entegre edin. (Detaylı entegrasyon dökümantasyonu, Orevly dokümanlarında mevcuttur.)

Sahneyi Çalıştırın:
Unity Editor içerisinde sahneyi çalıştırarak projeyi test edebilirsiniz.

Lisans
Bu proje, Apache Lisansı 2.0 kapsamında lisanslanmıştır. Daha fazla bilgi için lütfen LICENSE dosyasını inceleyiniz.

Bu proje, AR teknolojisiyle eğitim ve eğlenceyi birleştirerek çocuklara interaktif bir öğrenme deneyimi sunmayı amaçlamaktadır. Geri bildirimleriniz ve katkılarınız bizim için değerlidir!

# 🚀 AR-DİSTANCE-PROJECT 🚀

## 📋 Proje Genel Bakışı 📋

- **Hedef Kitle:** Çocuklar
- **Platform:** Artırılmış Gerçeklik (AR) tabanlı eğitim uygulaması
- **Geliştirme Ortamı:** Unity + Orevly Uygulaması
- **Amaç:** AR teknolojisi ile etkileşimli öğrenme deneyimi sunarak, çocukların tarih ve diğer eğitici konuları keşfetmelerini sağlamak.

## 📌 Temel Özellikler

- **Interaktif AR Oyunları:** Çocukların eğlenceli ve öğretici deneyimler yaşamalarını sağlayan dinamik AR oyunları.
- **Dinamik Buton Mekaniği:** Uygulamada, belirlenen alanda rastgele yerleştirilen butonlar arasında mesafe hesaplaması yapılır.
- **Kazanan Buton:** Buton çiftleri arasındaki mesafeler hesaplanır. Tıklanan buton çifti, hesaplanan en uzun mesafeye eşit olduğunda oyuncu "Kazandınız" ekranına yönlendirilir.
- **Kaybeden Buton:** Diğer durumlarda, oyuncu "Kaybettiniz" ekranına yönlendirilir.
- **Rastgele Buton Dağılımı:** `ButtonSpawner` scripti ile butonlar, belirlenen spawn alanı içerisinde rastgele konumlandırılır.
- **Mesafe Hesaplaması:** `DistanceCalculator` scripti, sahnedeki tüm butonlar arasındaki mesafeleri hesaplayarak en uzun mesafeyi belirler.
- **Kullanıcı Dostu Arayüz:** Çocukların kolayca kullanabilmesi için renkli ve sezgisel bir tasarım sunar.

## 🛠 Kod Bileşenleri

### `ButtonBehavior.cs`

Bu script, her bir butonun tıklanma olayını yönetir. Kullanıcı butona tıkladığında, `DistanceCalculator` kullanılarak buton çiftleri arasındaki en uzun mesafe hesaplanır. Eğer tıklanan buton çifti bu mesafeye eşitse, oyunun kazanıldığı kabul edilir; aksi halde kaybetme durumu işlenir.

```csharp
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonBehavior : MonoBehaviour, IPointerClickHandler
{
    public DistanceCalculator distanceCalculator;

    public void OnPointerClick(PointerEventData eventData)
    {
        float longestDistance = distanceCalculator.CalculateMaxDistance();
        Debug.Log(gameObject.name + " tıklandı. Hesaplanan en uzun mesafe: " + longestDistance);
        
        if (/* tıklanan buton çiftinin mesafesi == longestDistance */ false)
        {
            Debug.Log("Oyunu kazandınız!");
            UnityEngine.SceneManagement.SceneManager.LoadScene(
                UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
        }
        else
        {
            Debug.Log("Oyunu kaybettiniz!");
        }
    }
}
```

### `ButtonSpawner.cs`

Bu script, belirlenen alan içerisinde rastgele konumlarda butonlar oluşturur. Butonlar, oyunun başlangıcında spawn edilir.

```csharp
using UnityEngine;

public class ButtonSpawner : MonoBehaviour
{
    public GameObject buttonPrefab;
    public int buttonCount = 5;
    public Vector3 spawnAreaSize = new Vector3(2, 2, 2);

    void Start()
    {
        SpawnButtons();
    }

    void SpawnButtons()
    {
        for (int i = 0; i < buttonCount; i++)
        {
            Vector3 randomPos = new Vector3(
                Random.Range(-spawnAreaSize.x / 2, spawnAreaSize.x / 2),
                Random.Range(-spawnAreaSize.y / 2, spawnAreaSize.y / 2),
                Random.Range(-spawnAreaSize.z / 2, spawnAreaSize.z / 2)
            );
            Instantiate(buttonPrefab, randomPos, Quaternion.identity, transform);
        }
    }
}
```

### `DistanceCalculator.cs`

Bu script, sahnedeki tüm butonlar arasındaki mesafeleri hesaplar ve en uzun olan mesafeyi belirler.

```csharp
using UnityEngine;

public class DistanceCalculator : MonoBehaviour
{
    public float CalculateMaxDistance()
    {
        GameObject[] buttons = GameObject.FindGameObjectsWithTag("Button");
        float maxDistance = 0f;

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
```

## 🛠 Kullanılan Teknolojiler ve Araçlar

- **Unity**: AR uygulamasının geliştirilmesinde kullanılan ana platform.
- **Orevly Uygulaması**: Projenin AR bileşenlerini entegre etmek için kullanılan araç.
- **C#**: Kodlama dili.
- **AR Teknolojisi**: Çocuklara yönelik etkileşimli deneyim sunmak için kullanılan teknoloji.

## 📥 Kurulum ve Çalıştırma

## 🎥 Proje Anlatım Videosu
https://www.youtube.com/watch?v=uNnm31Hddm8&ab_channel=mustafakarata%C5%9F

### QR Kod ile Uygulamaya Erişim

Bu QR kodu, Overly App'i indirip projeye ulaşabilmeniz için kullanabilirsiniz.

![QR Kodu](https://github.com/MUSTAFAKARATAS0/AR-PROJECT/blob/main/QR_kodu.jpeg)

### Projeyi Klonlayın

GitHub üzerindeki depodan projeyi bilgisayarınıza klonlayın.

```
git clone https://github.com/MUSTAFAKARATAS0/AR-PROJECT.git
```

### Unity Editor ile Açın

Klonladığınız projeyi Unity Editor içerisinde açın.

### Orevly Entegrasyonu

Projeyi Orevly uygulamasıyla entegre edin. (Detaylı entegrasyon dökümantasyonu, Orevly dokümanlarında mevcuttur.)

### Sahneyi Çalıştırın

Unity Editor içerisinde sahneyi çalıştırarak projeyi test edebilirsiniz.

## 🌐 Web Sitesi 🌐

[Portföy Sitem](https://karatasmustafa.com/)

Sitemin kaynak kodlarına [buradan](https://github.com/MUSTAFAKARATAS0/site) erişebilirsiniz.

---
Bu proje, AR teknolojisiyle eğitim ve eğlenceyi birleştirerek çocuklara interaktif bir öğrenme deneyimi sunmayı amaçlamaktadır. Geri bildirimleriniz ve katkılarınız bizim için değerlidir! 🎮


![WhatsApp Görsel 2025-02-09 saat 18 12 56_b2fa5513](https://github.com/user-attachments/assets/c727b1d0-69c7-4c98-9b5a-3da4b324060b)


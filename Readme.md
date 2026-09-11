# Subnautica-BZVR-Fix

Subnautica: Below Zero için VR uyumluluğunu düzeltmeye yönelik bir yama/mod aracı. Oyunun build ayarlarını değiştirerek VR desteğini düzeltir.

<img width="701" height="791" alt="Subnautica BZ VR Fix önizleme" src="https://github.com/user-attachments/assets/c64ac108-4569-41f9-9a40-52f3cd62dd9c" />

## Başlarken

Bu talimatlar, projeyi kendi bilgisayarınızda çalıştırmanız veya geliştirme yapmanız için gereken adımları içerir.

### Gereksinimler

- Subnautica: Below Zero (Steam sürümü)
- Submersed VR modunun son sürümü

### Kurulum

1. Bu reponun son sürümünü [Releases](releases-linki) sayfasından indirin.
2. `.zip` dosyasını istediğiniz bir klasöre çıkartın.
3. `VRBuildSettingsPatcher.exe` dosyasını çalıştırın.
4. Aşağıdaki gibi bir ekran görüyorsanız işlem başarıyla tamamlanmış demektir:

   <img width="1122" height="622" alt="VRBuildSettingsPatcher başarılı ekranı" src="https://github.com/user-attachments/assets/2b0ae412-45b1-4989-8966-0f3231b12328" />

5. `Subnatica-bz-launcher-maker.py` dosyasına çift tıklayın. Aşağıdaki ekran açılacaktır:

   <img width="650" height="72" alt="Launcher maker ekranı" src="https://github.com/user-attachments/assets/1c2fea7e-6515-4614-ab75-bea0a272a751" />

6. Çıkan ekranda **Browse** deyip `C:\Program Files (x86)\Steam\steamapps\common` yolundan `SubnauticaZero` adlı klasörü seçin.
7. Ardından oyunun `.exe` yolu otomatik olarak bulunacaktır. **Create Launcher** butonuna tıklayın:

   <img width="890" height="170" alt="Create Launcher çıktısı" src="https://github.com/user-attachments/assets/4e57d2ad-d4ee-4992-91e8-3b3454c69132" />

8. Buradaki yazının tamamını kopyalayın. Aşağıdaki gibi olması gerekir:

   ```
   "C:/Program Files (x86)/Steam/steamapps/common/SubnauticaZero/SubnauticaZeroLauncher.exe" %command%
   ```

9. Bu satırı Steam'de oyunun **Başlatma Seçenekleri**'ne (Launch Options) ekleyin.
10. Son adım için 2 dosyaya ihtiyacınız var: `openvr_api.dll` ve `OVRPlugin.dll`.
    - `openvr_api.dll` dosyasını, SteamVR kuruluysa (buraya kadar geldiyseniz kurulu olmalı) şu yoldan bulabilirsiniz:
      `C:\Program Files (x86)\Steam\steamapps\common\SteamVR\bin\win64`
    - `OVRPlugin.dll` dosyasını başka bir kaynaktan temin edin.
    - Her iki dosyayı da şu klasöre yapıştırın:
      `C:\Program Files (x86)\Steam\steamapps\common\SubnauticaZero\SubnauticaZero_Data\Plugins\x86_64`
11. VR başlığınızı takıp SteamVR'ı açın, oyunu başlatın ve arkanıza yaslanın.

## Testlerin Çalıştırılması

*(Otomatik testiniz yoksa bu bölümü README'den tamamen kaldırabilirsiniz)*

## Dağıtım (Deployment)

Yeni bir sürüm yayınlarken:

1. Projeyi Release modunda derleyin.
2. `bin/Release/net472/` klasöründeki gerekli dosyaları (`.exe`, `.exe.config`, `AssetsTools.NET.dll`, `classdata.tpk`) zip'leyin.
3. GitHub'da yeni bir Release oluşturup zip'i yükleyin.

## Kullanılan Teknolojiler / Kütüphaneler

- [AssetsTools.NET](https://github.com/nesrak1/AssetsTools.NET) — Unity asset dosyalarını okuma/düzenleme (MIT Lisansı)
- [UABEA](https://github.com/nesrak1/UABEA) — Referans alınan araç (MIT Lisansı)

## Katkıda Bulunma

Katkıda bulunmak isterseniz lütfen bir Issue açın veya Pull Request gönderin.

## Sürümleme

Bu proje [SemVer](https://semver.org/) sürümleme sistemini kullanır. Mevcut sürümler için repodaki [Releases](releases-linki) sayfasına bakabilirsiniz.

## Lisans

Bu proje [MIT Lisansı](LICENSE) altında lisanslanmıştır.

## Teşekkürler

- AssetsTools.NET ve UABEA projelerine, kullandığım kütüphaneler için teşekkürler.
- Subnautica: Below Zero VR modding topluluğuna.

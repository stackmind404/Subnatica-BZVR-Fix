<img width="701" height="791" alt="image" src="https://github.com/user-attachments/assets/c64ac108-4569-41f9-9a40-52f3cd62dd9c" /># Subnatica-BZVR-Fix

Subnautica Below Zero için VR uyumluluğunu düzeltmeye yönelik bir yama/mod aracı. Oyunun build ayarlarını değiştirerek VR desteğini düzeltir.

## Başlarken

Bu talimatlar, projeyi kendi bilgisayarınızda çalıştırmanız veya geliştirme yapmanız için gereken adımları içerir.

### Gereksinimler

- Subnautica Below Zero (Steam sürümü)
- Submersed vr modunun son sürümü

### Kurulum

1. Bu reponun son sürümünü [Releases] sayfasından indirin
2. `.zip` dosyasını istediğiniz bir klasöre çıkartın
3. `VRBuildSettingsPatcher.exe` dosyasını çalıştırın
4.<img width="1122" height="622" alt="image" src="https://github.com/user-attachments/assets/2b0ae412-45b1-4989-8966-0f3231b12328" />
5. Görseldeki  ekranı görüuyorsanız işlem Başarıyla tamamlanmıştır
6. `Subnatica-bz-launcher-maker.py`  Dosyasına Çift tıklayın
7. <img width="650" height="72" alt="image" src="https://github.com/user-attachments/assets/1c2fea7e-6515-4614-ab75-bea0a272a751" />
8. Çıkan ekranda Browse Diyip  `C:\Program Files (x86)\Steam\steamapps\common` Yolundan `SubnaticaZero` Adlı Klasörü Seçin
9. Sonrasında Oyunun exe Yolunu otomatik Bulacaktir "Create Launcher" Butonuna Tıklayın
10. <img width="890" height="170" alt="image" src="https://github.com/user-attachments/assets/4e57d2ad-d4ee-4992-91e8-3b3454c69132" />
11. Burdakı Yazının Tamamını Kopyalayın `"C:/Program Files (x86)/Steam/steamapps/common/SubnauticaZero\SubnauticaZeroLauncher.exe" %command%` Bu Şekilde olması Lazım
12. ![Uploading image.png…]()
13. Steam Başlatma Seçeneklerine ekleyin
14. Artık Son adımlara geldik bize  `openvr_api.dll`  ve `OVRPlugin.dll` Adlı 2 tane dosya lazım İlk dosyayı Steam Vr adlı progamınız varsa ki (Yani buraya kadar geldiyseniz vardır) `C:\Program Files (x86)\Steam\steamapps\common\SteamVR\bin\win64` bu yoldan bulabilirsiniz 2. Dosya bende vardı eksikse bir yerden tamamlayın  bu iki dosyayı  `C:\Program Files (x86)\Steam\steamapps\common\SubnauticaZero\SubnauticaZero_Data\Plugins\x86_64` Yoluna Yapıştırın
15. Ve son olarak Vrınızı takıp steamvr ı Açıp oyuuna başlayıp arkanıza yaslanın  


 

## Testlerin Çalıştırılması

*(Otomatik testiniz yoksa bu bölümü README'den tamamen kaldırabilirsiniz)*

## Dağıtım (Deployment)

Yeni bir sürüm yayınlarken:
1. Projeyi Release modunda derleyin
2. `bin/Release/net472/` klasöründeki gerekli dosyaları (`.exe`, `.exe.config`, `AssetsTools.NET.dll`, `classdata.tpk`) zip'leyin
3. GitHub'da yeni bir Release oluşturup zip'i yükleyin

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

- AssetsTools.NET ve UABEA projelerine, kullandığım kütüphaneler için teşekkürler
- Subnautica Below Zero VR modding topluluğuna

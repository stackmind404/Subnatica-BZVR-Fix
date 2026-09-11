# Subnatica-BZVR-Fix

Subnautica Below Zero için VR uyumluluğunu düzeltmeye yönelik bir yama/mod aracı. Oyunun build ayarlarını değiştirerek VR desteğini düzeltir.

## Başlarken

Bu talimatlar, projeyi kendi bilgisayarınızda çalıştırmanız veya geliştirme yapmanız için gereken adımları içerir.

### Gereksinimler

- .NET Framework 4.7.2
- Visual Studio 2019 veya üzeri
- Subnautica Below Zero (Steam/Epic sürümü)
- [Launcher Adı](launcher-linki) — oyunu VR modunda başlatmak için gerekli

### Kurulum

1. Bu repoyu klonlayın veya son sürümü [Releases](releases-linki) sayfasından indirin
2. `.zip` dosyasını istediğiniz bir klasöre çıkartın
3. `VRBuildSettingsPatcher.exe` dosyasını çalıştırın
4. Yama işlemi tamamlandıktan sonra oyunu [Launcher Adı] üzerinden başlatın

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

## Geliştirici

- **[Adın]** — *Proje sahibi*

## Lisans

Bu proje [MIT Lisansı](LICENSE) altında lisanslanmıştır.

## Teşekkürler

- AssetsTools.NET ve UABEA projelerine, kullandığım kütüphaneler için teşekkürler
- Subnautica Below Zero VR modding topluluğuna

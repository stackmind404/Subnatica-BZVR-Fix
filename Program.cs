using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AssetsTools.NET;
using AssetsTools.NET.Extra;

namespace VRBuildSettingsPatcher
{
    internal static class Program
    {
        private const long BuildSettingsPathId = 11;

        private static int Main(string[] args)
        {
            Console.WriteLine("==========================================");
            Console.WriteLine(" VRBuildSettingsPatcher");
            Console.WriteLine(" Subnautica: Below Zero");
            Console.WriteLine("==========================================");
            Console.WriteLine();

            try
            {
                RunPatch();
            }
            catch (Exception ex)
            {
                Console.WriteLine();
                Console.WriteLine("BEKLENMEYEN HATA:");
                Console.WriteLine(ex);
            }

            Console.WriteLine();
            Console.WriteLine("Press Enter to exit...");
            Console.ReadLine();

            return 0;
        }

        private static void RunPatch()
        {
            // ------------------------------------------------------------
            // 1. Oyun klasörünü bul
            // ------------------------------------------------------------

            string gameRoot = TryAutoDetectGameRoot();

            while (string.IsNullOrWhiteSpace(gameRoot) ||
                   !File.Exists(Path.Combine(gameRoot, "SubnauticaZero.exe")))
            {
                Console.WriteLine("SubnauticaZero.exe otomatik bulunamadi.");
                Console.Write("Oyun klasorunun yolunu gir: ");

                string input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Bos yol girildi.");
                    Console.WriteLine();
                    continue;
                }

                input = input.Trim().Trim('"');

                if (!File.Exists(
                    Path.Combine(input, "SubnauticaZero.exe")))
                {
                    Console.WriteLine(
                        "Bu klasorde SubnauticaZero.exe bulunamadi.");
                    Console.WriteLine();
                    continue;
                }

                gameRoot = input;
            }

            Console.WriteLine("Oyun klasoru:");
            Console.WriteLine(gameRoot);
            Console.WriteLine();

            // ------------------------------------------------------------
            // 2. globalgamemanagers
            // ------------------------------------------------------------

            string dataPath =
                Path.Combine(
                    gameRoot,
                    "SubnauticaZero_Data");

            string ggmPath =
                Path.Combine(
                    dataPath,
                    "globalgamemanagers");

            if (!File.Exists(ggmPath))
            {
                Console.WriteLine(
                    "HATA: globalgamemanagers bulunamadi:");
                Console.WriteLine(ggmPath);
                return;
            }

            Console.WriteLine(
                "globalgamemanagers bulundu.");
            Console.WriteLine();

            // ------------------------------------------------------------
            // 3. Kalıcı yedek oluştur
            // ------------------------------------------------------------

            string backupPath =
                ggmPath + ".vrbuildsettings_backup";

            try
            {
                if (!File.Exists(backupPath))
                {
                    File.Copy(
                        ggmPath,
                        backupPath,
                        false);

                    Console.WriteLine(
                        "Kalici yedek olusturuldu.");
                }
                else
                {
                    Console.WriteLine(
                        "Kalici yedek zaten mevcut.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(
                    "HATA: Yedek olusturulamadi.");
                Console.WriteLine(ex);
                return;
            }

            Console.WriteLine();

            // ------------------------------------------------------------
            // 4. classdata.tpk
            // ------------------------------------------------------------

            string exeDir =
                AppDomain.CurrentDomain.BaseDirectory;

            string tpkPath =
                Path.Combine(
                    exeDir,
                    "classdata.tpk");

            if (!File.Exists(tpkPath))
            {
                Console.WriteLine(
                    "HATA: classdata.tpk bulunamadi.");
                Console.WriteLine();
                Console.WriteLine("Aranan yer:");
                Console.WriteLine(tpkPath);
                return;
            }

            Console.WriteLine(
                "classdata.tpk bulundu.");
            Console.WriteLine();

            // ------------------------------------------------------------
            // 5. AssetsTools.NET ile dosyayi ac
            // ------------------------------------------------------------

            AssetsManager manager = new AssetsManager();

            AssetsFileInstance instance = null;

            try
            {
                manager.LoadClassPackage(tpkPath);

                instance =
                    manager.LoadAssetsFile(
                        ggmPath,
                        false);

                string unityVersion =
                    instance.file.Metadata.UnityVersion;

                Console.WriteLine(
                    "Unity version: " +
                    unityVersion);

                manager.LoadClassDatabaseFromPackage(
                    unityVersion);

                Console.WriteLine(
                    "globalgamemanagers basariyla yuklendi.");
                Console.WriteLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine();
                Console.WriteLine(
                    "HATA: globalgamemanagers acilamadi.");
                Console.WriteLine(ex);

                try
                {
                    manager.UnloadAllAssetsFiles(true);
                }
                catch
                {
                }

                return;
            }

            try
            {
                // --------------------------------------------------------
                // 6. BuildSettings asset'ini bul
                // --------------------------------------------------------

                AssetFileInfo buildSettingsInfo =
                    instance.file
                        .GetAssetsOfType(
                            AssetClassID.BuildSettings)
                        .FirstOrDefault();

                if (buildSettingsInfo == null)
                {
                    Console.WriteLine(
                        "HATA: BuildSettings asset bulunamadi.");
                    return;
                }

                Console.WriteLine(
                    "BuildSettings bulundu.");
                Console.WriteLine(
                    "Path ID: " +
                    buildSettingsInfo.PathId);

                if (buildSettingsInfo.PathId !=
                    BuildSettingsPathId)
                {
                    Console.WriteLine();
                    Console.WriteLine(
                        "HATA: BuildSettings Path ID 11 degil.");
                    Console.WriteLine(
                        "Beklenen: 11");
                    Console.WriteLine(
                        "Bulunan: " +
                        buildSettingsInfo.PathId);
                    return;
                }

                // --------------------------------------------------------
                // 7. BuildSettings verisini oku
                // --------------------------------------------------------

                AssetTypeValueField baseField;

                try
                {
                    baseField =
                        manager.GetBaseField(
                            instance,
                            buildSettingsInfo);
                }
                catch (Exception ex)
                {
                    Console.WriteLine();
                    Console.WriteLine(
                        "HATA: BuildSettings deserialize edilemedi.");
                    Console.WriteLine(ex);
                    return;
                }

                if (baseField == null)
                {
                    Console.WriteLine(
                        "HATA: BuildSettings baseField null.");
                    return;
                }

                // --------------------------------------------------------
                // 8. enabledVRDevices alanını bul
                // --------------------------------------------------------

                AssetTypeValueField
                    enabledVrDevicesField =
                        baseField.Get(
                            "enabledVRDevices");

                if (enabledVrDevicesField == null ||
                    enabledVrDevicesField.IsDummy)
                {
                    Console.WriteLine(
                        "HATA: enabledVRDevices bulunamadi.");
                    return;
                }

                AssetTypeValueField
                    enabledVrDevicesArray =
                        enabledVrDevicesField.Get(
                            "Array");

                if (enabledVrDevicesArray == null ||
                    enabledVrDevicesArray.IsDummy)
                {
                    Console.WriteLine(
                        "HATA: enabledVRDevices.Array bulunamadi.");
                    return;
                }

                int currentCount =
                    enabledVrDevicesArray.Children == null
                        ? 0
                        : enabledVrDevicesArray.Children.Count;

                Console.WriteLine(
                    "Mevcut VR device sayisi: " +
                    currentCount);

                // --------------------------------------------------------
                // 9. Zaten patchlenmiş mi?
                // --------------------------------------------------------

                if (currentCount == 2)
                {
                    string first =
                        enabledVrDevicesArray.Children[0].AsString;

                    string second =
                        enabledVrDevicesArray.Children[1].AsString;

                    Console.WriteLine(
                        $"Mevcut degerler: [{first}, {second}]");

                    if (first == "None" &&
                        second == "OpenVR")
                    {
                        Console.WriteLine();
                        Console.WriteLine(
                            "Zaten patchlenmis.");
                        Console.WriteLine(
                            "enabledVRDevices = None, OpenVR");
                        return;
                    }

                    Console.WriteLine();
                    Console.WriteLine(
                        "HATA: Array 2 elemanli ancak degerler");
                    Console.WriteLine(
                        $"beklenen degil: [{first}, {second}]");
                    return;
                }

                if (currentCount != 0)
                {
                    Console.WriteLine();
                    Console.WriteLine(
                        "HATA: Beklenmeyen VR device sayisi: " +
                        currentCount);
                    return;
                }

                // --------------------------------------------------------
                // 10. None + OpenVR ekle
                // --------------------------------------------------------

                AssetTypeValueField noneField =
                    ValueBuilder
                        .DefaultValueFieldFromArrayTemplate(
                            enabledVrDevicesArray);

                noneField.AsString = "None";

                AssetTypeValueField openVrField =
                    ValueBuilder
                        .DefaultValueFieldFromArrayTemplate(
                            enabledVrDevicesArray);

                openVrField.AsString = "OpenVR";

                enabledVrDevicesArray.Children.Clear();
                enabledVrDevicesArray.Children.Add(noneField);
                enabledVrDevicesArray.Children.Add(openVrField);

                Console.WriteLine();
                Console.WriteLine(
                    "Yeni enabledVRDevices:");
                Console.WriteLine(
                    "[0] None");
                Console.WriteLine(
                    "[1] OpenVR");

                // --------------------------------------------------------
                // 11. Değiştirilmiş asset'i işaretle
                // --------------------------------------------------------

                buildSettingsInfo.SetNewData(
                    baseField);

                Console.WriteLine();
                Console.WriteLine(
                    "BuildSettings yeni veriyle hazirlandi.");

                // --------------------------------------------------------
                // 12. Geçici dosyaya yaz
                // --------------------------------------------------------

                string tempPath =
                    ggmPath + ".vrpatched.tmp";

                if (File.Exists(tempPath))
                {
                    File.Delete(tempPath);
                }

                try
                {
                    using (var writer =
                        new AssetsFileWriter(tempPath))
                    {
                        instance.file.Write(
                            writer,
                            0);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine();
                    Console.WriteLine(
                        "HATA: Patchli globalgamemanagers yazilamadi.");
                    Console.WriteLine(ex);

                    if (File.Exists(tempPath))
                    {
                        try
                        {
                            File.Delete(tempPath);
                        }
                        catch
                        {
                        }
                    }

                    return;
                }

                Console.WriteLine();
                Console.WriteLine(
                    "Gecici patch dosyasi yazildi.");
                Console.WriteLine(tempPath);

                // --------------------------------------------------------
                // 13. Kaynak dosyayı kapat
                // --------------------------------------------------------

                try
                {
                    manager.UnloadAllAssetsFiles(true);
                }
                catch
                {
                }

                // --------------------------------------------------------
                // 14. Orijinali güvenli şekilde yedekle
                // --------------------------------------------------------

                string secondaryBackup =
                    ggmPath + ".bak";

                try
                {
                    if (File.Exists(secondaryBackup))
                    {
                        File.Delete(secondaryBackup);
                    }

                    File.Move(
                        ggmPath,
                        secondaryBackup);
                }
                catch (Exception ex)
                {
                    Console.WriteLine();
                    Console.WriteLine(
                        "HATA: Orijinal dosya yedeklenemedi.");
                    Console.WriteLine(ex);

                    return;
                }

                // --------------------------------------------------------
                // 15. Patchli dosyayı aktif dosya yap
                // --------------------------------------------------------

                try
                {
                    File.Move(
                        tempPath,
                        ggmPath);
                }
                catch (Exception ex)
                {
                    Console.WriteLine();
                    Console.WriteLine(
                        "HATA: Patchli dosya yerine konulamadi.");
                    Console.WriteLine(ex);

                    Console.WriteLine();
                    Console.WriteLine(
                        "Orijinal dosya:");
                    Console.WriteLine(
                        secondaryBackup);

                    return;
                }

                // --------------------------------------------------------
                // 16. Başarılı
                // --------------------------------------------------------

                Console.WriteLine();
                Console.WriteLine(
                    "==========================================");
                Console.WriteLine(
                    " SUCCESS!");
                Console.WriteLine(
                    " enabledVRDevices = None, OpenVR");
                Console.WriteLine(
                    "==========================================");
                Console.WriteLine();
                Console.WriteLine(
                    "Yedek:");
                Console.WriteLine(
                    backupPath);
            }
            finally
            {
                try
                {
                    manager.UnloadAllAssetsFiles(true);
                }
                catch
                {
                }
            }
        }

        private static string TryAutoDetectGameRoot()
        {
            // ------------------------------------------------------------
            // Patcher doğrudan oyun klasöründeyse
            // ------------------------------------------------------------

            string ownDirectory =
                AppDomain.CurrentDomain.BaseDirectory;

            if (File.Exists(
                Path.Combine(
                    ownDirectory,
                    "SubnauticaZero.exe")))
            {
                return ownDirectory;
            }

            // ------------------------------------------------------------
            // Yaygın Steam yolları
            // ------------------------------------------------------------

            string[] drives =
            {
                "C",
                "D",
                "E",
                "F",
                "G"
            };

            string[] steamPaths =
            {
                @"Program Files (x86)\Steam\steamapps\common\SubnauticaZero",
                @"Program Files\Steam\steamapps\common\SubnauticaZero",
                @"SteamLibrary\steamapps\common\SubnauticaZero",
                @"Steam\steamapps\common\SubnauticaZero",
                @"Games\Steam\steamapps\common\SubnauticaZero"
            };

            foreach (string drive in drives)
            {
                foreach (string path in steamPaths)
                {
                    string candidate =
                        drive + @":\" + path;

                    if (File.Exists(
                        Path.Combine(
                            candidate,
                            "SubnauticaZero.exe")))
                    {
                        return candidate;
                    }
                }
            }

            return null;
        }
    }
}
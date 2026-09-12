# Subnautica-BZVR-Fix

Fixes the VR Location Not Found error for Subnautica: Below Zero.

## Getting Started

These instructions cover the steps needed to run or develop this project on your own computer.

### Requirements

- Subnautica: Below Zero (Steam version)
- Latest version of the Submersed VR mod

### Installation

1. Download the latest version of this repo from the [Releases](https://github.com/stackmind404/Subnautica-BZVR-Fix/releases) page.
2. Extract the `.zip` file to a folder of your choice.
3. Run `VRBuildSettingsPatcher.exe`.
4. If you see a screen like the one below, the process has completed successfully:

   <img width="1122" height="622" alt="VRBuildSettingsPatcher success screen" src="https://github.com/user-attachments/assets/2b0ae412-45b1-4989-8966-0f3231b12328" />

5. Double-click the `Subnatica-bz-launcher-maker.py` file. The screen below will open:

   <img width="701" height="791" alt="Subnautica BZ VR Fix preview" src="https://github.com/user-attachments/assets/c64ac108-4569-41f9-9a40-52f3cd62dd9c" />

6. In the window that appears, click **Browse** and select the folder named `SubnauticaZero` from the path `C:\Program Files (x86)\Steam\steamapps\common`.
7. The game's `.exe` path will then be found automatically. Click the **Create Launcher** button:

   <img width="650" height="72" alt="image" src="https://github.com/user-attachments/assets/6192eea8-f1df-4115-ab7d-2182596adda4" />

8. Copy the entire text shown here. It should look like this:

   ```
   "C:/Program Files (x86)/Steam/steamapps/common/SubnauticaZero/SubnauticaZeroLauncher.exe" %command%
   ```

9. Add this line to the game's **Launch Options** in Steam.

   <img width="890" height="170" alt="image" src="https://github.com/user-attachments/assets/a958037b-d57c-4fbb-bff5-693b50147aee" />

10. You'll need `openvr_api.dll` for the next step. You can find it at the following path, provided SteamVR is installed (it should be, if you've made it this far):
    `C:\Program Files (x86)\Steam\steamapps\common\SteamVR\bin\win64`
11. You'll also need `OVRPlugin.dll`. Check your computer first (usually in the Oculus/Meta Quest Link install folder) — if you can't find it, you can get it from the [official Meta Horizon Developers page](https://developers.meta.com/horizon/downloads/package/unity-integration/).
12. Paste both files into the following folder:
    `C:\Program Files (x86)\Steam\steamapps\common\SubnauticaZero\SubnauticaZero_Data\Plugins\x86_64`
13. Put on your VR headset, open SteamVR, launch the game, and sit back.


## Deployment

When releasing a new version:

1. Build the project in Release mode.
2. Zip the required files (`.exe`, `.exe.config`, `AssetsTools.NET.dll`, `classdata.tpk`) from the `bin/Release/net472/` folder.
3. Create a new Release on GitHub and upload the zip file.

## Technologies / Libraries Used

- [AssetsTools.NET](https://github.com/nesrak1/AssetsTools.NET) — For reading/editing Unity asset files (MIT License)
- [UABEA](https://github.com/nesrak1/UABEA) — Reference tool (MIT License)

## Contributing

If you'd like to contribute, please open an Issue or submit a Pull Request.

## Versioning

This project uses the [SemVer](https://semver.org/) versioning system. You can check the repo's [Releases](https://github.com/stackmind404/Subnautica-BZVR-Fix/releases page for available versions.

## License

This project is licensed under the [MIT License](LICENSE).

## Acknowledgements

- Thanks to the AssetsTools.NET and UABEA projects for the libraries I used.
- Thanks to the Subnautica: Below Zero VR modding community.

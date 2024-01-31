using UnityEngine;
using UnityEngine.SceneManagement;
public class ToggleDevice : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            DeviceModeManager.CurrentDeviceMode = DeviceMode.ESP32;
            SceneManager.LoadScene("TitleScene_ESP32");
        }
        if (Input.GetKeyDown(KeyCode.N))
        {
            DeviceModeManager.CurrentDeviceMode = DeviceMode.Nano;
            SceneManager.LoadScene("TitleScene_Nano");
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            DeviceModeManager.CurrentDeviceMode = DeviceMode.KeyBoard;
            SceneManager.LoadScene("TitleScene_KeyBoard");
        }
    }
}
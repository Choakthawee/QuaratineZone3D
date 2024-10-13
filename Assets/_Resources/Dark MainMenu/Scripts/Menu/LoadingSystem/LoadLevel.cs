using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour
{

    public void ContinueGame()
    {
        StartCoroutine(LoadSceneWithDelay("In-Game", 2f)); // โหลดฉาก In-Game หลังจาก 2 วินาที
    }

    public void LoadScene(string level)
    {
        StartCoroutine(LoadSceneWithDelay(level, 2f)); // โหลดฉากที่เลือกหลังจาก 2 วินาที
    }

    public void MainMenu()
    {
        // โหลดหน้าเมนูหลัก
        SceneManager.LoadScene("MainMenu");
    }

    public void ApplicationExit()
    {
        Application.Quit();
    }

    private IEnumerator LoadSceneWithDelay(string sceneName, float delay)
    {
        yield return new WaitForSeconds(delay); // รอเป็นเวลา delay วินาที
        SceneManager.LoadScene("Loading"); // ไปที่หน้าโหลด
    }
}

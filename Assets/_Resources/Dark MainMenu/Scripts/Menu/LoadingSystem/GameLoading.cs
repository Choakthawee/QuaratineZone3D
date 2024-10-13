using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameLoading : MonoBehaviour
{

    public GameObject loadingInfo, loadingIcon;
    private AsyncOperation async;

    IEnumerator Start()
    {
        loadingIcon.SetActive(true);
        loadingInfo.SetActive(false);

        // แสดงหน้าโหลดเป็นเวลา 2 วินาที
        yield return new WaitForSeconds(2f);

        async = SceneManager.LoadSceneAsync("In-Game");
        async.allowSceneActivation = false;

        // แสดงข้อมูลโหลด
        loadingIcon.SetActive(false);
        loadingInfo.SetActive(true);

        // เริ่มฉากจริง
        while (!async.isDone)
        {
            if (async.progress >= 0.9f) // เมื่อโหลดเสร็จแล้ว
            {
                async.allowSceneActivation = true;
            }
            yield return null;
        }
    }
}

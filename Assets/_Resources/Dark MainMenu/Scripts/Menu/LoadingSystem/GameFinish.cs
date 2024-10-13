using UnityEngine;
using UnityEngine.SceneManagement;

public class GameFinish : MonoBehaviour
{

    void OnTriggerEnter(Collider coll)
    {
        if (coll.transform.CompareTag("Player")) // ตรวจสอบแท็ก Player
        {
            SceneManager.LoadScene("Loading"); // โหลดหน้าโหลด
        }
    }
}

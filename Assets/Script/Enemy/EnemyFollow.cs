using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public Transform player; // ตัวแปรเก็บตำแหน่งของผู้เล่น
    public float speed = 2f; // ความเร็วในการเดินของซอมบี้
    public float stoppingDistance = 1.5f; // ระยะห่างที่ซอมบี้จะหยุดไม่เข้าใกล้ผู้เล่นเกินไป

    void Update()
    {
        if (player != null)
        {
            // คำนวณระยะห่างระหว่างซอมบี้กับผู้เล่น
            float distance = Vector3.Distance(transform.position, player.position);

            // ตรวจสอบว่าระยะห่างมากกว่าระยะที่กำหนดไว้หรือไม่
            if (distance > stoppingDistance)
            {
                // คำนวณทิศทางจากซอมบี้ไปยังผู้เล่น
                Vector3 direction = (player.position - transform.position).normalized;

                // หมุนหน้าซอมบี้ให้หันไปทางผู้เล่น
                transform.LookAt(player);

                // เคลื่อนที่ไปในทิศทางที่คำนวณไว้ด้วยความเร็วที่กำหนด
                transform.Translate(direction * speed * Time.deltaTime, Space.World);
            }
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool isGrounded;
    public float speed = 5f;
    public float gravity = -9.8f;
    public float jumpHeight = 3f;

    private Animator animator; // เพิ่มตัวแปรสำหรับ Animator

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>(); // กำหนดค่า Animator
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = controller.isGrounded;
    }

    public void ProcessMove(Vector2 input)
    {
        Vector3 moveDirection = Vector3.zero;
        moveDirection.x = input.x;
        moveDirection.z = input.y;

        // เช็คว่ามีการเคลื่อนที่หรือไม่
        if (moveDirection.x != 0 || moveDirection.z != 0)
        {
            // ถ้ามีการเคลื่อนที่ เล่นแอนิเมชันการวิ่ง
            animator.Play("Run Without Gun State");
        }
        else
        {
            // ถ้าไม่มีการเคลื่อนที่ เล่นแอนิเมชันหยุดนิ่ง
            animator.Play("Idle State"); // เปลี่ยนเป็นชื่อแอนิเมชันที่ตรงกัน
        }

        controller.Move(transform.TransformDirection(moveDirection) * speed * Time.deltaTime);
        
        // จัดการแรงโน้มถ่วง
        playerVelocity.y += gravity * Time.deltaTime;
        if (isGrounded && playerVelocity.y < 0)
            playerVelocity.y = -2f;

        // ย้ายตัวละคร
        controller.Move(playerVelocity * Time.deltaTime);

        // Debug ดูค่าการเคลื่อนที่ในแกน Y
        Debug.Log(playerVelocity.y);
    }

    public void Jump()
    {
        if (isGrounded)
        {
            playerVelocity.y = Mathf.Sqrt(jumpHeight * -3.0f * gravity);
        }
    }
}

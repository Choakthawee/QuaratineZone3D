using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rigidBody;
    public float speed = 4;

    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // เราไม่ต้องทำอะไรที่นี่ถ้าไม่ต้องการให้ตัวละครหันตามเมาส์
    }

    void FixedUpdate()
    {
        // รับ input จากปุ่ม W, A, S, D
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // ถ้ามีการเคลื่อนที่ เล่น animation การวิ่ง
        if (horizontal != 0 || vertical != 0)
        {
            animator.Play("Run Without Gun State");
        }

        // คำนวณทิศทางการเคลื่อนที่ตามทิศทางที่ตัวละครหัน
        Vector3 movement = transform.forward * vertical + transform.right * horizontal;

        // ปรับความยาวให้คงที่เพื่อการเคลื่อนที่ที่สมดุล
        movement.Normalize();

        // ใช้ MovePosition แทน AddForce เพื่อเคลื่อนที่ตัวละคร
        rigidBody.MovePosition(transform.position + movement * speed * Time.fixedDeltaTime);
    }
}
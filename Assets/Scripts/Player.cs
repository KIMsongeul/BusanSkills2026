using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    //이동 
    private float moveSpeed = 3f;
    private float rotSpeed = 2f;

    //폭탄
    private int bombCount = 3;
    
    //아이템
    private int hpRecoveryCount = 0;
    
    private Rigidbody2D rigid;
    private HpSystem hp;

    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        hp = GetComponent<HpSystem>();
    }

    private void Update()
    {
        Interaction();
    }

    private void FixedUpdate()
    {
        Movement();
    }

    private void Interaction()
    {
        //폭탄
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (bombCount > 0)
            {
                //태그가 총알인 오브젝트들 배열 생성
                GameObject[] bullets = GameObject.FindGameObjectsWithTag("Bullet");
                //배열 안에 있는 총알 오브젝트들 하나씩 삭제
                foreach (GameObject bullet in bullets)
                {
                    Destroy(bullet);
                }
                bombCount--;
            }
        }
        
        //체력회복 아이템 사용
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (hpRecoveryCount > 0)
            {
                hpRecoveryCount--;
                hp.TakeDamage(-30);
            }
        }
        
    }

    private void Movement()
    {
        //감속
        float currentSpeed = moveSpeed;
        
        if (Input.GetKey(KeyCode.LeftShift))
        {
            currentSpeed = moveSpeed/2;
        }
        
        //전진
        if (Input.GetKey(KeyCode.W))
        {
            rigid.linearVelocity = transform.up * currentSpeed;
        }
        else
        {
            rigid.linearVelocity = Vector2.zero;
        }
        
        //회전
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(new Vector3(0,0,rotSpeed));
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(new Vector3(0,0,-rotSpeed));
        }
    }
}

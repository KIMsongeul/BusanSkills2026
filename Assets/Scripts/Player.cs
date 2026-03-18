using System;
using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    //이동 
    private float moveSpeed = 3f;
    private float rotSpeed = 2f;

    //폭탄
    private int bombCount = 3;
    
    //아이템 카운트
    private int hpRecoveryItemCount = 0;
    private int invincibleItemCount = 0;
    
    //무적 상태
    private bool isInvincible = false;
    private float invincibleTime = 7f;
    
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
            if (hpRecoveryItemCount > 0)
            {
                hpRecoveryItemCount--;
                hp.TakeDamage(-30);
            }
        }
        
        //무적 아이템 사용
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (invincibleItemCount > 0)
            {
                invincibleItemCount--;
                StartCoroutine(Invincible());
            }
        }
        
    }

    IEnumerator Invincible()
    {
        isInvincible = true;
        yield return new WaitForSeconds(invincibleTime);
        isInvincible = false;
    }

    public bool IsInvincible()
    {
        return isInvincible;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("HpRecoveryItem"))
        {
            hpRecoveryItemCount++;
            Destroy(other.gameObject);
        }

        if (other.CompareTag("InvincibleItem"))
        {
            invincibleItemCount++;
            Destroy(other.gameObject);
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

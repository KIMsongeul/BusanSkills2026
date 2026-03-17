using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float speed = 1f;
    public float rotSpeed = 180f;
    private int damage = 10;

    private Transform player;
    private Collider2D col;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        col = GetComponent<Collider2D>();
        //처음에 충돌 잠깐 비활성화
        col.enabled = false;
        //0.3초 뒤 충돌 활성화
        //왜나면 총알이 생성된 후 바로 적에게 부딪힐 수 있는 변수 제거를 위함
        Invoke("EnableCollider", 0.3f);
        
        //6초 이상 있으면 사라짐
        Destroy(gameObject, 6f);
    }

    private void Update()
    {
        if (player == null)
        {
            return;
        }
        
        //플레이어 방향 계산
        Vector2 dir =  player.position - transform.position;
        dir.Normalize();
        //회전 방향 계산
        float rot = Vector3.Cross(dir, transform.up).z;
        
        transform.Rotate(0,0,-rot * rotSpeed * Time.deltaTime);
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }

    void EnableCollider()
    {
        col.enabled = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        HpSystem hp = other.GetComponent<HpSystem>();

        if (hp != null)
        {
            hp.TakeDamage(damage);
        }
        Destroy(gameObject);
    }
}

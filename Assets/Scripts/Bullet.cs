using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private int damage = 10;

    private void Start()
    {
        //6초 이상 있으면 사라짐
        Destroy(gameObject, 6f);
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

using System;
using UnityEngine;

public class HpSystem : MonoBehaviour
{
    public int maxHp = 0;
    private int currentHp;

    private void Start()
    {
        currentHp = maxHp;
    }

    public void TakeDamage(int damage)
    {
        currentHp -= damage;

        if (currentHp <= 0)
        {
            Destroy(gameObject);
        }
    }
}

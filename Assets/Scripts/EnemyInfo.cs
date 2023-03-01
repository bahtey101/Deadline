using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInfo : MonoBehaviour
{
    private float HP = 75f;
    private float maxHP = 75f;

    public float GetHp()
    {
        return HP / maxHP;
    }

    public void TakeDamage(float value)
    {
        HP -= value;
    }
}

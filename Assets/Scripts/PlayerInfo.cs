using UnityEngine;
using UnityEngine.UI;

public class PlayerInfo : MonoBehaviour
{
    private float HP = 150f;
    private float maxHP = 150f;

    private float mana = 80f;
    private float maxMana = 80f;

    public float GetHp()
    {
        return HP / maxHP;
    }

    public float GetMana()
    {
        return mana / maxMana;
    }

    public void SetHP(float value)
    {
        HP = value > maxHP ? maxHP : value;
    }

    public void SetMana(float value)
    {
        mana = value > maxMana ? maxMana : value;
    }

    public void TakeDamage(float value)
    {
        HP -= value;
    }
}

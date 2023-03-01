using UnityEngine;
using UnityEngine.UI;

public class HPManaBar : MonoBehaviour
{
    public Image healthBar;
    public Image manaBar;

    public PlayerInfo player;

     void Awake()
    {
        healthBar = GameObject.Find("HealthBar").GetComponent<Image>();
        manaBar = GameObject.Find("ManaBar").GetComponent<Image>();

        player = FindObjectOfType<PlayerInfo>();
    }

    void Update() 
    {
        healthBar.fillAmount = player.GetHp();
        manaBar.fillAmount = player.GetMana();
    }
}

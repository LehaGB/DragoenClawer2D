using UnityEngine;

public class PlayerBase : MonoBehaviour
{
    public PlayerAttack playerAttack;
    public PlayerHealth playerHealth;
    public PlayerMovement playerMovement;
    public PlayerMoney playerMoney;

    public static PlayerBase Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
}

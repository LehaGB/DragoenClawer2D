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

    private void Start()
    {
        LoadData();
    }


    public void SaveData()
    {
        PlayerPrefs.SetInt("Money", PlayerBase.Instance.playerMoney.currentCoins);
        PlayerPrefs.SetInt("Attack", PlayerBase.Instance.playerAttack.damage);
        PlayerPrefs.SetFloat("Speed", PlayerBase.Instance.playerMovement.moveSpeed);
        PlayerPrefs.SetInt("MaxHealt", PlayerBase.Instance.playerHealth.maxHealth);
        PlayerPrefs.SetInt("CurrentHealth", PlayerBase.Instance.playerHealth.cuurentHealth);
        PlayerPrefs.Save();
    }

    private void LoadData()
    {
        if (PlayerPrefs.HasKey("Money"))
        {
            playerMoney.currentCoins = PlayerPrefs.GetInt("Money");
        }
        if (PlayerPrefs.HasKey("Attack"))
        {
            playerAttack.damage = PlayerPrefs.GetInt("Attack");
        }
        if (PlayerPrefs.HasKey("Speed"))
        {
            playerMovement.moveSpeed = PlayerPrefs.GetFloat("Speed");
        }
        if (PlayerPrefs.HasKey("MaxHealt"))
        {
            playerHealth.maxHealth = PlayerPrefs.GetInt("MaxHealt");
        }
        if (PlayerPrefs.HasKey("CurrentHealth"))
        {
            playerHealth.cuurentHealth = PlayerPrefs.GetInt("CurrentHealth");
        }
        playerHealth.UpdeteHealthbarUI();
    }
}

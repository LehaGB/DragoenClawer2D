using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMoney : MonoBehaviour
{
    public Text coinText;
    public int currentCoins;

   

    private void Start()
    {

        if (PlayerPrefs.HasKey("Money"))
        {
            currentCoins = PlayerPrefs.GetInt("Money");
        }

        coinText = GameObject.FindGameObjectWithTag("CoinsText").GetComponent<Text>();
        UpdateCoinsCount();
    }

    private void UpdateCoinsCount()
    {
        coinText.text = currentCoins.ToString();
    }

    public void AddCoin(int coinsCount = 1)
    {
        currentCoins = currentCoins + coinsCount;
        UpdateCoinsCount();
    }
}

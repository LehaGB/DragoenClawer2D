using UnityEngine;
using UnityEngine.UI;

public class ByItem : MonoBehaviour
{
    public int price;

    public float speedMultiplier;
    public float damageMultiplier;
    public int hpModifier;

    public Text priceText;


    private void Start()
    {
        UpdatePriceText();
    }


    private void Update()
    {
        UpdatePriceText();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") && price <= PlayerBase.Instance.playerMoney.currentCoins)
        {
            PlayerBase.Instance.playerMoney.AddCoin(-price);

            if(speedMultiplier != 0)
            {
                PlayerBase.Instance.playerMovement.MultiplySpeed(speedMultiplier);
            }
            if(damageMultiplier != 0)
            {
                PlayerBase.Instance.playerAttack.MultiplyDamage(damageMultiplier);
            }

            PlayerBase.Instance.playerHealth.IncreaseMaxHealth(hpModifier);
        }
        UpdatePriceText();
    }

    public void UpdatePriceText()
    {
        if (price > PlayerBase.Instance.playerMoney.currentCoins)
        {
            priceText.color = Color.red;
        }
        if (price <= PlayerBase.Instance.playerMoney.currentCoins)
        {
            priceText.color = Color.green;
        }
        if (PlayerBase.Instance.playerMoney.currentCoins == 0)
        {
            priceText.color = Color.red;
        }
        priceText.text = price.ToString();
    }
}

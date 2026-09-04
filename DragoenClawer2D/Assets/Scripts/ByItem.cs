using UnityEngine;

public class ByItem : MonoBehaviour
{
    public int price;

    public float speedMultiplier;
    public float damageMultiplier;
    public int hpModifier;

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
    }
}

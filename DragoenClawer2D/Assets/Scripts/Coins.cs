using UnityEngine;

public class Coins : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerBase.Instance.playerMoney.AddCoin();
            Destroy(gameObject);
        }
    }
}

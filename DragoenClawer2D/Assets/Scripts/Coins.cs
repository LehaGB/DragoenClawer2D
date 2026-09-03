using UnityEngine;

public class Coins : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerMoney.Instance.AddCoin();
            Destroy(gameObject);
        }
    }
}

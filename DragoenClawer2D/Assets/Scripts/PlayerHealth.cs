using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 3;

    [SerializeField] private int cuurentHealth;

    public void TakeDamge(int damage)
    {
        cuurentHealth -= damage;
    }
}

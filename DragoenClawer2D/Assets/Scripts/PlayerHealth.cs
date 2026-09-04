using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 3;
    public bool isAlive = true;
    public int cuurentHealth;

    public Transform healthbarUI;
    public GameObject hpPrefab;
    public Animator animator;
    public SpriteRenderer spriteRenderer;


    private void Awake()
    {
        cuurentHealth = maxHealth;
        UpdeteHealthbarUI();
    }

    public void TakeDamge(int damage)
    {
        if (isAlive)
        {
            cuurentHealth -= damage;
            UpdeteHealthbarUI();

            if (cuurentHealth <= 0)
            {
                isAlive = false;
                animator.SetTrigger("Die");
            }
        }
    }

    public void UpdeteHealthbarUI()
    {
        foreach(Transform child in healthbarUI)
        {
            Destroy(child.gameObject);
        }

        for (int i = 0; i < cuurentHealth; i++)
        {
            Instantiate(hpPrefab, healthbarUI);
        }
    }

    public void DisablePlayerVisual()
    {
        spriteRenderer.enabled = false;
    }

    public void IncreaseMaxHealth(int hpCount)
    {
        maxHealth += hpCount;
        cuurentHealth += hpCount;
        UpdeteHealthbarUI();
    }
}

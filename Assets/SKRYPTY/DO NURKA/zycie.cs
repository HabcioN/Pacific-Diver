using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class zycie : MonoBehaviour
{
    private Animator animator;
    public GameObject deathEffect;
    public GameObject DeathScreen;

    public int health;
    public int liczbaserc;
    private GameObject player;
    public Image[] serce;
    public Sprite pelne;
    public Sprite puste;

    public Text deathText; 
    void Start()
    {
        player = GameObject.Find("GRACZ");
        deathText = GameObject.Find("DeathText").GetComponent<Text>();
        deathText.enabled = false; 
    }
    void Update()
    {
        if (health > liczbaserc)
        {
            health = liczbaserc;
        }

        for (int i = 0; i < serce.Length; i++)
        {
            if (i < health)
            {
                serce[i].sprite = pelne;
            }
            else
            {
                serce[i].sprite = puste;
            }

            if (i < liczbaserc)
            {
                serce[i].enabled = true;
            }
            else
            {
                serce[i].enabled = false;
            }
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            serce[0].sprite = puste;
            Die();
        }
    }

    void Die()
    {
        Destroy(player);
        deathText.enabled = true; // Pokazujemy tekst po œmierci gracza
        deathText.text = "You died";
        DeathScreen.SetActive(true);
    }
}
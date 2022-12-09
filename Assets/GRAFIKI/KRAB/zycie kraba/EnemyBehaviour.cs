using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyBehaviour : MonoBehaviour
{
    public float Hitpoints;
    public float MaxHitPoints = 5;
    public HealthbarBehaviour Healthbar;

    void Start()
    {
        Hitpoints = MaxHitPoints;
        Healthbar.SetHealth(Hitpoints, MaxHitPoints);


    }
    public void TakeHit(float damage)
    {
        Hitpoints -= damage;
        Healthbar.SetHealth(Hitpoints, MaxHitPoints);

        if (Hitpoints <= 0)
        {
            Destroy(gameObject);
        }



    }
       

   
}

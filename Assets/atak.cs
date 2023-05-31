using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class atak : MonoBehaviour
{
    public int damage = 25;
    void Start()
    {
        
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        zycie gracz = hitInfo.GetComponent<zycie>();
        if (gracz != null)
        {
            gracz.TakeDamage(damage);

            
        }



    }
}

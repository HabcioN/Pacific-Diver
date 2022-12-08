using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NewBehaviourScript : MonoBehaviour
{
    private Vector3 respawnPoint;
    private Rigidbody2D rbBody;
    public float silaSkoku = 350;
    public bool kierunekWPrawo = true;
    private Animator anim;
    private bool naPlatformie = true;
   
   
    public float launchForce;
    public ProjectileBehaviour ProjectilePrefab;
    public Transform LaunchOffset;

    void Start()
    {
        respawnPoint = transform.position;
        rbBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Flip()
    {
        kierunekWPrawo = !kierunekWPrawo;
        Vector3 skala = gameObject.transform.localScale;
        skala.x *= -1;
        gameObject.transform.localScale = skala;
    }

    void Update()
    {
        float ruchPoziomy = Input.GetAxis("Horizontal");


        float ruchPionowy = Input.GetAxis("Vertical");

        rbBody.velocity = new Vector2(ruchPoziomy * 5, rbBody.velocity.y);

        Vector3 skala = gameObject.transform.localScale;
        if (ruchPoziomy < 0 && kierunekWPrawo == true)
        {
            Flip();
        }

        if (ruchPoziomy > 0 && kierunekWPrawo == false)
        {
            Flip();
        }

        if (ruchPoziomy < 0 || ruchPoziomy > 0)
        {
            anim.SetInteger("FazaAnimacji", 1);
        }
        else
        {
            anim.SetInteger("FazaAnimacji", 0);
        }
       
        
        if (Input.GetButtonDown("Fire1") )
        {
            Instantiate(ProjectilePrefab, LaunchOffset.position, transform.rotation);

        }
    
    }

}

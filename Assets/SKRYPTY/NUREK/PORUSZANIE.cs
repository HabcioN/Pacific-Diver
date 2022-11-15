using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PORUSZANIE : MonoBehaviour
{
    private Vector3 respawnPoint;
    private Rigidbody2D rbBody;
    public float silaSkoku = 350;
    public bool kierunekWPrawo = true;
    private Animator anim;
    private bool naPlatformie = true;
    public Transform testerPolozeniaPostaci;
    public LayerMask maskaWarstwyDoTestowania;
    public float launchForce;
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
        naPlatformie = Physics2D.OverlapCircle((Vector2)testerPolozeniaPostaci.position, 0.1f, maskaWarstwyDoTestowania);
        if (Input.GetKeyDown(KeyCode.Space) && naPlatformie == true)
        {
            rbBody.AddForce(new Vector2(0f, silaSkoku));

        }
    }
}

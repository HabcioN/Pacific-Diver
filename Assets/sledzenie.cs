using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sledzenie : MonoBehaviour
{

    public float FollowSpeed = 2f;
    public float yOffset = 1f;
    public Transform postac;

    // Update is called once per frame
    void Update()
    {
        Vector3 newPos = new Vector3(postac.position.x, transform.position.y, -10f);
        transform.position = Vector3.Slerp(transform.position, newPos, FollowSpeed * Time.deltaTime);
    }

}


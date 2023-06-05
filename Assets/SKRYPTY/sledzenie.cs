using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sledzenie : MonoBehaviour
{

    public float followSpeed = 2f;
    public float yOffset = 1f;
    public Transform target;
    public Vector2 minPosition;
    public Vector2 maxPosition;

    private void LateUpdate()
    {
        if (target != null)
        {
            float targetX = Mathf.Clamp(target.position.x, minPosition.x, maxPosition.x);
            float targetY = Mathf.Clamp(target.position.y + yOffset, minPosition.y, maxPosition.y);
            Vector3 newPos = new Vector3(targetX, targetY, transform.position.z);
            transform.position = Vector3.Slerp(transform.position, newPos, followSpeed * Time.deltaTime);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(new Vector3(minPosition.x, minPosition.y, transform.position.z), new Vector3(minPosition.x, maxPosition.y, transform.position.z));
        Gizmos.DrawLine(new Vector3(minPosition.x, maxPosition.y, transform.position.z), new Vector3(maxPosition.x, maxPosition.y, transform.position.z));
        Gizmos.DrawLine(new Vector3(maxPosition.x, maxPosition.y, transform.position.z), new Vector3(maxPosition.x, minPosition.y, transform.position.z));
        Gizmos.DrawLine(new Vector3(maxPosition.x, minPosition.y, transform.position.z), new Vector3(minPosition.x, minPosition.y, transform.position.z));
    }
}


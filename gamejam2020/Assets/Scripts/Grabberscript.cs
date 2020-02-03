using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabberscript : MonoBehaviour
{
    public float distance=2f;
    RaycastHit2D hit;
    public bool grabbed;
    public Transform holdpoint;
    public float throwforce;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            if (!grabbed)
            {
                Physics2D.queriesStartInColliders = false;
                hit = Physics2D.Raycast(transform.position, Vector2.right * transform.localScale.x,distance);

                if (hit.collider != null)
                {
                    grabbed = true;
                }
            }
            else
            {
                grabbed = false;
                if (hit.collider.gameObject.GetComponent<Rigidbody2D>() != null)
                {
                   // hit.collider.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(, 1);
                }
            }
        }
        if (grabbed)
        {
            hit.collider.gameObject.transform.position = holdpoint.position;
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position,transform.position + Vector3.right * transform.localScale.x* distance);
    }
}

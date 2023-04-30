using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock_hit : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (Input.GetMouseButtonDown(0))
            {
                //collision.GetComponent<Player>().m_animator.SetTrigger("Attack");
                collision.GetComponent<Player>().TakeDamage(2);
                Destroy(gameObject);
            }
        }
    }
}

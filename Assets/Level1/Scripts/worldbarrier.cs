using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class worldbarrier : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
     if (collision.gameObject.CompareTag("Player"))
        {
            collision.GetComponent<Player>().WorldDeath();
        }   
    }
}

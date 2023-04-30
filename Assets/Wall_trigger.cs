using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Wall_trigger : MonoBehaviour
{
    public int ans_num;
    public int val;
    public GameObject wall;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (Input.GetMouseButtonDown(0))
            {
                val = collision.GetComponent<Player_heavy>().count_num;
                if (ans_num == val)
                {
                    GameObject.Destroy(wall);
                }
                else
                {
                    collision.GetComponent<Player_heavy>().TakeDamage(2);
                }
            }
        }
    }
}

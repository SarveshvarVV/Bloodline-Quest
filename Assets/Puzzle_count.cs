using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle_count : MonoBehaviour
{
    public int count_num;
    public GameObject wall;
    //public bool reset=false;
    // Start is called before the first frame update
    void Start()
    {
        
    }


    void FixedUpdate()
    {
       if (count_num == 7) {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Lvl_1_puzzle");
            foreach (GameObject enemy in enemies)
                GameObject.Destroy(enemy);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if(Input.GetMouseButtonDown(0))
            {
                count_num++;
                Debug.Log(count_num);
            }
        }
    }
}

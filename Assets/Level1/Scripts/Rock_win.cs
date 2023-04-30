using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock_win : MonoBehaviour
{
    public GameObject Boss;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //public void win()
    //{
    //    GameObject[] enemies = GameObject.FindGameObjectsWithTag("Lvl_1_puzzle");
    //    foreach (GameObject enemy in enemies)
    //        GameObject.Destroy(enemy);
    //}
    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (Input.GetMouseButtonDown(0))
            {
                GameObject[] enemies = GameObject.FindGameObjectsWithTag("Lvl_1_puzzle");
                    foreach (GameObject enemy in enemies)
                        GameObject.Destroy(enemy);
                Instantiate(Boss, new Vector2(230, -2), Boss.transform.rotation);
            }
        }
        
    }
}

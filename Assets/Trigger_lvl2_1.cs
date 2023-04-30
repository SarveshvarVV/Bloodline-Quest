using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger_lvl2_1 : MonoBehaviour
{
    public GameObject wall;
    //public GameObject reset;
    public GameObject count;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D()
    {
        
        Instantiate(wall, new Vector2(168.54f, -4.06f), wall.transform.rotation);
        //Instantiate(reset, new Vector2(149.5f, -12.99789f), wall.transform.rotation);
        Instantiate(count, new Vector2(154.91f, -12.99789f), wall.transform.rotation);

        Destroy(gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public GameObject wall;
    public GameObject rock_hit;
    public GameObject rock_win;

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
        Instantiate(wall, new Vector2 (192, 6), wall.transform.rotation);
        Instantiate(wall, new Vector2 (222, 6), wall.transform.rotation);
        Instantiate(rock_hit, new Vector2(195, -3.63f), wall.transform.rotation);
        Instantiate(rock_hit, new Vector2(198, -3.63f), wall.transform.rotation);
        Instantiate(rock_hit, new Vector2(201, -3.63f), wall.transform.rotation);
        Instantiate(rock_hit, new Vector2(204, -3.63f), wall.transform.rotation);
        Instantiate(rock_hit, new Vector2(207, -3.63f), wall.transform.rotation);
        Instantiate(rock_hit, new Vector2(210, -3.63f), wall.transform.rotation);
        Instantiate(rock_hit, new Vector2(213, -3.63f), wall.transform.rotation);
        Instantiate(rock_win, new Vector2(216, -3.63f), wall.transform.rotation);
        Instantiate(rock_hit, new Vector2(219, -3.63f), wall.transform.rotation);

        Destroy(gameObject);
    }
    
}

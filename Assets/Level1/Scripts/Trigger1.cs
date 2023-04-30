using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger1 : MonoBehaviour
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
        Instantiate(wall, new Vector2 (200, -4.01f), wall.transform.rotation);
        Instantiate(wall, new Vector2 (230, -4.01f), wall.transform.rotation);
        Instantiate(rock_hit, new Vector2(203, -13.64f), wall.transform.rotation);
        Instantiate(rock_hit, new Vector2(206, -13.64f), wall.transform.rotation);
        Instantiate(rock_hit, new Vector2(209, -13.64f), wall.transform.rotation);
        Instantiate(rock_win, new Vector2(212, -13.64f), wall.transform.rotation);
        Instantiate(rock_hit, new Vector2(215, -13.64f), wall.transform.rotation);
        Instantiate(rock_hit, new Vector2(218, -13.64f), wall.transform.rotation);
        Instantiate(rock_hit, new Vector2(221, -13.64f), wall.transform.rotation);
        Instantiate(rock_hit, new Vector2(224, -13.64f), wall.transform.rotation);
        Instantiate(rock_hit, new Vector2(227, -13.64f), wall.transform.rotation);

        Destroy(gameObject);
    }
    
}

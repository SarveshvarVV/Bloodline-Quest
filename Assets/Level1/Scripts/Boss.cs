using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;
using static UnityEditor.ShaderGraph.Internal.KeywordDependentCollection;

public class Boss : MonoBehaviour
{

    private Animator anim;
    public float speed = 2.5f;
    Transform player;
    Rigidbody2D rb;

    public bool isFlipped = false;

    public void LookAtPlayer()
    {
        Vector3 flipped = transform.localScale;
        flipped.z *= -1f;

        if (transform.position.x > player.position.x && isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = false;
        }
        else if (transform.position.x < player.position.x && !isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = true;
        }
    }
    private void Start()
    {
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = anim.GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        Vector2 target = new Vector2(player.position.x, rb.position.y);
        Vector2 newPos = Vector2.MoveTowards(rb.position, target, speed * Time.fixedDeltaTime);
        rb.MovePosition(newPos);
        anim.SetTrigger("Walk");

    }
    
    public void Attack()
    {
        anim.SetTrigger("Attack");
        anim.SetTrigger("Idle");

    }







}
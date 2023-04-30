using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Tilemaps;
using UnityEngine;

public class Test_lizard : MonoBehaviour
{
    #region Public Variables
    public Transform rayCast;
    public LayerMask rayCastMask;
    public float rayCastLength;
    public float attackDistance;
    public float moveSpeed;
    public float timer;
    public Transform leftLimit;
    public Transform rightLimit;
    public Transform attackPoint;
    public float attackRange;
    public int attackDamage;
    public LayerMask playerLayer;
    public GameObject playerObject;

    #endregion

    #region Private Variables
    private int Enemy_health;
    [SerializeField] int Enemy_Max_health;
    private RaycastHit2D hit;
    private Transform target;
    private Animator anim;
    private float distance;
    private bool attackMode;
    private bool inRange;
    private bool cooling;
    private float intTimer;
    private bool is_dead=false;
    #endregion


    // Start is called before the first frame update
    void Awake()
    {
        SelectTarget();
        intTimer = timer;
        anim = GetComponent<Animator>();
    }

    private void Start()
    {
        Enemy_health = Enemy_Max_health;
    }

    // Update is called once per frame
    void Update()
    {
        if (!is_dead)
        {
            if (!attackMode)
            {

                Move();
            }
            if (!InsideofLimits() && !inRange && !anim.GetCurrentAnimatorStateInfo(0).IsName("Attack2"))
            {
                SelectTarget();
            }
            if (inRange)
            {
                hit = Physics2D.Raycast(rayCast.position, transform.right, rayCastLength, rayCastMask);
                RaycastDebugger();
            }
            if (hit.collider != null)
            {
                EnemyLogic();
            }
            else if (hit.collider == null)
            {
                inRange = false;
            }


            if (inRange == false)
            {

                StopAttack();

            }
        }
    }

    void OnTriggerEnter2D(Collider2D trig)
    {
        
        if (trig.gameObject.tag == "Player")
        {
            target = trig.transform;
            inRange = true;
            Flip();
        }     
    }
    
    void EnemyLogic()
    {
        distance = Vector2.Distance(transform.position, target.position);   

        if (distance > attackDistance)
        {
            
            StopAttack();

        }
        else if (attackDistance >= distance && cooling == false)
        {
            Attack();
        }
        if (cooling)
        {
            Cooldown();
            anim.SetBool("Attack2", false);
        }
    }
    void Move()
    {
        anim.SetBool("Run", true);

        if (!anim.GetCurrentAnimatorStateInfo(0).IsName("Attack2"))
        {
            Vector2 targetPosition = new Vector2(target.position.x, transform.position.y);
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

        }
    }
    void Attack()
    {
        timer = intTimer;
        attackMode = true;

        anim.SetBool("Run", false);
        anim.SetBool("Attack2",true);
        if (playerObject.GetComponent<Player>().health <= 0)
        {
            anim.SetBool("Edle", true);
        }
        
        Collider2D[] hit_box = Physics2D.OverlapCircleAll(attackPoint.position, attackRange,playerLayer);

        foreach(Collider2D player in hit_box)
        {
            player.GetComponent<Player>().TakeDamage(attackDamage);
            
        }

    }

    public void Enemy_TakeDamage(int damage)
    {
        Enemy_health -= damage;
        anim.SetBool("Hurt", true);

        if(Enemy_health <= 0)
        {
            Die();
            is_dead = true;
        }
    }

    void Die()
    {
        anim.SetBool("Death", true);
    }
    void Cooldown()
    {
        timer -= Time.deltaTime;

        if (timer <= 0 && cooling && attackMode)
        {
            cooling = false;
            timer = intTimer;
        }
    }
    void StopAttack()
    {
        cooling = false;
        attackMode = false;
        anim.SetBool("Attack2", false);
    }

    void RaycastDebugger()
    {
        if (distance > attackDistance)
        {
            Debug.DrawRay(rayCast.position, transform.right * rayCastLength, Color.red);
        }
        else if (attackDistance > distance)
        {
            Debug.DrawRay(rayCast.position, transform.right * rayCastLength, Color.green);
        }

    }
    public void TriggerCooling()
    {
        cooling = true;
    }

    private bool InsideofLimits()
    {
        return transform.position.x > leftLimit.position.x && transform.position.x < rightLimit.position.x;     
    }
    public void SelectTarget() 
    {
        float  distanceToLeft = Vector2.Distance( transform.position, leftLimit.position);
        float distanceToRight = Vector2.Distance(transform.position, rightLimit.position);

        if(distanceToLeft > distanceToRight)
        {
            target = leftLimit;
            
        }
        else
        {
            target = rightLimit;
            
        }
        Flip();
    }
    public void Flip()
    {
        Vector3 rotation = transform.eulerAngles;
        if(transform.position.x > target.position.x)
        {
            rotation.y = 180f;

        }
        else
        {
            rotation.y = 0f;

        }
        transform.eulerAngles = rotation;
    }
       
}

using UnityEngine;
using System.Collections;
using System;

public class Player_heavy : MonoBehaviour {

    [SerializeField] float      m_speed = 4.0f;
    [SerializeField] float      m_jumpForce = 7.5f;

    public int count_num;

    private Animator            m_animator;
    private Rigidbody2D         m_body2d;
    //private Sensor_Bandit       m_groundSensor;
    private bool                m_grounded = false;

    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask groundLayer;

    private float safeTime;
    public float startSafeTime;
    private float timeBtwShots;
    public float startTimeBtwShots;

    public Transform attackPoint;
    public float attackRange;
    public LayerMask enemyLayer;
    public int attackDamage;
    public float attackRate = 2f;
    float nextAttackTime = 0f;

    private bool                m_combatIdle = false;
    public bool                m_isDead = false;

    public int health;
    public int maxHealth;
    public int mainHealth;
    public GameObject losePanel;
    //public int maxHealth = 100;


    // Use this for initialization
    void Start () {
        health = maxHealth;
        mainHealth = maxHealth;
        m_animator = GetComponent<Animator>();
        m_body2d = GetComponent<Rigidbody2D>();
        //m_groundSensor = transform.Find("GroundSensor").GetComponent<Sensor_Bandit>();
    }

    // Update is called once per frame
    void Update()
    {
        ////Check if character just landed on the ground
        if (!m_grounded)
        {
            //m_animator.SetTrigger("Jump");
            m_animator.SetBool("Grounded", m_grounded);
        }

        ////Check if character just started falling
        if (m_grounded)
        {
            m_animator.SetBool("Grounded", m_grounded);
        }

        if (safeTime > 0)
        {
            safeTime -= Time.deltaTime;
        }

        // -- Handle Animations --
        //Death
        //if (Input.GetKeyDown("e"))
        //{
        //    if (!m_isDead)
        //        m_animator.SetTrigger("Death");
        //    else
        //        m_animator.SetTrigger("Recover");

        //    m_isDead = !m_isDead;
        //}

        //Hurt
        if (m_isDead)
        {
            gameObject.tag = "Dead";
        }
        if (mainHealth <= 0)
        {
            m_isDead = true;
            m_animator.SetTrigger("Death");
            // add scene trans
        }
        if (health <= 0)
        {
            losePanel.SetActive(true);
            m_isDead = true;
            m_animator.SetTrigger("Death");
        }

        //Change between idle and combat idle
        //else if (Input.GetKeyDown("f"))
        //    m_combatIdle = !m_combatIdle;

        if (m_isDead != true)
        {
            // -- Handle input and movement --
            float inputX = Input.GetAxis("Horizontal");

            // Swap direction of sprite depending on walk direction
            if (inputX > 0)
                transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
            else if (inputX < 0)
                transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);

            // Move
            m_body2d.velocity = new Vector2(inputX * m_speed, m_body2d.velocity.y);

            //Set AirSpeed in animator
            m_animator.SetFloat("AirSpeed", m_body2d.velocity.y);

            m_grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
            //Attack
            if (Time.time >= nextAttackTime)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    Attack();
                    nextAttackTime = Time.time + 1f / attackRate;
                }

                //Jump
                if ((Input.GetKeyDown("space")) && (m_grounded))
                {
                    m_animator.SetTrigger("Jump");
                    //m_grounded = false;
                    //m_animator.SetBool("Grounded", m_grounded);
                    m_body2d.velocity = new Vector2(m_body2d.velocity.x, m_jumpForce);
                    //m_groundSensor.Disable(1.35f);
                }
                
                //Run
                else if (Mathf.Abs(inputX) > Mathf.Epsilon)
                    m_animator.SetInteger("AnimState", 2);

                //Combat Idle
                else if (m_combatIdle)
                    m_animator.SetInteger("AnimState", 1);

                //Idle
                else
                    m_animator.SetInteger("AnimState", 0);
            }
        }
    }
    public void TakeDamage(int damage)
    {
        if (safeTime <= 0)
        {
            health -= damage;
            m_animator.SetTrigger("Hurt");
            safeTime = startSafeTime;
        }
        if(health<=0)
        {
            m_animator.SetBool("Death", true);
            losePanel.SetActive(true);
            m_isDead = true;
        }
    }

    void Attack()
    {
        m_animator.SetTrigger("Attack");
        
        Collider2D[] hit_box = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);
        foreach (Collider2D player in hit_box)
        {
            player.GetComponent<test_lizard>().TakeEnemyDamage(attackDamage);
            
        }
    }
    public void WorldDeath()
    {
        health = 0;
    }
    public void TakeMainDamage(int mainDamage)
    {
        mainHealth -= mainDamage;
        m_animator.SetTrigger("Hurt");
        if (mainHealth <= 0)
        {
            health = 1;
            m_animator.SetBool("Death", true);
        }
    }
    public void Recover()
    {
        m_animator.SetTrigger("Recover");

    }

    public void count_update()
    {
        count_num++;
        Debug.Log(count_num);
        if(count_num == 9) { 
            count_num= 0;
        }
    }

}

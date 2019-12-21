using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour
{

    [SerializeField] float m_speed = 1.0f;
    [SerializeField] float m_jumpForce = 2.0f;

    private Animator m_animator;
    private Rigidbody2D m_body2d;
    private Sensor_Bandit m_groundSensor;
    private bool m_grounded = false;
    private bool m_combatIdle = false;
    private bool m_isDead = false;

    public int health = 100;

    // Use this for initialization
    void Start()
    {
        m_animator = GetComponent<Animator>();
        m_body2d = GetComponent<Rigidbody2D>();
        m_groundSensor = transform.Find("GroundSensor").GetComponent<Sensor_Bandit>();
    }

    // Update is called once per frame
    void Update()
    {
        //Check if character just landed on the ground
        if (!m_grounded && m_groundSensor.State())
        {
            m_grounded = true;
            m_animator.SetBool("Grounded", m_grounded);
        }

        //Check if character just started falling
        if (m_grounded && !m_groundSensor.State())
        {
            m_grounded = false;
            m_animator.SetBool("Grounded", m_grounded);
        }

        // -- Handle input and movement --
        float moveX = -1;

        // Swap direction of sprite depending on walk direction
        if (moveX > 0)
            transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        else if (moveX < 0)
            transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);

        // Move
        

        m_body2d.velocity = new Vector2(moveX * m_speed, m_body2d.velocity.y);


        //Set AirSpeed in animator
        m_animator.SetFloat("AirSpeed", m_body2d.velocity.y);

       // m_animator.SetTrigger("Run");
        // -- Handle Animations --
        //Death

        //Hurt
        //else if (Input.GetKeyDown("q"))
        // m_animator.SetTrigger("Hurt");

        //Attack
       

        ////Change between idle and combat idle
        // else if (Input.GetKeyDown("f"))
        //  m_combatIdle = !m_combatIdle;

        //Jump
            
        }

       
}


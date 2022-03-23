using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Mover
{
    //Experience
    public int m_xpValue = 1;

    //Logic
    public float m_triggerLength = 1.0f;
    public float m_chaseLenght = 5.0f;

    private bool m_isChasing = false;
    private bool m_collidingWithPlayer = false;
    private Transform m_playerTransform;
    private Vector3 m_startingPosition;

    //Enemy weapon hitbox
    private BoxCollider2D m_hitbox;
    private Collider2D[] m_hits = new Collider2D[10];

    protected override void Start()
    {
        base.Start();
        m_playerTransform = GameManager.m_instance.player.transform;
        m_startingPosition = transform.position;
        m_hitbox = transform.GetChild(0).GetComponent<BoxCollider2D>();
    }

    private void FixedUpdate()
    {
        //Is the player in range
        if (Vector3.Distance(m_playerTransform.position, m_startingPosition) < m_chaseLenght)
        {
            m_isChasing = Vector3.Distance(m_playerTransform.position, m_startingPosition) < m_triggerLength;

            if (m_isChasing)
            {
                if (!m_collidingWithPlayer)
                {
                    UpdateMotor((m_playerTransform.position - transform.position).normalized);
                }
            }
            else
            {
                UpdateMotor(m_startingPosition - transform.position);
            }
        }
        else
        {
            UpdateMotor(m_startingPosition - transform.position);
            m_isChasing = false;
        }

        //Check for collider overlap
    }

}

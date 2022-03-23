using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Mover : Fighter
{
    protected BoxCollider2D m_boxCollider;
    protected Vector3 m_moveDelta;
    protected RaycastHit2D m_hit;

    protected float m_moveHorizontal;
    protected float m_moveVertical;
    protected float m_speedFactor = 0.72f;

    protected float m_YSpeed = 0.75f;
    protected float m_XSpeed = 1.0f;



    protected virtual void Start()
    {
        m_boxCollider = GetComponent<BoxCollider2D>();
    }

    protected virtual void UpdateMotor(Vector3 input)
    {
        //Reset move delta
        m_moveDelta = new Vector3 (input.x * m_XSpeed, input.y * m_YSpeed, 0);

        //Swap sprite direction left-right
        if (m_moveDelta.x > 0)
        {
            transform.localScale = Vector3.one;
        }
        else if (m_moveDelta.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        //Make sure we can move in this direction
        m_hit = Physics2D.BoxCast(transform.position, m_boxCollider.size, 0, new Vector2(0, m_moveDelta.y), Mathf.Abs(m_moveDelta.y * Time.deltaTime), LayerMask.GetMask("Characters", "Blocking"));
        if (m_hit.collider == null)
        {
            //Make this thing move
            transform.Translate(0, m_moveDelta.y * Time.fixedDeltaTime * m_speedFactor, 0);
        }

        m_hit = Physics2D.BoxCast(transform.position, m_boxCollider.size, 0, new Vector2(m_moveDelta.x, 0), Mathf.Abs(m_moveDelta.x * Time.deltaTime), LayerMask.GetMask("Characters", "Blocking"));
        if (m_hit.collider == null)
        {
            //Make this thing move
            transform.Translate(m_moveDelta.x * Time.fixedDeltaTime * m_speedFactor, 0, 0);
        }
    }
}

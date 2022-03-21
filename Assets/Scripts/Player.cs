using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Fighter
{
    private BoxCollider2D m_boxCollider;
    private Vector3 m_moveDelta;
    private RaycastHit2D m_hit;

    private float m_moveHorizontal;
    private float m_moveVertical;
    private float m_speedFactor = 0.72f;
    
    private void Start()
    {
        m_boxCollider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        m_moveHorizontal = Input.GetAxisRaw("Horizontal");
        m_moveVertical = Input.GetAxisRaw("Vertical");
    }


    private void FixedUpdate()
    {
        //Reset move delta
        m_moveDelta = new Vector3(m_moveHorizontal, m_moveVertical, 0);

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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //https://www.youtube.com/watch?v=b8YUfee_pzc
    //00:37:18

    private BoxCollider2D m_boxCollider;
    private Vector3 m_moveDelta;
    private float m_moveHorizontal;
    private float m_moveVertical;

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
        m_moveDelta = new Vector3 (m_moveHorizontal, m_moveVertical, 0);

        //Swap sprite direction left-right
        if (m_moveDelta.x > 0)
        {
            transform.localScale = Vector3.one;
        }
        else if (m_moveDelta.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        //Make this thing move
        transform.Translate(m_moveDelta * Time.fixedDeltaTime);
    }
}

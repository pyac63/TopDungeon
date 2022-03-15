using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collidable : MonoBehaviour
{
    public ContactFilter2D m_filter;
    private BoxCollider2D m_boxCollider;
    private Collider2D[] m_hits = new Collider2D[10];

    protected virtual void Start()
    {
        m_boxCollider = GetComponent<BoxCollider2D>();
    }

    protected virtual void Update()
    {
        //Check for collision
        m_boxCollider.OverlapCollider(m_filter, m_hits);
        for (int i = 0; i < m_hits.Length; i++)
        {
            if (m_hits[i] == null)
            {
                continue;
            }

            OnCollide(m_hits[i]);

            //Cleaning array
            m_hits[i] = null;

        }
    }

    protected virtual void OnCollide(Collider2D collider)
    {
        Debug.Log("OnCollide() was not implemented in " + this.name);
    }
}

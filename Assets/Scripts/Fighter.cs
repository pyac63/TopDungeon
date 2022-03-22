using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighter : MonoBehaviour
{
    public int m_hitPoint = 10;
    public int m_maxHitpPoint = 10;
    public float m_pushRecoverySpeed = 0.2f;

    protected float m_immuneTime = 1.0f;
    protected float m_lastImmune;

    protected Vector3 m_pushDirection;

    // All fighters can ReceiveDamage() / Die()

    protected virtual void ReceiveDamage (Damage dmg)
    {
        if(Time.time - m_lastImmune > m_immuneTime)
        {
            m_lastImmune = Time.time;
            m_hitPoint -= dmg.m_damageAmount;
            m_pushDirection = (transform.position - dmg.m_origin).normalized * dmg.m_damagePushForce;

            GameManager.m_instance.ShowText(dmg.m_damageAmount.ToString(), 20, Color.red, transform.position, Vector3.zero, 0.5f);

            if (m_hitPoint <= 0)
            {
                m_hitPoint = 0;
                Death();
            }
        }
    }

    protected virtual void Death()
    {

    }
}

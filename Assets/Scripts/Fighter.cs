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
}

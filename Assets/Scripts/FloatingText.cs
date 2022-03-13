using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloatingText
{
    public bool m_active;
    public GameObject m_go;
    public Text m_txt;
    public Vector3 m_motion;
    public float m_duration;
    public float m_lastShown;

    public void Show()
    {
        m_active = true;
        m_lastShown = Time.time;
        m_go.SetActive(m_active);
    }

    public void Hide()
    {
        m_active = false;
        m_go.SetActive(m_active);
    }

    public void UpdateFloatingText()
    {
        if (!m_active)
        {
            return;
        }

        if (Time.time - m_lastShown > m_duration)
        {
            Hide();
        }
        m_go.transform.position += m_motion * Time.deltaTime;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloatingTextManager : MonoBehaviour
{
    public GameObject m_textContainer;
    public GameObject m_textPrefab;

    private List<FloatingText> m_floatingTexts = new List<FloatingText>();

    private void Update()
    {
        foreach (FloatingText text in m_floatingTexts)
        {
            text.UpdateFloatingText();
        }
    }

    public void Show(string msg, int fontSize, Color color, Vector3 position, Vector3 motion, float duration)
    {
        FloatingText floatingText = GetFloatingText();

        floatingText.m_txt.text = msg;
        floatingText.m_txt.fontSize = fontSize;
        floatingText.m_txt.color = color;
        floatingText.m_go.transform.position = Camera.main.WorldToScreenPoint(position);
        floatingText.m_motion = motion;
        floatingText.m_duration = duration;

        floatingText.Show();

    }

    private FloatingText GetFloatingText()
    {
        FloatingText txt = m_floatingTexts.Find(t => !t.m_active);

        if (txt == null)
        {
            txt = new FloatingText();
            txt.m_go = Instantiate(m_textPrefab);
            txt.m_go.transform.SetParent(m_textContainer.transform);
            txt.m_txt = txt.m_go.GetComponent<Text>();

            m_floatingTexts.Add(txt);
        }

        return txt;
    }
}

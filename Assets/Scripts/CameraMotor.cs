using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMotor : MonoBehaviour
{
    public Transform m_lookAt;
    public float m_boundX = 0.15f;
    public float m_boundY = 0.05f;

    private void LateUpdate()
    {
        Vector3 delta = Vector3.zero;


        //Check if inside the bounds of the X axis
        float deltaX = m_lookAt.position.x - transform.position.x;
        if (deltaX > m_boundX || deltaX < -m_boundX)
        {
            if (transform.position.x < m_lookAt.position.x)
            {
                delta.x = deltaX - m_boundX;
            }
            else
            {
                delta.x = deltaX + m_boundX;
            }
        }


        //Check if inside the bounds of the  axis
        float deltaY = m_lookAt.position.y - transform.position.y;
        if (deltaY > m_boundY || deltaY < -m_boundY)
        {
            if (transform.position.y < m_lookAt.position.y)
            {
                delta.y = deltaY - m_boundY;
            }
            else
            {
                delta.y = deltaY + m_boundY;
            }
        }

        transform.position += new Vector3(delta.x, delta.y, 0);
    }
}

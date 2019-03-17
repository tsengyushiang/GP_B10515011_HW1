using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float m_moveSpeed = 2;
    [SerializeField] private float m_turnSpeed = 200;
    private float m_currentV = 0;
    private float m_currentH = 0;

    public float speedH = 2.0f;
    public float speedV = 2.0f;

    private float yaw = 0.0f;
    private float pitch = 0.0f;


    private readonly float m_interpolation = 10;

    void Update()
    { 
        yaw += speedH * Input.GetAxis("Mouse X");
        pitch -= speedV * Input.GetAxis("Mouse Y");

        transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);

        if (Input.GetKey(KeyCode.Space)) {
            transform.position += Vector3.up;
        }

        float vw = Input.GetAxis("Vertical");
        float hw = Input.GetAxis("Horizontal");

        m_currentV = Mathf.Lerp(m_currentV, vw, Time.deltaTime * m_interpolation);
        m_currentH = Mathf.Lerp(m_currentH, hw, Time.deltaTime * m_interpolation);

        transform.position += transform.forward * m_currentV * m_moveSpeed * Time.deltaTime;
        transform.Rotate(0, m_currentH * m_turnSpeed * Time.deltaTime, 0);

    }
}
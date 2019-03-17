using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class ZombieCharacterControl : MonoBehaviour
{
    public Text HintText;
    private bool movealbe = true;
    private enum ControlMode
    {
        Tank,
        Direct
    }
    public GameObject Axe;

    [SerializeField] private float m_moveSpeed = 2;
    [SerializeField] private float m_turnSpeed = 200;

    [SerializeField] private Animator m_animator;
    [SerializeField] private Rigidbody m_rigidBody;

    [SerializeField] private ControlMode m_controlMode = ControlMode.Tank;

    private float m_currentV = 0;
    private float m_currentH = 0;

    private readonly float m_interpolation = 10;

    private Vector3 m_currentDirection = Vector3.zero;

    void Awake()
    {
        if (!m_animator) { gameObject.GetComponent<Animator>(); }
        if (!m_rigidBody) { gameObject.GetComponent<Animator>(); }
        Axe.SetActive(false);
    }

    public void dead() {
        if (movealbe == false) return;
        transform.Find("deadLight").gameObject.SetActive(true);
        m_animator.Play("zombie_death_standing");
        movealbe = false;
        HintText.text = "GAMEOVER";
        GetComponent<AudioSource>().Play();
    }

    void FixedUpdate()
    {
        if (movealbe == false) return;
        if (transform.position.y < 1)
        {
            dead();
            return;
        }
        if (Input.GetKey(KeyCode.Space))
        {
            m_animator.Play("zombie_attack");
        }

        switch (m_controlMode)
        {
            case ControlMode.Direct:
                DirectUpdate();
                break;

            case ControlMode.Tank:
                TankUpdate();
                break;

            default:
                Debug.LogError("Unsupported state");
                break;
        }
    }

    private void TankUpdate()
    {
        float v = Input.GetAxis("Vertical");
        float h = Input.GetAxis("Horizontal");

        m_currentV = Mathf.Lerp(m_currentV, v, Time.deltaTime * m_interpolation);
        m_currentH = Mathf.Lerp(m_currentH, h, Time.deltaTime * m_interpolation);

        transform.position += transform.forward * m_currentV * m_moveSpeed * Time.deltaTime;
        transform.Rotate(0, m_currentH * m_turnSpeed * Time.deltaTime, 0);

        m_animator.SetFloat("MoveSpeed", m_currentV);
    }

    private void DirectUpdate()
    {
        float v = Input.GetAxis("Vertical");
        float h = Input.GetAxis("Horizontal");

        Transform camera = Camera.main.transform;

        m_currentV = Mathf.Lerp(m_currentV, v, Time.deltaTime * m_interpolation);
        m_currentH = Mathf.Lerp(m_currentH, h, Time.deltaTime * m_interpolation);

        Vector3 direction = camera.forward * m_currentV + camera.right * m_currentH;

        float directionLength = direction.magnitude;
        direction.y = 0;
        direction = direction.normalized * directionLength;

        if (direction != Vector3.zero)
        {
            m_currentDirection = Vector3.Slerp(m_currentDirection, direction, Time.deltaTime * m_interpolation);

            transform.rotation = Quaternion.LookRotation(m_currentDirection);
            transform.position += m_currentDirection * m_moveSpeed * Time.deltaTime;

            m_animator.SetFloat("MoveSpeed", direction.magnitude);
        }
    }  

    private void OnTriggerEnter(Collider other)
    {
        if (movealbe == false) return;
        hintword TouchWord = other.gameObject.GetComponent<hintword>();

        if (TouchWord != null) {
            HintText.text = TouchWord.hintWord;            
        }
        if (other.gameObject.name == "GetAxe") {
            Destroy(other.gameObject);
            Axe.SetActive(true);
            transform.GetChild(0).GetComponent<AudioSource>().Play();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        hintword TouchWord = other.gameObject.GetComponent<hintword>();

        if (other.gameObject.name == "GetAxe")
        {
            return;
        }
        else if (TouchWord != null)
        {
            HintText.text = "";
        }
    }
}

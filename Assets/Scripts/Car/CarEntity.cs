using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarEntity : MonoBehaviour
{
    //wheel control
    public GameObject wheelFR;
    public GameObject wheelFL;
    public GameObject wheelBL;
    public GameObject wheelBR;
    float m_FrontWheelAngle = 0;
    const float WHEEL_ANGLE_LIMIT = 45f;
    public float turnAngularVelocity = 15f;
    //linear motion control
    float m_Velocity;
    public float acceleraion = 5f;
    public float deceleraion = 6f;
    public float maxVelocity = 50f;
    float m_DeltaMovement;
    float CarLength = 1f;
    //color control when collided
    [SerializeField] SpriteRenderer[] m_Renderers = new SpriteRenderer[5];
    public CheckPoint ch;
    //parking grades
    public int point = 100;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //linear diplacement control
        if (Input.GetKey(KeyCode.UpArrow))
        {
            m_Velocity = Mathf.Min(maxVelocity, m_Velocity + Time.fixedDeltaTime * acceleraion);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            m_Velocity = Mathf.Max(-0.5f* maxVelocity, m_Velocity - Time.fixedDeltaTime * deceleraion);
        }
        if (Input.GetKey(KeyCode.Space))
        {
            m_Velocity = 0;
        }
        m_DeltaMovement = m_Velocity * Time.fixedDeltaTime;
        //z-axis rotation control
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            m_FrontWheelAngle = Mathf.Clamp(
                m_FrontWheelAngle + Time.fixedDeltaTime * turnAngularVelocity, -WHEEL_ANGLE_LIMIT, WHEEL_ANGLE_LIMIT);
            UpdateWheel();
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            m_FrontWheelAngle = Mathf.Clamp(
                m_FrontWheelAngle - Time.fixedDeltaTime * turnAngularVelocity, -WHEEL_ANGLE_LIMIT, WHEEL_ANGLE_LIMIT);
            UpdateWheel();
        }
        //update position&rotation
        this.transform.Rotate(0f, 0f, 1 / CarLength * Mathf.Tan(Mathf.Deg2Rad * m_FrontWheelAngle) * Mathf.Rad2Deg * m_DeltaMovement);
        this.transform.Translate(Vector3.right * m_DeltaMovement);
    }
    void UpdateWheel()
    {
        Vector3 localEulerAngles = new Vector3(0f, 0f, m_FrontWheelAngle);
        wheelFR.transform.localEulerAngles = localEulerAngles;
        wheelFL.transform.localEulerAngles = localEulerAngles;
    }
    void ResetColor()
    {
        ChangeColor(Color.white);
    }
    void ChangeColor(Color color)
    {
        foreach(SpriteRenderer r in m_Renderers)
        {
            r.color = color;
        }
    }
    void Stop()
    {
        m_Velocity = 0;
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        Stop();
        point -= 12;
        Debug.Log("Oops! Collide with something! Your grade now:"+point);
        if (point < 70)
        {
            Debug.Log("You have failed! Poor driver!");
        }
        ChangeColor(Color.red);
    }
    void OnCollisionStay2D(Collision2D collision)
    {
        Stop();
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        ResetColor();
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        CheckPoint checkPoint = collision.gameObject.GetComponent<CheckPoint>();
        if (checkPoint ==ch)
        {
            ChangeColor(Color.green);
            this.Invoke("ResetColor", 0.9f);
        }
    }
    void Update()
    {
        var shadow = Resources.Load<GameObject>("clone");
        var fog = Resources.Load<GameObject>("fog");
        GameObject.Instantiate(shadow, this.gameObject.transform.position,this.gameObject.transform.rotation);
        GameObject.Instantiate(fog, this.gameObject.transform.position+Random.insideUnitSphere+new Vector3(-1,0,0), Quaternion.identity);
    }
}

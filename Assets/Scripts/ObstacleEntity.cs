using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleEntity : MonoBehaviour
{
    SpriteRenderer m_Target;
    // Start is called before the first frame update
    void Start()
    {
        m_Target = this.GetComponent<SpriteRenderer>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        m_Target.color = Color.red;
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        m_Target.color = Color.white;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrows : MonoBehaviour
{
    [SerializeField] SpriteRenderer[] m_Renderers = new SpriteRenderer[4];
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.DownArrow))
        {
            m_Renderers[0].color = Color.blue;
        }
        else
        {
            m_Renderers[0].color = Color.white;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            m_Renderers[1].color = Color.blue;
        }
        else
        {
            m_Renderers[1].color = Color.white;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            m_Renderers[2].color = Color.blue;
        }
        else
        {
            m_Renderers[2].color = Color.white;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            m_Renderers[3].color = Color.blue;
        }
        else
        {
            m_Renderers[3].color = Color.white;
        }
    }
}

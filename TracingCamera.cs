using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TracingCamera : MonoBehaviour
{
    public GameObject targetObject;
    public float MOVING_THRESHOLD = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    /*void Update()
    {
        Vector3 deltaPos = targetObject.transform.position - this.transform.position;
        Vector3 adjust = deltaPos * 0.9f * Time.deltaTime;

        this.transform.position += new Vector3(adjust.x, adjust.y, 0);
    }*/
    private void LateUpdate()
    {
        Vector2 deltaPos = -targetObject.transform.position + this.transform.position;
        if (deltaPos.magnitude > MOVING_THRESHOLD)
        {
            deltaPos.Normalize();
            Vector2 adjust = new Vector2(targetObject.transform.position.x, targetObject.transform.position.y) +  deltaPos * MOVING_THRESHOLD;
            this.transform.position = new Vector3(adjust.x, adjust.y, this.transform.position.z);
        }
    }
}

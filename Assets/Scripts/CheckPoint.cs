using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    //放入要移動的車子跟追蹤相機
    public GameObject Car;
    public GameObject Camera;
    //塞自己的Render
    public SpriteRenderer r;
    //指定要轉移處的x座標，例如要到(50,0),則offset=50;
    public float offset;
    void OnTriggerEnter2D(Collider2D collision)
    {
        r.color = Color.cyan;
        Car.transform.position=new Vector3(offset,0,Car.transform.position.z);
        Camera.transform.position=new Vector3(offset, 0, Camera.transform.position.z);
        Debug.Log("Change floor \n");
        //GameObject.Destroy(this.gameObject);
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        r.color = Color.white;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

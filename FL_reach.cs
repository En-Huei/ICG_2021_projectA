using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FL_reach : MonoBehaviour
{
    //掛在左上的偵測圖樣!
    public FLBR_reach Dectector;
    public Collider2D FL_wheel;
    public Collider2D BR_wheel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == FL_wheel|| collision == BR_wheel)
        {
            //wheel reach the front left corner
            Dectector.FL_check = 1;
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision == FL_wheel || collision == BR_wheel)
        {
            //wheel exit the front left corner
            Dectector.FL_check = 0;
        }
    }
}

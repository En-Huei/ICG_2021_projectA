using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FLBR_reach : MonoBehaviour
{
    //判定:在左左右右，或是前前後後頭痛過後，決定轉用對角檢測
    //考慮簡便性，檢查左前輪跟右後輪就好，當兩輪同時觸碰左前線跟後線時代表停好
    //左前線跟右前線的圖像如同"「」"一般
    //record finish time
    float time;
    //check whether wheel is reaching
    public int FL_check = 0, BR_check = 0;
    // Start is called before the first frame update
    void Start()
    {
        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
        time = Time.time;
        if (FL_check ==1&&BR_check==1)
        {
            Debug.Log("Congraduation! Finish time: " + time);
            UnityEditor.EditorApplication.isPlaying = false;
        }
    }
}

using UnityEngine;
using System.Collections.Generic;
using System.Collections;


public class PlayerController : MonoBehaviour
{
    TimingManager thetimingManager;
    void Start()
    {
        thetimingManager = FindObjectOfType<TimingManager>();    // 타이밍 매니저 컴포넌트 가져오기 
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            thetimingManager.CheckTiming(); //스페이스바 누르며 체크타이밍 함수 실행 
        }  
    }

}

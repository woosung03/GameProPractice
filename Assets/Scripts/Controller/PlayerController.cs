using UnityEngine;
using System.Collections.Generic;
using System.Collections;


public class PlayerController : MonoBehaviour
{
    TimingManager thetimingManager;
    void Start()
    {
        thetimingManager = FindObjectOfType<TimingManager>();    // Ÿ�̹� �Ŵ��� ������Ʈ �������� 
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            thetimingManager.CheckTiming(); //�����̽��� ������ üũŸ�̹� �Լ� ���� 
        }  
    }

}

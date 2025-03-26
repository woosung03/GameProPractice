using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class Note : MonoBehaviour
{
    public float noteSpeed = 400; //노트 이동 속도

    UnityEngine.UI.Image noteImage;

    void Start()
    {
        noteImage = GetComponent<UnityEngine.UI.Image>();
    }

    
    void Update()
    {
        transform.localPosition += Vector3.right * noteSpeed * Time.deltaTime; //노트 이동 스피드를 400으로 설정
    }

    public void HideNote()
    {
        noteImage.enabled = false;
    }
}

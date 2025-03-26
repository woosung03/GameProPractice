using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class Note : MonoBehaviour
{
    public float noteSpeed = 400; //��Ʈ �̵� �ӵ�

    UnityEngine.UI.Image noteImage;

    void Start()
    {
        noteImage = GetComponent<UnityEngine.UI.Image>();
    }

    
    void Update()
    {
        transform.localPosition += Vector3.right * noteSpeed * Time.deltaTime; //��Ʈ �̵� ���ǵ带 400���� ����
    }

    public void HideNote()
    {
        noteImage.enabled = false;
    }
}

using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class CenterFlame : MonoBehaviour //����� �÷��̾�
{
    AudioSource MyAudio;
    bool musicStart = false; // ���� ���� Ȯ��
    private void Start()
    {
        MyAudio = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!musicStart) // false�϶��� ���� ����
        {
            if (collision.CompareTag("Note")) //��Ʈ�� �����÷��ӿ� ������ ���� ����
            {
                MyAudio.Play();
                musicStart = true;
            }
        }
    }
}

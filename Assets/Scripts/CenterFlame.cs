using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class CenterFlame : MonoBehaviour //오디오 플레이어
{
    AudioSource MyAudio;
    bool musicStart = false; // 음악 시작 확인
    private void Start()
    {
        MyAudio = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!musicStart) // false일때만 음악 시작
        {
            if (collision.CompareTag("Note")) //노트가 센터플레임에 닿으면 음악 시작
            {
                MyAudio.Play();
                musicStart = true;
            }
        }
    }
}

using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class EffectManager : MonoBehaviour
{
    [SerializeField] Animator noteHitAnimator = null; //��Ʈ ��Ʈ �ִϸ����ͺ���
    string hit = "Hit"; //�Ķ���� ��Ʈ

    [SerializeField] Animator judgmentAnimator = null; //���� �ִϸ����� ����
    [SerializeField] UnityEngine.UI.Image judgmentImage = null; //���� �̹��� ����
    [SerializeField] Sprite[] judgementSprite = null;   // ���� ����� ���� �̹��� ��������Ʈ
    public void JudgmentEffect(int p_num)
    {
        judgmentImage.sprite = judgementSprite[p_num]; // ���� �̹��� ����
        judgmentAnimator.SetTrigger(hit); //���� �ִϸ����� 
    }
    public void NoteHitEffect() //��Ʈ ��Ʈ ����Ʈ
    {
        noteHitAnimator.SetTrigger(hit);
    }
   
}

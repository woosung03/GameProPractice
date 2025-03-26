using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class EffectManager : MonoBehaviour
{
    [SerializeField] Animator noteHitAnimator = null; //노트 히트 애니메이터변수
    string hit = "Hit"; //파라미터 히트

    [SerializeField] Animator judgmentAnimator = null; //판정 애니메이터 변수
    [SerializeField] UnityEngine.UI.Image judgmentImage = null; //판정 이미지 변수
    [SerializeField] Sprite[] judgementSprite = null;   // 판정 결과에 따른 이미지 스프라이트
    public void JudgmentEffect(int p_num)
    {
        judgmentImage.sprite = judgementSprite[p_num]; // 판정 이미지 변경
        judgmentAnimator.SetTrigger(hit); //판정 애니메이터 
    }
    public void NoteHitEffect() //노트 히트 이펙트
    {
        noteHitAnimator.SetTrigger(hit);
    }
   
}

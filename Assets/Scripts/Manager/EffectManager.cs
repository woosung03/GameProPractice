using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class EffectManager : MonoBehaviour
{
    [SerializeField] Animator noteHitAnimator = null;
    string hit = "Hit";

    [SerializeField] Animator judgmentAnimator = null;
    [SerializeField] UnityEngine.UI.Image judgmentImage = null;
    [SerializeField] Sprite[] judgementSprite = null;
    public void JudgmentEffect(int p_num)
    {
        judgmentImage.sprite = judgementSprite[p_num];
        judgmentAnimator.SetTrigger(hit);
    }
    public void NoteHitEffect()
    {
        noteHitAnimator.SetTrigger(hit);
    }
   
}

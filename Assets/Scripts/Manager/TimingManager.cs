using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class TimingManager : MonoBehaviour
{
    public List < GameObject > boxNoteList = new List < GameObject > ();

    [SerializeField] Transform Center = null;
    [SerializeField] RectTransform[] timingRect = null;
    Vector2[] timingBoxs = null;

    EffectManager theEffect;
    void Start()
    {
        theEffect = FindObjectOfType<EffectManager>();

        //판정 범위 설정(타이밍 박스)
        timingBoxs = new Vector2 [timingRect.Length];

        for(int i = 0; i < timingRect.Length; i++)
        {
            timingBoxs[i].Set(Center.localPosition.x - timingRect[i].rect.width / 2,
                              Center.localPosition.x + timingRect[i].rect.width / 2);
        }
    }

    public void CheckTiming()
    { 
        for(int i = 0; i < boxNoteList.Count;i++)
        {
            float t_notePosX= boxNoteList[i].transform.localPosition.x;

            for(int x = 0; x < timingBoxs.Length; x++)
            {
                if (timingBoxs[x].x <= t_notePosX && t_notePosX <= timingBoxs[x].y)
                {
                    //노트 제거
                    boxNoteList[i].GetComponent<Note>().HideNote();
                    boxNoteList.RemoveAt(i);

                    //노트 이펙트
                    if (x < timingBoxs.Length - 1)
                        theEffect.NoteHitEffect();
                    theEffect.JudgmentEffect(x);
                    return;
                }
            }
        }
        theEffect.JudgmentEffect(timingBoxs.Length);
    }
}

using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class TimingManager : MonoBehaviour
{
    public List < GameObject > boxNoteList = new List < GameObject > (); //판정 박스 노트 리스트

    [SerializeField] Transform Center = null; //판정 중심   
    [SerializeField] RectTransform[] timingRect = null; //5개 판정 범위들
    Vector2[] timingBoxs = null; //판정 범위

    EffectManager theEffect;// **이펙트 매니저 참조
    void Start()
    {
        theEffect = FindObjectOfType<EffectManager>(); //**이펙트 매니저 컴포넌트 가져오기

        //판정 범위 설정(타이밍 박스)
        timingBoxs = new Vector2 [timingRect.Length]; //백터는 스칼라에 방향이 추가된 값 

        for(int i = 0; i < timingRect.Length; i++)
        {
            timingBoxs[i].Set(Center.localPosition.x - timingRect[i].rect.width / 2,     //판정범위 최소값
                              Center.localPosition.x + timingRect[i].rect.width / 2);   //판정범위 최대값
        }
    }

    public void CheckTiming()
    { 
        for(int i = 0; i < boxNoteList.Count;i++) //노트 리스트를 돌면서 갯수만큼 반복
        {
            float t_notePosX= boxNoteList[i].transform.localPosition.x; //노트의 x좌표를 받아와서 판정범위에 넣어줌

            for (int x = 0; x < timingBoxs.Length; x++) //노트 리스트를 돌면서 갯수만큼 반복
            {
                if (timingBoxs[x].x <= t_notePosX && t_notePosX <= timingBoxs[x].y) //판정 범위 최소값 최대값 사이
                {
                    //노트 제거
                    boxNoteList[i].GetComponent<Note>().HideNote(); //노트가 화면에서 사라짐
                    boxNoteList.RemoveAt(i); //노트 오브젝트가 사라짐

                    //노트 이펙트
                    if (x < timingBoxs.Length - 1) //판정 결과에 따른 힣ㅇ트 이펙트 재생
                        theEffect.NoteHitEffect();//**노트 히트 이펙트
                    theEffect.JudgmentEffect(x); //**판정 이펙트
                    return;
                }
            }
        }
        theEffect.JudgmentEffect(timingBoxs.Length); //**판정 이펙트 Fail
    }
}

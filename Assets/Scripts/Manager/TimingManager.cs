using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class TimingManager : MonoBehaviour
{
    public List < GameObject > boxNoteList = new List < GameObject > (); //���� �ڽ� ��Ʈ ����Ʈ

    [SerializeField] Transform Center = null; //���� �߽�   
    [SerializeField] RectTransform[] timingRect = null; //5�� ���� ������
    Vector2[] timingBoxs = null; //���� ����

    EffectManager theEffect;// **����Ʈ �Ŵ��� ����
    void Start()
    {
        theEffect = FindObjectOfType<EffectManager>(); //**����Ʈ �Ŵ��� ������Ʈ ��������

        //���� ���� ����(Ÿ�̹� �ڽ�)
        timingBoxs = new Vector2 [timingRect.Length]; //���ʹ� ��Į�� ������ �߰��� �� 

        for(int i = 0; i < timingRect.Length; i++)
        {
            timingBoxs[i].Set(Center.localPosition.x - timingRect[i].rect.width / 2,     //�������� �ּҰ�
                              Center.localPosition.x + timingRect[i].rect.width / 2);   //�������� �ִ밪
        }
    }

    public void CheckTiming()
    { 
        for(int i = 0; i < boxNoteList.Count;i++) //��Ʈ ����Ʈ�� ���鼭 ������ŭ �ݺ�
        {
            float t_notePosX= boxNoteList[i].transform.localPosition.x; //��Ʈ�� x��ǥ�� �޾ƿͼ� ���������� �־���

            for (int x = 0; x < timingBoxs.Length; x++) //��Ʈ ����Ʈ�� ���鼭 ������ŭ �ݺ�
            {
                if (timingBoxs[x].x <= t_notePosX && t_notePosX <= timingBoxs[x].y) //���� ���� �ּҰ� �ִ밪 ����
                {
                    //��Ʈ ����
                    boxNoteList[i].GetComponent<Note>().HideNote(); //��Ʈ�� ȭ�鿡�� �����
                    boxNoteList.RemoveAt(i); //��Ʈ ������Ʈ�� �����

                    //��Ʈ ����Ʈ
                    if (x < timingBoxs.Length - 1) //���� ����� ���� �R��Ʈ ����Ʈ ���
                        theEffect.NoteHitEffect();//**��Ʈ ��Ʈ ����Ʈ
                    theEffect.JudgmentEffect(x); //**���� ����Ʈ
                    return;
                }
            }
        }
        theEffect.JudgmentEffect(timingBoxs.Length); //**���� ����Ʈ Fail
    }
}

using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class TimingManager : MonoBehaviour
{
    public List < GameObject > boxNoteList = new List < GameObject > (); //ÆÇÁ¤ ¹Ú½º ³ëÆ® ¸®½ºÆ®

    [SerializeField] Transform Center = null; //ÆÇÁ¤ Áß½É   
    [SerializeField] RectTransform[] timingRect = null; //5°³ ÆÇÁ¤ ¹üÀ§µé
    Vector2[] timingBoxs = null; //ÆÇÁ¤ ¹üÀ§

    EffectManager theEffect;// **ÀÌÆåÆ® ¸Å´ÏÀú ÂüÁ¶
    void Start()
    {
        theEffect = FindObjectOfType<EffectManager>(); //**ÀÌÆåÆ® ¸Å´ÏÀú ÄÄÆ÷³ÍÆ® °¡Á®¿À±â

        //ÆÇÁ¤ ¹üÀ§ ¼³Á¤(Å¸ÀÌ¹Ö ¹Ú½º)
        timingBoxs = new Vector2 [timingRect.Length]; //¹éÅÍ´Â ½ºÄ®¶ó¿¡ ¹æÇâÀÌ Ãß°¡µÈ °ª 

        for(int i = 0; i < timingRect.Length; i++)
        {
            timingBoxs[i].Set(Center.localPosition.x - timingRect[i].rect.width / 2,     //ÆÇÁ¤¹üÀ§ ÃÖ¼Ò°ª
                              Center.localPosition.x + timingRect[i].rect.width / 2);   //ÆÇÁ¤¹üÀ§ ÃÖ´ë°ª
        }
    }

    public void CheckTiming()
    { 
        for(int i = 0; i < boxNoteList.Count;i++) //³ëÆ® ¸®½ºÆ®¸¦ µ¹¸é¼­ °¹¼ö¸¸Å­ ¹İº¹
        {
            float t_notePosX= boxNoteList[i].transform.localPosition.x; //³ëÆ®ÀÇ xÁÂÇ¥¸¦ ¹Ş¾Æ¿Í¼­ ÆÇÁ¤¹üÀ§¿¡ ³Ö¾îÁÜ

            for (int x = 0; x < timingBoxs.Length; x++) //³ëÆ® ¸®½ºÆ®¸¦ µ¹¸é¼­ °¹¼ö¸¸Å­ ¹İº¹
            {
                if (timingBoxs[x].x <= t_notePosX && t_notePosX <= timingBoxs[x].y) //ÆÇÁ¤ ¹üÀ§ ÃÖ¼Ò°ª ÃÖ´ë°ª »çÀÌ
                {
                    //³ëÆ® Á¦°Å
                    boxNoteList[i].GetComponent<Note>().HideNote(); //³ëÆ®°¡ È­¸é¿¡¼­ »ç¶óÁü
                    boxNoteList.RemoveAt(i); //³ëÆ® ¿ÀºêÁ§Æ®°¡ »ç¶óÁü

                    //³ëÆ® ÀÌÆåÆ®
                    if (x < timingBoxs.Length - 1) //ÆÇÁ¤ °á°ú¿¡ µû¸¥ ÆR¤·Æ® ÀÌÆåÆ® Àç»ı
                        theEffect.NoteHitEffect();//**³ëÆ® È÷Æ® ÀÌÆåÆ®
                    theEffect.JudgmentEffect(x); //**ÆÇÁ¤ ÀÌÆåÆ®
                    return;
                }
            }
        }
        theEffect.JudgmentEffect(timingBoxs.Length); //**ÆÇÁ¤ ÀÌÆåÆ® Fail
    }
}

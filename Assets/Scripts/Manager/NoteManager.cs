using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class NoteManager : MonoBehaviour 
{
    public int bpm = 0; //분당 노트 수 설정
    double currentTime = 0d; //노트 생성 시간

    [SerializeField] Transform tfNoteAppear = null; //노트 생성 위치
    [SerializeField] GameObject goNote = null;  //노트 프리팹 위치

    TimingManager theTimingManager; //**타이밍 매니저 참조
    EffectManager theEffectManager; //**이펙트 매니저 참조
    void Start() //오류 많이 발생하는 부분
    {
        theEffectManager = FindObjectOfType<EffectManager>(); //**이펙트 매니저 컴포넌트 가져오기
        theTimingManager = GetComponent<TimingManager>(); //타이밍 매니저 컴포넌트 가져오기
    }

    void Update() //노트 생성
    {
        currentTime += Time.deltaTime; //시간이 흐름에 따라 현재 시간을 더해줌 1초에 1씩 증가

        if (currentTime >= 60d / bpm) //60초를 분당 노트 수로 나누어서 노트 생성
        {
            GameObject t_note = Instantiate(goNote, tfNoteAppear.position, Quaternion.identity); //0.5초 지나면 노트 생성

            t_note.transform.SetParent(this.transform); //게임화면에 노트 보이게하기
            theTimingManager.boxNoteList.Add(t_note); //**노트 리스트에 노트 추가
            currentTime -= 60d / bpm; //노트 생성 후 현재 시간 초기화(currentTime 시간이 뭔가 이상함 게속 밀림)
        }
    }

    private void OnTriggerExit2D(Collider2D collision) //Enter랑 Exit 판정이 다른가? Enter는 들어 올때 Exit는 나갈때 
    {
        if (collision.CompareTag("Note"))
        {
            theEffectManager.JudgmentEffect(4); //**판정 이펙트
            theTimingManager.boxNoteList.Remove(collision.gameObject); //**노트 리스트에서 노트 제거
            Destroy(collision.gameObject); //노트가 판정선을 지나가면 노트 제거
        }
    }
}

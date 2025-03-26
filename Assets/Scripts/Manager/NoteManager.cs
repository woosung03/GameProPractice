using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class NoteManager : MonoBehaviour 
{
    public int bpm = 0; //�д� ��Ʈ �� ����
    double currentTime = 0d; //��Ʈ ���� �ð�

    [SerializeField] Transform tfNoteAppear = null; //��Ʈ ���� ��ġ
    [SerializeField] GameObject goNote = null;  //��Ʈ ������ ��ġ

    TimingManager theTimingManager; //**Ÿ�̹� �Ŵ��� ����
    EffectManager theEffectManager; //**����Ʈ �Ŵ��� ����
    void Start() //���� ���� �߻��ϴ� �κ�
    {
        theEffectManager = FindObjectOfType<EffectManager>(); //**����Ʈ �Ŵ��� ������Ʈ ��������
        theTimingManager = GetComponent<TimingManager>(); //Ÿ�̹� �Ŵ��� ������Ʈ ��������
    }

    void Update() //��Ʈ ����
    {
        currentTime += Time.deltaTime; //�ð��� �帧�� ���� ���� �ð��� ������ 1�ʿ� 1�� ����

        if (currentTime >= 60d / bpm) //60�ʸ� �д� ��Ʈ ���� ����� ��Ʈ ����
        {
            GameObject t_note = Instantiate(goNote, tfNoteAppear.position, Quaternion.identity); //0.5�� ������ ��Ʈ ����

            t_note.transform.SetParent(this.transform); //����ȭ�鿡 ��Ʈ ���̰��ϱ�
            theTimingManager.boxNoteList.Add(t_note); //**��Ʈ ����Ʈ�� ��Ʈ �߰�
            currentTime -= 60d / bpm; //��Ʈ ���� �� ���� �ð� �ʱ�ȭ(currentTime �ð��� ���� �̻��� �Լ� �и�)
        }
    }

    private void OnTriggerExit2D(Collider2D collision) //Enter�� Exit ������ �ٸ���? Enter�� ��� �ö� Exit�� ������ 
    {
        if (collision.CompareTag("Note"))
        {
            theEffectManager.JudgmentEffect(4); //**���� ����Ʈ
            theTimingManager.boxNoteList.Remove(collision.gameObject); //**��Ʈ ����Ʈ���� ��Ʈ ����
            Destroy(collision.gameObject); //��Ʈ�� �������� �������� ��Ʈ ����
        }
    }
}

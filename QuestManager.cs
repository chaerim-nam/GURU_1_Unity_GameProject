using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public int questId;

    Dictionary<int, QuestData> questList;

    void Awake()
    {
        questList = new Dictionary<int, QuestData>();
        GenerateData();
    }

    void GenerateData()
    {
        //����Ʈ ���̵�, ���ǽ� ���̵�
        questList.Add(10, new QuestData("��������2 ����Ʈ", new int[] { 1000 }));
    }

    //���ǽ� ���̵� �ް� ����Ʈ ��ȣ�� ��ȯ�ϴ� �Լ�
    public int GetQuestTalkIndex(int id)
    {
        return questId;
    }
}

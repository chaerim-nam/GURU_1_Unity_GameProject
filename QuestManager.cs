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
        //퀘스트 아이디, 엔피시 아이디
        questList.Add(10, new QuestData("스테이지2 퀘스트", new int[] { 1000 }));
    }

    //엔피시 아이디를 받고 퀘스트 번호를 반환하는 함수
    public int GetQuestTalkIndex(int id)
    {
        return questId;
    }
}

using System.Collections;
using System.Collections.Generic;

public class QuestData 
{
    public string questName;

    //퀘스트를 주는 엔피시 아이디 변수
    public int[] npcId;

    //구조체 생성을 위한 매개변수 생성자
    public QuestData(string name, int[] npc)
    {
        questName = name;
        npcId = npc;
    }
}

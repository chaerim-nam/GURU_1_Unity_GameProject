using System.Collections;
using System.Collections.Generic;

public class QuestData 
{
    public string questName;

    //����Ʈ�� �ִ� ���ǽ� ���̵� ����
    public int[] npcId;

    //����ü ������ ���� �Ű����� ������
    public QuestData(string name, int[] npc)
    {
        questName = name;
        npcId = npc;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkManager : MonoBehaviour
{
    //�б�
    public int branch; //���� 1 �Ǵ� 2
    

    //������Ʈ�� ���̵�� ��ȭ ����
    Dictionary<int, string[]> talkData;

    void Awake()
    {
        talkData = new Dictionary<int, string[]>();
        GenerateData();
    }

    //��ȭ ������ ����
    void GenerateData()
    {
        //Talk Data
        //Chlid: 1000
        


        //Quest Talk
        if (branch == 1)
        {
            talkData.Add(10 + 1000, new string[] { "...", "�ٵ� ���� ���ž�?", "..ůů", "��� ���ִ� ������ ���µ�?", "[����Ʈ: �򸣸� ã�ƺ�����]", " [WASDŰ�� �̵�, SPACEŰ�� ��ȣ�ۿ�] " });
            talkData.Add(10 + 2000, new string[] { "!! �򸣴�!", "[����Ʈ ����!]", "�ȳ�.. ��ġ ���̳�", "�׳����� ���ϵ��� �� ���� ������?", "�������� �� �� ������?" });
            talkData.Add(10 + 3000, new string[] { "[�� 1 ���а�]", "�ǹ� ���� �� �� ." });
            talkData.Add(10 + 4000, new string[] { "������ �ڱ� �� ���ƺ��̴� �ڵ���." });
            talkData.Add(10 + 5000, new string[] { "���� �Ǹ� ���� ���� �����." });
            talkData.Add(10 + 6000, new string[] { "����� �ڵ���", "���ִ� ������ ������ �ʴ´�." });
            talkData.Add(10 + 7000, new string[] { "���� ���� ���δ�.", "��ô �������ϴ�." });
            talkData.Add(10 + 8000, new string[] { "���ֹ����� ���δ�.", "�켱 ���ִ� ������ ��� ������ ã�ƺ���." });

            


        }
        else if(branch == 2)
        {
            talkData.Add(10 + 1000, new string[] { "���ϵ��� ã�� �ִٰ�?", "�׷� �� �񴰹���� ���󰡺�" });
           
        }
        else if (branch == 3)
        {
            talkData.Add(10 + 1000, new string[] { "���?", "���� �����̳����ݾ�!", "�̳༮! ���� �� �������� ���� �ڴٴ�!", "ȥ �� ����߰ڱ�!" });
            talkData.Add(10 + 2000, new string[] { "��!", "���� �� �����̶��!" });
            talkData.Add(10 + 3000, new string[] { "[������ ���]" });
            talkData.Add(10 + 4000, new string[] { "[ȭ��]", "���ִ� ����� ���µ� �ű��ϰ� �� ����ִ�." });
            talkData.Add(10 + 5000, new string[] { "[�����]", "���� �Ѱܳ� �� �и��ϴ�." });
        }
        else if (branch == 4)
        {
            talkData.Add(10 + 2000, new string[] { "���� : ������ ���� �� ��!", "��, ��� ����", "����,�� ���ϵ��� �� ����� �˾�?", "���� : ����!!", "��.. �������� �� �� �����߰ڱ�" });
            talkData.Add(10 + 3000, new string[] { "[������ ���]" });
            talkData.Add(10 + 4000, new string[] { "[ȭ��]", "���ִ� ����� ���µ� �ű��ϰ� �� ����ִ�." });
            talkData.Add(10 + 5000, new string[] { "[�����]", "���� �Ѱܳ� �� �и��ϴ�." });
           
        }
        else if (branch == 5)
        {
            talkData.Add(10 + 1000, new string[] { "�ƺ�?", "��ħ �� �Ծ��!", "���� ��� ���� ���� �㵹�̸� �� ã�ھ��..", "�ƺ��� �� ã���ֽǷ���?" });
            talkData.Add(10 + 2000, new string[] { "�㵹��..." });
            talkData.Add(10 + 3000, new string[] { ".  .  ." });
            talkData.Add(10 + 4000, new string[] { "�ڵ����� �� �༮�� ����� �޾ƾ� ������ �� �ִ�." });
            talkData.Add(10 + 5000, new string[] { "�� ������ ������ �ڵ����� �� ���´�." });
            talkData.Add(10 + 6000, new string[] { "��ȭ��", "�ٸ� ����� ������ ����." });
            talkData.Add(10 + 7000, new string[] { "�������� ���δ�." });
        }
        else if (branch == 6)
        {
            talkData.Add(10 + 1000, new string[] { "������ �ƺ�!", "��? ���ϵ��̿�?", " �۽��..���� �� ���̴��ɿ�?", "�ﰢ���� �� �� ��������!" });
            talkData.Add(10 + 2000, new string[] { "�㵹�̸� ã�Ҵ�~ ������!" });
            talkData.Add(10 + 3000, new string[] { "�����ϴ�." });
            talkData.Add(10 + 4000, new string[] { "�ڵ����� �� �༮�� ����� �޾ƾ� ������ �� �ִ�." });
            talkData.Add(10 + 5000, new string[] { "�̰� ������ �ڵ����� �� ���´�." });
            talkData.Add(10 + 6000, new string[] { "[��ȭ��]", "�ٸ� ����� ������ ����." });
            talkData.Add(10 + 7000, new string[] { "�������� ���δ�." });
        }
        else if (branch == 7)
        {
            talkData.Add(10 + 1000, new string[] { "����", "�� ���а��� ���� ���� ����̴� ������?", "�츮 �б� ����̰� �ƴ��ݾ�?!", });
            talkData.Add(10 + 2000, new string[] { "����, �� ������! ", "���� ����� : �� �̸� �����!", "���� ����� : ���￩��� ���� ���� �����Ѵ�!!", "���� ����� : ������ �ΰ����� �� �� �� �Ʒ���!", "��? ���� �� ģ�� ���ϵ��� �����̾�!", "�б��� ���� ��Ų��!!", "�� �� ���� �����!" });
            talkData.Add(10 + 3000, new string[] { "[������ȭ]", "����ϴ� ���ϴ� ���� ����." });

        }
        else if (branch == 8)
        {
            talkData.Add(10 + 1000, new string[] { "��..���� �ο��̿���..", "���� ��ο�����", "������ ���ϵ��� ���ƿñ�?", "...", "������..", });

        }
        else if (branch == 9)
        {
            talkData.Add(10 + 1000, new string[] { "[��ħ ������ ±±�Ÿ���] ","[�ָ��� ������� �Ҹ��� �鸰��]","??? : �� ���� �б��� ���±���..", "?? : ��! ��ġ��!!", "??? : �� ���??", "??? : ����� ! ��ġ�� �츮 ����;��� ~!" });

        }
        else if (branch == 10)
        {
            talkData.Add(10 + 1000, new string[] { "..!!", "���ϵ�! ���ƿԱ���!!" });

        }

    }

    //������ ��ȭ ������ ��ȯ
    public string GetTalk(int id, int talkIndex)
    {
        //��ȭ�� �������� null ��ȯ
        if (talkIndex == talkData[id].Length)
        {

            return null;
        }
        else
        {
            return talkData[id][talkIndex];     //id�� ��ȭ�� ������ ��, talkIndex�� ��ȭ�� �� ������ �����´�.
            
        }
    }

   
}

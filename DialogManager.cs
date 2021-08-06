using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogManager : MonoBehaviour
{
    public int branch;


    //��ȭ �Ŵ��� ����
    public TalkManager talkManager;

    //����Ʈ �Ŵ��� ����
    public QuestManager questManager;

    //��ȭ �ǳ� ����
    public GameObject talkPanel;

    //��ȭ �ؽ�Ʈ ����
    public Text talkText;

    //��ȭ �ε��� ����
    public int talkIndex;

    //�˻� ��� ������Ʈ ����
    public GameObject scanObject;

    public bool isAction;

    public void Action(GameObject scanObj)
    {
        scanObject = scanObj;
        ObjData objData = scanObject.GetComponent<ObjData>();
        Talk(objData.id, objData.isNPC);

        talkPanel.SetActive(isAction);
    }

    void Talk(int id, bool isNPC)
    {
        //Set Talk Data
        int questTalkIndex = questManager.GetQuestTalkIndex(id);
        string talkData = talkManager.GetTalk(id + questTalkIndex, talkIndex);
        //����Ʈ ��ȣ + ���ǽ� ���̵� = ����Ʈ ��ȭ ������ ���̵�

        //End Talk
        if (talkData == null)
        {
            isAction = false;
            talkIndex = 0;
            //return;     //��������

            if (branch ==1)
            {

                if (scanObject.name == "Chur")
                {
                    //�������� 2�� ����
                    SceneManager.LoadScene("Stage02_Main");
                    return;
                }
                else
                {
                    return;
                }
               
            }
            else if(branch==2)
            {
                //��������2 �̴ϰ������� ����!
                SceneManager.LoadScene("SampleScene");
                return;
            }
            else if (branch == 3)
            {
                
                if (scanObject.name == "Swutang")
                {
                    //�������� 3�� �̴ϰ������� ����
                    SceneManager.LoadScene("Stage03_minigame");
                    ;
                    return;
                }
                else
                {
                    return;
                }
            }
            else if (branch == 4)
            {
                if (scanObject.name == "Swutang")
                {
                    //�������� 4�� ����
                    SceneManager.LoadScene("Stage04_Main_1");
                    return;
                }
                else
                {
                    return;
                }
            }
            else if (branch ==5 )
            {
                if (scanObject.name == "Woodong")
                {
                    //�������� 4�� �̴ϰ������� ����
                    SceneManager.LoadScene("Stage04_minigame");
                    return;
                }
                else
                {
                    return;
                }
            }
            else if (branch == 6)
            {
                if (scanObject.name == "Woodong")
                {
                    //�������� 5��!
                    SceneManager.LoadScene("Stage05_Main_1");
                    return;
                }
                else
                {
                    return;
                }

            }
            else if (branch == 7)
            {
                if (scanObject.name == "Gang")
                {
                    //�������� 5�� �̴ϰ��ӷ�!
                    SceneManager.LoadScene("Stage05_minigame");
                    return;
                }
                else
                {
                    return;
                }

            }
            else if (branch == 8)
            {
                //�������� ����
                SceneManager.LoadScene("End");
                return;


            }
            else if (branch == 9)
            {


                //���ʷα�2�� ����
                SceneManager.LoadScene("Epilogue2");
                return;

            }
            else if (branch == 10)
            {


                //close�� !
                SceneManager.LoadScene("Close");
                return;

            }
        }

        //Continue Talk
        if (isNPC)
        {
            talkText.text = talkData;
        }
        else
        {
            talkText.text = talkData;
        }

        isAction = true;
        talkIndex++;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogManager : MonoBehaviour
{
    public int branch;


    //대화 매니저 변수
    public TalkManager talkManager;

    //퀘스트 매니저 변수
    public QuestManager questManager;

    //대화 판넬 변수
    public GameObject talkPanel;

    //대화 텍스트 변수
    public Text talkText;

    //대화 인덱스 변수
    public int talkIndex;

    //검색 대상 오브젝트 변수
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
        //퀘스트 번호 + 엔피시 아이디 = 퀘스트 대화 데이터 아이디

        //End Talk
        if (talkData == null)
        {
            isAction = false;
            talkIndex = 0;
            //return;     //강제종료

            if (branch ==1)
            {

                if (scanObject.name == "Chur")
                {
                    //스테이지 2로 연결
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
                //스테이지2 미니게임으로 연결!
                SceneManager.LoadScene("SampleScene");
                return;
            }
            else if (branch == 3)
            {
                
                if (scanObject.name == "Swutang")
                {
                    //스테이지 3의 미니게임으로 연결
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
                    //스테이지 4로 연결
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
                    //스테이지 4의 미니게임으로 연결
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
                    //스테이지 5로!
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
                    //스테이지 5의 미니게임로!
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
                //엔딩으로 연결
                SceneManager.LoadScene("End");
                return;


            }
            else if (branch == 9)
            {


                //에필로그2로 연결
                SceneManager.LoadScene("Epilogue2");
                return;

            }
            else if (branch == 10)
            {


                //close로 !
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

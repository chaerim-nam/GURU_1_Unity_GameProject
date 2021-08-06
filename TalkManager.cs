using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkManager : MonoBehaviour
{
    //분기
    public int branch; //값은 1 또는 2
    

    //오브젝트의 아이디와 대화 정보
    Dictionary<int, string[]> talkData;

    void Awake()
    {
        talkData = new Dictionary<int, string[]>();
        GenerateData();
    }

    //대화 문장을 저장
    void GenerateData()
    {
        //Talk Data
        //Chlid: 1000
        


        //Quest Talk
        if (branch == 1)
        {
            talkData.Add(10 + 1000, new string[] { "...", "다들 어디로 간거야?", "..킁킁", "어디서 맛있는 냄새가 나는데?", "[퀘스트: 츄르를 찾아보세요]", " [WASD키로 이동, SPACE키로 상호작용] " });
            talkData.Add(10 + 2000, new string[] { "!! 츄르다!", "[퀘스트 성공!]", "냠냠.. 참치 맛이네", "그나저나 슈니들이 다 어디로 간거지?", "도서관에 한 번 가볼까?" });
            talkData.Add(10 + 3000, new string[] { "[제 1 과학관]", "건물 안은 못 들어가 ." });
            talkData.Add(10 + 4000, new string[] { "누워서 자기 딱 좋아보이는 자동차." });
            talkData.Add(10 + 5000, new string[] { "밤이 되면 빛이 나는 막대기." });
            talkData.Add(10 + 6000, new string[] { "평범한 자동차", "맛있는 냄새가 나지는 않는다." });
            talkData.Add(10 + 7000, new string[] { "안이 훤히 보인다.", "무척 지저분하다." });
            talkData.Add(10 + 8000, new string[] { "만주벌판이 보인다.", "우선 맛있는 냄새가 어디서 나는지 찾아보자." });

            


        }
        else if(branch == 2)
        {
            talkData.Add(10 + 1000, new string[] { "슈니들을 찾고 있다고?", "그럼 이 비눗방울을 따라가봐" });
           
        }
        else if (branch == 3)
        {
            talkData.Add(10 + 1000, new string[] { "어라?", "저건 슈땅이놈이잖아!", "이녀석! 감히 내 구역에서 잠을 자다니!", "혼 좀 내줘야겠군!" });
            talkData.Add(10 + 2000, new string[] { "야!", "여긴 내 구역이라고!" });
            talkData.Add(10 + 3000, new string[] { "[오래된 기둥]" });
            talkData.Add(10 + 4000, new string[] { "[화분]", "물주는 사람도 없는데 신기하게 잘 살아있다." });
            talkData.Add(10 + 5000, new string[] { "[기숙사]", "들어가면 쫓겨날 게 분명하다." });
        }
        else if (branch == 4)
        {
            talkData.Add(10 + 2000, new string[] { "슈땅 : 다음엔 절대 안 져!", "흥, 어림도 없지", "아참,너 슈니들이 다 어디간지 알아?", "슈땅 : 몰라!!", "흥.. 정문에나 한 번 가봐야겠군" });
            talkData.Add(10 + 3000, new string[] { "[오래된 기둥]" });
            talkData.Add(10 + 4000, new string[] { "[화분]", "물주는 사람도 없는데 신기하게 잘 살아있다." });
            talkData.Add(10 + 5000, new string[] { "[기숙사]", "들어가면 쫓겨날 게 분명하다." });
           
        }
        else if (branch == 5)
        {
            talkData.Add(10 + 1000, new string[] { "아빠?", "마침 잘 왔어요!", "여기 어딘가 숨겨 놓은 쥐돌이를 못 찾겠어요..", "아빠가 좀 찾아주실래요?" });
            talkData.Add(10 + 2000, new string[] { "쥐돌이..." });
            talkData.Add(10 + 3000, new string[] { ".  .  ." });
            talkData.Add(10 + 4000, new string[] { "자동차는 이 녀석의 허락을 받아야 지나갈 수 있다." });
            talkData.Add(10 + 5000, new string[] { "이 꼬깔이 있으면 자동차가 못 들어온다." });
            talkData.Add(10 + 6000, new string[] { "소화전", "다른 고양이 냄새가 난다." });
            talkData.Add(10 + 7000, new string[] { "주차장이 보인다." });
        }
        else if (branch == 6)
        {
            talkData.Add(10 + 1000, new string[] { "고마워요 아빠!", "네? 슈니들이요?", " 글쎄요..요즘 안 보이던걸요?", "삼각숲에 한 번 가보세요!" });
            talkData.Add(10 + 2000, new string[] { "쥐돌이를 찾았다~ 고마워요!" });
            talkData.Add(10 + 3000, new string[] { "고맙습니다." });
            talkData.Add(10 + 4000, new string[] { "자동차는 이 녀석의 허락을 받아야 지나갈 수 있다." });
            talkData.Add(10 + 5000, new string[] { "이게 있으면 자동차가 못 들어온다." });
            talkData.Add(10 + 6000, new string[] { "[소화전]", "다른 고양이 냄새가 난다." });
            talkData.Add(10 + 7000, new string[] { "주차장이 보인다." });
        }
        else if (branch == 7)
        {
            talkData.Add(10 + 1000, new string[] { "오잉", "저 깡패같이 생긴 검은 고양이는 누구지?", "우리 학교 고양이가 아니잖아?!", });
            talkData.Add(10 + 2000, new string[] { "어이, 넌 누구냐! ", "깡패 고양이 : 내 이름 김깡패!", "깡패 고양이 : 서울여대는 이제 내가 지배한다!!", "깡패 고양이 : 나약한 인간들은 다 내 발 아래야!", "뭐? 여긴 내 친구 슈니들의 공간이야!", "학교는 내가 지킨다!!", "한 판 붙자 김깡패!" });
            talkData.Add(10 + 3000, new string[] { "[공중전화]", "사용하는 슈니는 별로 없다." });

        }
        else if (branch == 8)
        {
            talkData.Add(10 + 1000, new string[] { "휴..힘든 싸움이였어..", "벌써 어두워졌네", "내일은 슈니들이 돌아올까?", "...", "졸리다..", });

        }
        else if (branch == 9)
        {
            talkData.Add(10 + 1000, new string[] { "[아침 새들이 짹짹거린다] ","[멀리서 웅성대는 소리가 들린다]","??? : 와 드디어 학교를 오는구나..", "?? : 어! 우치다!!", "??? : 헉 어디??", "??? : 저어기 ! 우치야 우리 보고싶었지 ~!" });

        }
        else if (branch == 10)
        {
            talkData.Add(10 + 1000, new string[] { "..!!", "슈니들! 돌아왔구나!!" });

        }

    }

    //지정된 대화 문장을 반환
    public string GetTalk(int id, int talkIndex)
    {
        //대화가 끝났으면 null 반환
        if (talkIndex == talkData[id].Length)
        {

            return null;
        }
        else
        {
            return talkData[id][talkIndex];     //id로 대화를 가져온 후, talkIndex로 대화의 한 문장을 가져온다.
            
        }
    }

   
}

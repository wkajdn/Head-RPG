using System.Collections;           //네임스페이스. "Collections자료구조 클래스를 가져온다." Object형식을 사용해 데이터를 관리한다. 박싱(Object로 형변환 되는 것)과 언박싱(Object에서 원래 타입으로 변환하는 것.)이 발생해서 C#에서는 사용하지 않는다. 사실 지워도 실행에는 문제가 없다...
using System.Collections.Generic;   //네임스페이스. "Collections.Generic자료구조 클래스를 가져온다." 데이터 형식을 일반화하여 사용하기 때문에 Collections보다 성능 저하가 적다. 형변환을 거치지 않는다.
using UnityEngine;                  //네임스페이스. "UnityEngine의 API(컴퓨터 프로그램 사이의 연결 서비스)를 가져온다."

public class DataController : MonoBehaviour   // 클래스의 이름은 이 C# Script의 이름과 동일해야 한다.
                                              // MonoBehaviour 모든 Unity 스크립트가 파생되는 기본 클래스. <Behaviour <Component <Object. 
{
    public int m_gold = 0;              //전역변수(class 내 모든 곳에서 사용할 수 있는 변수). "정수 gold 라는 변수를 만들고 0을 대입한다." 기존 골드량.
    private int m_goldPerClick = 0;     //전역변수. "정수 goldPerClick 이라는 변수를 만들고 0을 대입한다." 클릭 당 골드량.

    private void Awake()          // 딱히 출력할 필요가 없는 Awake()메서드. 스크립트 인스턴스가 로딩될 때, 게임이 시작되기 전에, 모든 변수와 게임의 상태를 초기화하기 위해 딱 한 번 호출된다. Start()와 다른 점은, Awake()는 스크립트간의 참조를 설정하기 위해 사용하고, Start는 정보를 보내고 받는 경우에 사용한다는 것이다.
    {
        //PlayerPrefs.DeleteAll();
        m_gold = PlayerPrefs.GetInt("Gold");                      // "PlayerPrefs(게임 세션 사이에 Preference를 저장하고, 접근하는 클래스)에서 "Gold"라고 정의되어 있는 데이터를 로드한다." 왜? 두 번째 실행할 때 로드를 하고 이어서 작업해야 하니까.
        m_goldPerClick = PlayerPrefs.GetInt("GoldPerClick", 1);      // "PlayerPrefs에서 "GoldPerClick"이라고 정의되어 있는 데이터를 로드한다." 초기화하며 값에 변화를 주기 위해 인수 1을 추가했다.
    }
    // **골드량을 레지스트리에 저장하는 메서드
    public void SetGold(int newGold)              //"정수 newGold를 매개변수로 갖는 현재 골드량 메서드를 만든다." Set~은 자주 쓰이는 함수. 골드에 뭘 할 때마다 계속 나올 예정이다. set을 통해 데이터에 저장 중인 것.
    {
        m_gold = newGold;                         //"전역변수 m_gold에 newGold를 대입한다." SetGold메서드의 인수를 골드에 넣기 위해. 근데 사실 이 문장이 없어도 문제가 없다. newGold에 다시 넣고 작성할거냐, 그냥 어차피 매번 최신화되는 m_gold의 값을 사용할거냐.
        PlayerPrefs.SetInt("Gold", m_gold);       //"PlayerPrefs에 "Gold"로 식별된 Preference의 값을 m_gold로 설정한다." 즉, 레지스트리에 값을 저장한다.
    }
    // **골드량 증감을 처리하는 메서드.
    public void AddGold(int newGold)     // "정수 newGold를 매개변수로 갖는 AddGold메서드를 만든다." 
    {
        m_gold += newGold;               // "m_gold에 변수 m_gold + 인수 newGold 값을 대입한다." 
        SetGold(m_gold);                 // "그리고, 그렇게 나온 m_gold 값을 SetGold 시킨다(=PlayerPrefs에 저장한다)."
    }

    public void SubGold(int newGold)     // "정수 newGold를 매개변수로 갖는 SubGold메서드를 만든다."
    {
        m_gold -= newGold;               // "m_gold에 변수 m_gold - 인수 newGold 값을 대입한다."
        SetGold(m_gold);                 // "그리고, 그렇게 나온 m_gold 값을 SetGold 시킨다(=PlayerPrefs에 저장한다)."
    }

    public int GetGold()    // "정수형 GetGold() 메서드를 만든다."
    {
        return m_gold;        // 보이드 형태면 필요 없는데 int라 리턴해줘야 함. "m_gold의 값을 돌려준다."
    }
    // **골드를 클릭할 때마다 증가하는 메서드.
    public void SetGoldPerClick(int newGoldPerClick)           // "정수 newGoldPerClick을 매개변수로 갖는 현재 클릭 당 골드량을 메서드로 만든다."
    {
        m_goldPerClick = newGoldPerClick;                      //"인수 newGoldPerClick을 변수 m_goldPerClick에 대입한다."
        PlayerPrefs.SetInt("GoldPerClick", m_goldPerClick);    //"PlayerPrefs에 "GoldPerClick"로 식별된 Preference의 값을 m_goldPerClick로 설정한다."
    }

    public int GetGoldPerClick()        // "정수형 GetGoldPerClick() 메서드를 만든다."
    {
        return m_goldPerClick;          // "m_goldPerClick의 값을 돌려준다."
    }

    public void AddGoldPerClick(int newGoldPerClick)
    {
        m_goldPerClick += newGoldPerClick;
        SetGoldPerClick(m_goldPerClick);
    }

    public void LoadUpgradeButton(UpgradeButton upgradeButton)
    {
        string key = upgradeButton.upgradeName;
        upgradeButton.level = PlayerPrefs.GetInt(key + "_level", 1);
        upgradeButton.goldByUpgrade = PlayerPrefs.GetInt(key + "_goldByUpgrade", upgradeButton.goldByUpgrade);
        upgradeButton.currentCost = PlayerPrefs.GetInt(key + "_cost", upgradeButton.currentCost);
    }

    public void SaveUpgradeButton(UpgradeButton upgradeButton)
    {
        string key = upgradeButton.upgradeName;
        PlayerPrefs.SetInt(key + "_level", upgradeButton.level);
        PlayerPrefs.SetInt(key + "_goldByUpgrade", upgradeButton.goldByUpgrade);
        PlayerPrefs.SetInt(key + "_Cost", upgradeButton.currentCost);
    }

}

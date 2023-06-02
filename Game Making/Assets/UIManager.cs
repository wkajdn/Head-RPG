using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;   // 유니티엔진의 UI에 접근할 수 있는 API 호출.

public class UIManager : MonoBehaviour
{
    public Text goldDisplayer;                // 골드디스플레이어의 text 변수 선언.
    public Text goldPerClickDisplayer;        // 클릭 당 골드량 디스플레이어의 text변수 선언.
    public DataController dataController;      // 인스턴스화

    void Start()
    {

    }

    void Update()     //매 업데이트마다 적용되도록.
    {
        goldDisplayer.text = "Gold : " + dataController.GetGold();   // text는 우리가 골드디스플레이어에 텍스트가 있기 때문에, 또한 여기에 접근 가능한 이유는 우리가 위에 UI를 추가했기 때문에.  = dataController.GetGold().ToString(); 해도 골드량만이지만 보이긴 함.
        goldPerClickDisplayer.text = "Gold Per Click : " + dataController.GetGoldPerClick();    // 클릭 당 골드량 디스플레이어의 텍스트에 "Gold Per Click : " 이란 문자열과 데이터컨트롤의 GetGoldPerClick() 리턴값을 출력함.



    }
}

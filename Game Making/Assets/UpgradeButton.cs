using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;          // 유니티 API의 UI를 가져오다.

public class UpgradeButton : MonoBehaviour        //28일
{
    public DataController dataController;   // DataController 클래스 인스턴스화.

    public Text upgradeDisplayer;     // UI의 Text upgradeDisplayer 를 지정하는 곳.
    public string upgradeName;        // "업그레이드"의 이름.

    public int goldByUpgrade;            // goldByUpgrade(업그레이드에 의해 증가한 골드량) 변수 선언.
    public int startGoldByUpgrade = 1;   // 업그레이드에 의해 증가하는 골드량의 처음 수치 에 대한 변수를 선언하고 1로 초기화.

    public int currentCost;           // 업그레이드 비용에 대한 변수 선언.
    public int startCurrentCost = 1;  // 업그레이드 비용의 처음 수치에 대한 변수를 선언하고 1로 초기화.

    public int level = 1;    // 레벨에 대한 변수를 선언하고 1로 초기화.

    public float upgradePow = 1.14f;   // pow : 거듭제곱. 여긴 그냥 변수이름으로 쓴거지만.. 어쨌든 업그레이드 제곱 변수를 만들고 1.14f로 초기화.
    public float costPow = 1.24f;     // 비용 제곱 변수를 만들고 1.24f로 초기화.



    void Start()                                   // 첫 프레임에 실행되는 것들.
    {
        dataController.LoadUpgradeButton(this);    // 데이터컨트롤러 클래스에서 LoadUpgradeButton 메서드를 가져오고 인수로 이 클래스를 넣어서 실행.
        UpdateUI();                                // 아래에 만든 UpdateUI 메서드 실행.
    }

    public void PurchaseUpgrade()     // 구매했을 때의 프로세스. 로직.  //OnClick 이벤트로 작동(버튼 컴포넌트에서 적용했기 때문에).
    {
        if(dataController.GetGold() >= currentCost)   //내 가진 골드랑 현재 비용을 계산한다. 업그레이드 비용보다 가진 돈이 더 크다면? 아래 과정(업그레이드)가능.
        {
            dataController.SubGold(currentCost);   // 가진 돈에서 업그레이드 비용을 뺀다.
            level += 1;                            // 레벨을 1 증가시킨다.
            dataController.AddGoldPerClick(goldByUpgrade);     // 데이터컨트롤러쪽에 작성된 클릭 당 골드량 추가 메서드를 업그레이드되는 골드량을 인수로 받아 실행시킨다.

            //클릭 당 골드 변경된 부분들 저장하는 부분.
            UpdateUpgrade();         // 업그레이드와 관련된 프로세스 진행. 아래 메서드. 
            UpdateUI();              // UI도 업데이트함.
            dataController.SaveUpgradeButton(this);    // 데이터컨트롤러에 작성된 업그레이드버튼 저장 메서드를 이 클래스를 받아 실행.
        }
    }

    public void UpdateUpgrade()    // 클릭 당 골드레벨도 증가해야 하고, 비용도 증가해야 하니 업그레이드 되는 값을 업데이트 하는 메서드. // 굳이 이 함수 없이 펄체이스업그레이드에 넣어도 되는데 나중에 여기에 뭘 더 추가할지 몰니까 미래를 위해 분리.
    {
        goldByUpgrade = startGoldByUpgrade * (int)Mathf.Pow(upgradePow, level);  // 업그레이드 되는 골드량은 시작 업그레이드 골드량(1) x (upgradePow의 값(1.14f)을 레벨만큼 제곱하고, 정수화 한 값)이다.
        currentCost = startCurrentCost * (int)Mathf.Pow(costPow, level);   // 업그레이드 비용은, costPow(1.24f)에 level만큼 거듭제곱을 한 값이다.
    }

    public void UpdateUI()      // 처음 UI에서 보여주는 값을 설정하는 메서드.
    {
        upgradeDisplayer.text = "능지 떡상: "+ upgradeName + "\n" + "필요 비용: " + currentCost + "\n" + "레벨: " + level + "\n" + "획득 가능 골드 +" + goldByUpgrade;    //upgradeName이 스트링이라.
    }

    public void SaveUpgradeButton(UpgradeButton upgradeButton)
    {
        string key = upgradeButton.upgradeName;
        PlayerPrefs.SetInt(key + "_level", upgradeButton.level);
        PlayerPrefs.SetInt(key + "_goldByUpgrade", upgradeButton.goldByUpgrade);
        PlayerPrefs.SetInt(key + "_Cost", upgradeButton.currentCost);
    }

    void Update()
    {
        
    }
}

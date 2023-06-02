using System.Collections;           //���ӽ����̽�. "Collections�ڷᱸ�� Ŭ������ �����´�." Object������ ����� �����͸� �����Ѵ�. �ڽ�(Object�� ����ȯ �Ǵ� ��)�� ��ڽ�(Object���� ���� Ÿ������ ��ȯ�ϴ� ��.)�� �߻��ؼ� C#������ ������� �ʴ´�. ��� ������ ���࿡�� ������ ����...
using System.Collections.Generic;   //���ӽ����̽�. "Collections.Generic�ڷᱸ�� Ŭ������ �����´�." ������ ������ �Ϲ�ȭ�Ͽ� ����ϱ� ������ Collections���� ���� ���ϰ� ����. ����ȯ�� ��ġ�� �ʴ´�.
using UnityEngine;                  //���ӽ����̽�. "UnityEngine�� API(��ǻ�� ���α׷� ������ ���� ����)�� �����´�."

public class DataController : MonoBehaviour   // Ŭ������ �̸��� �� C# Script�� �̸��� �����ؾ� �Ѵ�.
                                              // MonoBehaviour ��� Unity ��ũ��Ʈ�� �Ļ��Ǵ� �⺻ Ŭ����. <Behaviour <Component <Object. 
{
    public int m_gold = 0;              //��������(class �� ��� ������ ����� �� �ִ� ����). "���� gold ��� ������ ����� 0�� �����Ѵ�." ���� ��差.
    private int m_goldPerClick = 0;     //��������. "���� goldPerClick �̶�� ������ ����� 0�� �����Ѵ�." Ŭ�� �� ��差.

    private void Awake()          // ���� ����� �ʿ䰡 ���� Awake()�޼���. ��ũ��Ʈ �ν��Ͻ��� �ε��� ��, ������ ���۵Ǳ� ����, ��� ������ ������ ���¸� �ʱ�ȭ�ϱ� ���� �� �� �� ȣ��ȴ�. Start()�� �ٸ� ����, Awake()�� ��ũ��Ʈ���� ������ �����ϱ� ���� ����ϰ�, Start�� ������ ������ �޴� ��쿡 ����Ѵٴ� ���̴�.
    {
        //PlayerPrefs.DeleteAll();
        m_gold = PlayerPrefs.GetInt("Gold");                      // "PlayerPrefs(���� ���� ���̿� Preference�� �����ϰ�, �����ϴ� Ŭ����)���� "Gold"��� ���ǵǾ� �ִ� �����͸� �ε��Ѵ�." ��? �� ��° ������ �� �ε带 �ϰ� �̾ �۾��ؾ� �ϴϱ�.
        m_goldPerClick = PlayerPrefs.GetInt("GoldPerClick", 1);      // "PlayerPrefs���� "GoldPerClick"�̶�� ���ǵǾ� �ִ� �����͸� �ε��Ѵ�." �ʱ�ȭ�ϸ� ���� ��ȭ�� �ֱ� ���� �μ� 1�� �߰��ߴ�.
    }
    // **��差�� ������Ʈ���� �����ϴ� �޼���
    public void SetGold(int newGold)              //"���� newGold�� �Ű������� ���� ���� ��差 �޼��带 �����." Set~�� ���� ���̴� �Լ�. ��忡 �� �� ������ ��� ���� �����̴�. set�� ���� �����Ϳ� ���� ���� ��.
    {
        m_gold = newGold;                         //"�������� m_gold�� newGold�� �����Ѵ�." SetGold�޼����� �μ��� ��忡 �ֱ� ����. �ٵ� ��� �� ������ ��� ������ ����. newGold�� �ٽ� �ְ� �ۼ��Ұų�, �׳� ������ �Ź� �ֽ�ȭ�Ǵ� m_gold�� ���� ����Ұų�.
        PlayerPrefs.SetInt("Gold", m_gold);       //"PlayerPrefs�� "Gold"�� �ĺ��� Preference�� ���� m_gold�� �����Ѵ�." ��, ������Ʈ���� ���� �����Ѵ�.
    }
    // **��差 ������ ó���ϴ� �޼���.
    public void AddGold(int newGold)     // "���� newGold�� �Ű������� ���� AddGold�޼��带 �����." 
    {
        m_gold += newGold;               // "m_gold�� ���� m_gold + �μ� newGold ���� �����Ѵ�." 
        SetGold(m_gold);                 // "�׸���, �׷��� ���� m_gold ���� SetGold ��Ų��(=PlayerPrefs�� �����Ѵ�)."
    }

    public void SubGold(int newGold)     // "���� newGold�� �Ű������� ���� SubGold�޼��带 �����."
    {
        m_gold -= newGold;               // "m_gold�� ���� m_gold - �μ� newGold ���� �����Ѵ�."
        SetGold(m_gold);                 // "�׸���, �׷��� ���� m_gold ���� SetGold ��Ų��(=PlayerPrefs�� �����Ѵ�)."
    }

    public int GetGold()    // "������ GetGold() �޼��带 �����."
    {
        return m_gold;        // ���̵� ���¸� �ʿ� ���µ� int�� ��������� ��. "m_gold�� ���� �����ش�."
    }
    // **��带 Ŭ���� ������ �����ϴ� �޼���.
    public void SetGoldPerClick(int newGoldPerClick)           // "���� newGoldPerClick�� �Ű������� ���� ���� Ŭ�� �� ��差�� �޼���� �����."
    {
        m_goldPerClick = newGoldPerClick;                      //"�μ� newGoldPerClick�� ���� m_goldPerClick�� �����Ѵ�."
        PlayerPrefs.SetInt("GoldPerClick", m_goldPerClick);    //"PlayerPrefs�� "GoldPerClick"�� �ĺ��� Preference�� ���� m_goldPerClick�� �����Ѵ�."
    }

    public int GetGoldPerClick()        // "������ GetGoldPerClick() �޼��带 �����."
    {
        return m_goldPerClick;          // "m_goldPerClick�� ���� �����ش�."
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

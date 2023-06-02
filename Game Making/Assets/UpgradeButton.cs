using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;          // ����Ƽ API�� UI�� ��������.

public class UpgradeButton : MonoBehaviour        //28��
{
    public DataController dataController;   // DataController Ŭ���� �ν��Ͻ�ȭ.

    public Text upgradeDisplayer;     // UI�� Text upgradeDisplayer �� �����ϴ� ��.
    public string upgradeName;        // "���׷��̵�"�� �̸�.

    public int goldByUpgrade;            // goldByUpgrade(���׷��̵忡 ���� ������ ��差) ���� ����.
    public int startGoldByUpgrade = 1;   // ���׷��̵忡 ���� �����ϴ� ��差�� ó�� ��ġ �� ���� ������ �����ϰ� 1�� �ʱ�ȭ.

    public int currentCost;           // ���׷��̵� ��뿡 ���� ���� ����.
    public int startCurrentCost = 1;  // ���׷��̵� ����� ó�� ��ġ�� ���� ������ �����ϰ� 1�� �ʱ�ȭ.

    public int level = 1;    // ������ ���� ������ �����ϰ� 1�� �ʱ�ȭ.

    public float upgradePow = 1.14f;   // pow : �ŵ�����. ���� �׳� �����̸����� ��������.. ��·�� ���׷��̵� ���� ������ ����� 1.14f�� �ʱ�ȭ.
    public float costPow = 1.24f;     // ��� ���� ������ ����� 1.24f�� �ʱ�ȭ.



    void Start()                                   // ù �����ӿ� ����Ǵ� �͵�.
    {
        dataController.LoadUpgradeButton(this);    // ��������Ʈ�ѷ� Ŭ�������� LoadUpgradeButton �޼��带 �������� �μ��� �� Ŭ������ �־ ����.
        UpdateUI();                                // �Ʒ��� ���� UpdateUI �޼��� ����.
    }

    public void PurchaseUpgrade()     // �������� ���� ���μ���. ����.  //OnClick �̺�Ʈ�� �۵�(��ư ������Ʈ���� �����߱� ������).
    {
        if(dataController.GetGold() >= currentCost)   //�� ���� ���� ���� ����� ����Ѵ�. ���׷��̵� ��뺸�� ���� ���� �� ũ�ٸ�? �Ʒ� ����(���׷��̵�)����.
        {
            dataController.SubGold(currentCost);   // ���� ������ ���׷��̵� ����� ����.
            level += 1;                            // ������ 1 ������Ų��.
            dataController.AddGoldPerClick(goldByUpgrade);     // ��������Ʈ�ѷ��ʿ� �ۼ��� Ŭ�� �� ��差 �߰� �޼��带 ���׷��̵�Ǵ� ��差�� �μ��� �޾� �����Ų��.

            //Ŭ�� �� ��� ����� �κе� �����ϴ� �κ�.
            UpdateUpgrade();         // ���׷��̵�� ���õ� ���μ��� ����. �Ʒ� �޼���. 
            UpdateUI();              // UI�� ������Ʈ��.
            dataController.SaveUpgradeButton(this);    // ��������Ʈ�ѷ��� �ۼ��� ���׷��̵��ư ���� �޼��带 �� Ŭ������ �޾� ����.
        }
    }

    public void UpdateUpgrade()    // Ŭ�� �� ��巹���� �����ؾ� �ϰ�, ��뵵 �����ؾ� �ϴ� ���׷��̵� �Ǵ� ���� ������Ʈ �ϴ� �޼���. // ���� �� �Լ� ���� ��ü�̽����׷��̵忡 �־ �Ǵµ� ���߿� ���⿡ �� �� �߰����� ���ϱ� �̷��� ���� �и�.
    {
        goldByUpgrade = startGoldByUpgrade * (int)Mathf.Pow(upgradePow, level);  // ���׷��̵� �Ǵ� ��差�� ���� ���׷��̵� ��差(1) x (upgradePow�� ��(1.14f)�� ������ŭ �����ϰ�, ����ȭ �� ��)�̴�.
        currentCost = startCurrentCost * (int)Mathf.Pow(costPow, level);   // ���׷��̵� �����, costPow(1.24f)�� level��ŭ �ŵ������� �� ���̴�.
    }

    public void UpdateUI()      // ó�� UI���� �����ִ� ���� �����ϴ� �޼���.
    {
        upgradeDisplayer.text = "���� ����: "+ upgradeName + "\n" + "�ʿ� ���: " + currentCost + "\n" + "����: " + level + "\n" + "ȹ�� ���� ��� +" + goldByUpgrade;    //upgradeName�� ��Ʈ���̶�.
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;   // ����Ƽ������ UI�� ������ �� �ִ� API ȣ��.

public class UIManager : MonoBehaviour
{
    public Text goldDisplayer;                // �����÷��̾��� text ���� ����.
    public Text goldPerClickDisplayer;        // Ŭ�� �� ��差 ���÷��̾��� text���� ����.
    public DataController dataController;      // �ν��Ͻ�ȭ

    void Start()
    {

    }

    void Update()     //�� ������Ʈ���� ����ǵ���.
    {
        goldDisplayer.text = "Gold : " + dataController.GetGold();   // text�� �츮�� �����÷��̾ �ؽ�Ʈ�� �ֱ� ������, ���� ���⿡ ���� ������ ������ �츮�� ���� UI�� �߰��߱� ������.  = dataController.GetGold().ToString(); �ص� ��差�������� ���̱� ��.
        goldPerClickDisplayer.text = "Gold Per Click : " + dataController.GetGoldPerClick();    // Ŭ�� �� ��差 ���÷��̾��� �ؽ�Ʈ�� "Gold Per Click : " �̶� ���ڿ��� ��������Ʈ���� GetGoldPerClick() ���ϰ��� �����.



    }
}

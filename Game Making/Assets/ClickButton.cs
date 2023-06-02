using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickButton : MonoBehaviour
{
    public DataController dataController;
    public int gold;

    public void Awake()
    {
        gold = dataController.m_gold;
    }

    public void OnClick()
    {
        int goldPerClick = dataController.GetGoldPerClick();
        dataController.AddGold(goldPerClick);
    }
}
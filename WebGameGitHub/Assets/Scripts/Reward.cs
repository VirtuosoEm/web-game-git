using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using YG;

public class Reward : MonoBehaviour
{
    public string rewardID;
    public int coins;

    public void MyRewardAdvShow()
    {
        YG2.RewardedAdvShow(rewardID, () =>
        {
            // ��������� ��������������
            //coins++;
            SelectItems._money+=100;
            PlayerPrefs.SetInt("Money", SelectItems._money);

            // �� �������, �������������� ID ��������������
            if (rewardID == "AddCoin")
                coins++;
        });
    }
}

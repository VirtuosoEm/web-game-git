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
            // Получение вознаграждения
            //coins++;
            SelectItems._money+=100;
            PlayerPrefs.SetInt("Money", SelectItems._money);

            // По желанию, воспользуйтесь ID вознаграждения
            if (rewardID == "AddCoin")
                coins++;
        });
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YG;

namespace YG
{
    public partial class SavesYG
    {
        // ���� ������ ��� ����������
        public int coins = 5; // ������
    }
}

public class SaveProgress : MonoBehaviour
{
    public void Save()
    {
        YG2.saves.coins += 10;
    }
    
}

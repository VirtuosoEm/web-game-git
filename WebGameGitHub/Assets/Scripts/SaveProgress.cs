using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YG;

namespace YG
{
    public partial class SavesYG
    {
        // Ваши данные для сохранения
        public int coins = 5; // Пример
    }
}

public class SaveProgress : MonoBehaviour
{
    public void Save()
    {
        YG2.saves.coins += 10;
    }
    
}

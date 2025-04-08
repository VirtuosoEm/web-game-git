using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YG;

namespace YG
{
    public partial class SavesYG
    {
        // Ваши данные для сохранения
        public int coins = 100; // Пример
        public int indexBall;
        public int ball;
        public List<string> nameBall;
    }
}

public class SaveProgress : MonoBehaviour
{
    public static SaveProgress instance;
    public void DefoltSave()
    {
        //YG2.saves.coins = 10;
        //YG2.saves.indexBall = 0;
        PlayerPrefs.DeleteAll();
        

    }
    
}

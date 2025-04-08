using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static int Money; // Монеты
    public static int LevelIndex; // индекс уровня
    public GameObject planeLevelse;

    public Button[] buttons;
    private int levelUnLock;
    public static bool startOpenLevel;
    public static int maxCountButtons;

    void Start()
    {
        planeLevelse.SetActive(false);

        maxCountButtons = buttons.Length; // присваиваю количество кнопок в массиве в переменную статичную
        Debug.Log("Максимальное количество кнопок " + maxCountButtons);
        //levelUnLock = YandexGame.savesData.openLevel;
        levelUnLock = PlayerPrefs.HasKey("LevelUnlock") ? PlayerPrefs.GetInt("LevelUnlock") : 2;
        //Debug.Log("открытый уровень" + levelUnLock.ToString());
        //Debug.Log("полученый уровень из сохранения" + YandexGame.savesData.openLevel);

        for (int i = 0; i < buttons.Length; i++)     // проверяет какие уровни не были пройдены и  их блокирует 
        {
            buttons[i].interactable = false;
            buttons[i].GetComponentInChildren<TextMeshProUGUI>().text = (i + 1).ToString();
            buttons[i].GetComponent<Image>().color = Color.gray;
            buttons[i].transform.Find("Lock").gameObject.SetActive(true);
        }


        for (int i = 0; i < levelUnLock + 1; i++)      // разблокирует уровни по мере прохождения 
        {
            if (i < buttons.Length)
            {
                buttons[i].interactable = true;
                buttons[i].GetComponent<Image>().color = Color.white;
                buttons[i].transform.Find("Lock").gameObject.SetActive(false);
            }
        }
    }

    private void Update()
    {
        if (startOpenLevel == true)
        {
            OpenLevel();
            startOpenLevel = false;
        }
    }

    public void OpenLevel()
    {
        levelUnLock = PlayerPrefs.HasKey("LevelUnlock") ? PlayerPrefs.GetInt("LevelUnlock") : 1;
        //levelUnLock = YandexGame.savesData.openLevel;

        for (int i = 0; i < buttons.Length; i++)     // проверяет какие уровни не были пройдены и  их блокирует 
        {
            buttons[i].interactable = false;
            buttons[i].GetComponentInChildren<TextMeshProUGUI>().text = (i + 1).ToString();
            buttons[i].GetComponent<Image>().color = Color.gray;
            buttons[i].transform.Find("Lock").gameObject.SetActive(true);
        }


        for (int i = 0; i < levelUnLock + 1; i++)      // разблокирует уровни по мере прохождения 
        {
            if (i < buttons.Length)
            {
                buttons[i].interactable = true;
                buttons[i].GetComponent<Image>().color = Color.white;
                buttons[i].transform.Find("Lock").gameObject.SetActive(false);
            }
        }

    }

    public void LoadLevelse(int level)
    {
        SceneManager.LoadScene(level);
    }


    public void OpenClosedLevelsePanel()
    {
        planeLevelse.SetActive(!planeLevelse.activeSelf);
    }
    
}

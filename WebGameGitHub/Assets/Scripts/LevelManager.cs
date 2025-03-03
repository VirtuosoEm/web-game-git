using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    /*public static LevelManager instance = null;

    private void Start()
    {
        if (instance == null)
        { 
            instance = this; 
        }
        else if (instance == this)
        {
            Destroy(gameObject);
        }

        
        DontDestroyOnLoad(gameObject);
    }
    */

    public void MenuButton()
    {
        PlayerPrefs.SetInt("Money", SelectItems._money);
        Debug.Log("Menu");
        SceneManager.LoadScene(0);
        
    }
    public void GameButton()
    {
        SceneManager.LoadScene(1);
        GameManager.LevelIndex = 1;
    }
    

}

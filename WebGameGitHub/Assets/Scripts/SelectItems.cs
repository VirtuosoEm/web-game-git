using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using YG;


public class SelectItems : MonoBehaviour
{
    //[SerializeField] private int _money;
    public static int _money;
    [SerializeField] private TextMeshProUGUI _moneyText;
    private const string MONEY_TAG = "Money";


    private Transform _itemParent;
    [SerializeField] private List<Item> _items;

    [SerializeField] private TextMeshProUGUI _selectText;
    [SerializeField] private TextMeshProUGUI _buyButtonText;
    [SerializeField] private GameObject _buyButton;

    [SerializeField] private string _key;
    private int _currentIndex;
    private int _savedItemIndex;

    private void Start()
    {
        //_money = PlayerPrefs.HasKey(MONEY_TAG) ? PlayerPrefs.GetInt(MONEY_TAG) : 1000;
        _money = YG2.saves.coins;
        _moneyText.text = $"Денег: {_money}$";


        _itemParent = GetComponent<Transform>();
        _items[0].IsPurchased = true;

        for (int i = 1; i < _items.Count; i++)
            _items[i].InitializeItem();

        for (int i = 0; i < _itemParent.childCount; i++)
            _itemParent.GetChild(i).gameObject.SetActive(false);

        _savedItemIndex = PlayerPrefs.HasKey(_key) ? PlayerPrefs.GetInt(_key) : 0;
        /*if (YG2.saves.ball != 0)
        {
            _savedItemIndex = YG2.saves.indexBall;
        }
        else
        {
            _savedItemIndex = 0;
        }*/

        //_savedItemIndex = YG2.saves.indexBall;
        //Debug.Log("индекс мяча " + YG2.saves.indexBall);
        _currentIndex = _savedItemIndex;

        _itemParent.GetChild(_savedItemIndex).gameObject.SetActive(true);
        UpdateItem();

    }

    public void SelectLeft()
    {
        _itemParent.GetChild(_currentIndex).gameObject.SetActive(false);

        if (_currentIndex - 1 >= 0)
        {
            _currentIndex--;
        }
        else
        {
            _currentIndex = _itemParent.childCount - 1;
        }

        _itemParent.GetChild(_currentIndex).gameObject.SetActive(true);
        UpdateItem();
    }

    public void SelectRight()
    {
        _itemParent.GetChild(_currentIndex).gameObject.SetActive(false);
        if (_currentIndex + 1 < _itemParent.childCount)
        {
            _currentIndex++;
        }
        else
        {
            _currentIndex = 0;
        }

        _itemParent.GetChild(_currentIndex).gameObject.SetActive(true);
        UpdateItem();
    }

    private void UpdateItem()
    {
        _selectText.text = _savedItemIndex == _currentIndex ? "Выбрано" : "Выбрать";

        if (_currentIndex < _items.Count)
        {
            _buyButton.SetActive(_items[_currentIndex].IsPurchased == false);
            _buyButtonText.text = $"Цена: {_items[_currentIndex].Cost}$";
        }
        else
            _buyButton.SetActive(false);
    }

    public void BuyItem()
    {
        if (_money >= _items[_currentIndex].Cost)
        {
            _money -= _items[_currentIndex].Cost;
            _moneyText.text = $"Денег: {_money}$";

            _buyButton.SetActive(false);
            _items[_currentIndex].SavePurchase();
            SaveItem();
            PlayerPrefs.SetInt(MONEY_TAG, _money);
            //YG2.saves.coins = _money;
        }
    }

    public void SaveItem()
    {
        PlayerPrefs.SetInt(_key, _currentIndex);
        PlayerPrefs.SetInt("Ball", _currentIndex);
        //Debug.Log("Я в сохранении и сохранять должен" + _key + " -- это _key;");

        //YG2.saves.indexBall = _currentIndex;
        //YG2.saves.ball = _currentIndex;

        _savedItemIndex = _currentIndex;
        _selectText.text = "Выбрано";
    }

    /*public void DeleteSave()
    {
        //PlayerPrefs.DeleteAll();
        SaveProgress.instance.DefoltSave();
    }*/


}
[System.Serializable]
public class Item 
{
    [SerializeField] private string _key = "item";

    public bool IsPurchased = false;
    public int Cost;

    public void InitializeItem()
    {
        IsPurchased = PlayerPrefs.HasKey(_key) ? PlayerPrefs.GetInt(_key) == 1 : false;
        /*if (YG2.saves.nameBall.Contains(_key))
        {
            IsPurchased = true;
        }
        else
        {
            IsPurchased = false;
        }*/


        /*if (YG2.saves.indexBall == 1)
        {
            IsPurchased = true;
        }
        else
        {
            IsPurchased = false;
        }*/


    } 
        
        
    
    public void SavePurchase()
    {
        PlayerPrefs.SetInt(_key, 1);
        //YG2.saves.nameBall.Add(_key);
        //YG2.saves.indexBall = 1;
        IsPurchased = true;
    }
}


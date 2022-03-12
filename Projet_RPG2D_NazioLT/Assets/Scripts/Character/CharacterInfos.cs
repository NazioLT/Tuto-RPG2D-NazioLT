using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public enum ItemsID
{
    Money = 0,
}

[System.Serializable]
public class Item
{
    [SerializeField] private string name;
    [SerializeField] public ItemsID ID;

    public int number;
}

public class CharacterInfos : MonoBehaviour
{
    private static Item[] inventory;
    private int maxHealth = 5;
    public static int health = 5;

    [SerializeField] private Transform heartPrefab;
    [SerializeField] private Transform heartParent;
    private List<GameObject> heartsObj = new List<GameObject>();

    private GameManager manager;
    [SerializeField] private TextMeshProUGUI moneyTxt;

    private void Start()
    {
        manager = GameManager.GetInstance();
        inventory = new Item[1];
        inventory[0] = new Item();

        InitHealth();
    }

    private void Update()
    {
        moneyTxt.text = " : " + inventory[(int) ItemsID.Money].number;
    }

    private void InitHealth()
    {
        health = maxHealth;

        for (int i = 0; i < maxHealth; i++)
        {
            Transform curHeart = Instantiate(heartPrefab);
            curHeart.SetParent(heartParent);
            heartsObj.Add(curHeart.gameObject);
        }

    }

    private void TakeDamage(int _damage)
    {
        health -= _damage;

        //ReAffiche les coeurs
        for (int i = 1; i < maxHealth + 1; i++)
        {
            if (i <= health)
            {
                heartsObj[i-1].SetActive(true);
            }
            else
            {
                heartsObj[i-1].SetActive(false);
            }
            
        }
    }
    
    public static void AddItem(ItemsID _id, int _number)
    {
        inventory[(int) _id].number += _number;
    }
}

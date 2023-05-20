using UnityEngine;

[System.Serializable]
public class Item
{
    [SerializeField] private string name;
    
    public ItemID _id;
    public int number = 0;
}

using UnityEngine;

[System.Serializable]
public class Dialogue
{
    [SerializeField] private string characterName;
    [SerializeField, TextArea(5,5)] private string content;
    [SerializeField] private Sprite charSprite;

    public string getName => characterName;
    public string getContent => content;
    public Sprite getCharSprite => charSprite;
}

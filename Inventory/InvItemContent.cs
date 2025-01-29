using UnityEngine;

[System.Serializable]
public struct InvItemContent
{

    public string id;
    public Sprite sprite;
    [TextArea(3, 5)]
    public string description;

}

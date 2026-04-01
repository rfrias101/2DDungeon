using System.Xml.Linq;
using UnityEngine;
using UnityEngine.UI;

public abstract class NPC : WorldEntity, ITalkable
{
    protected string npcName;
    protected string dialogue;

    protected NPC(NPCData data)
    {
        npcName = data.npcName;
        dialogue = data.dialogue;
    }

    public abstract void Talk();
    public abstract void Interact();
}

[System.Serializable]
public class NPCData
{
    public string npcName;
    [TextArea] public string dialogue; 
}

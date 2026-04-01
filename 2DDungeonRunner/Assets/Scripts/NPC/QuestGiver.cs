using UnityEngine;

public class QuestGiver : NPC
{
    public QuestGiver(NPCData data) : base(data) { }

    public override void Talk()
    {
        Debug.Log($"{npcName}: I have a quest for you!");
    }

    public override void Interact()
    {
        Talk();
    }
}

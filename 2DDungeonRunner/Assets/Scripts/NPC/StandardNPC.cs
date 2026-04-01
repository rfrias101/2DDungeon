using UnityEngine;

public class StandardNPC : NPC
{
    public StandardNPC(NPCData data) : base(data) { }

    public override void Talk()
    {
        Debug.Log($"{npcName}: {dialogue}");
    }

    public override void Interact()
    {
        Talk();
    }
}

using UnityEngine;
public class NPCController : MonoBehaviour, IInteractable
{
    public enum NPCType { QuestGiver, StandardNPC }
    [SerializeField] private NPCType npcType;
    [SerializeField] private NPCData data;
    [SerializeField] private NPCAIMovement _aiMovement;
    private NPC _npc;

    void Awake()
    {
        if (npcType == NPCType.QuestGiver)
            _npc = new QuestGiver(data);
        else if (npcType == NPCType.StandardNPC)
            _npc = new StandardNPC(data);
    }

    public void Interact()
    {
        _aiMovement.StopForInteraction();
        _npc.Interact();
    }

    public void ResumeMovement()
    {
        _aiMovement.ResumeAfterInteraction();
    }
}
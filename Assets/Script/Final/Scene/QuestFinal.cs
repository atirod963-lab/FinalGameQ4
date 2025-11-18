using UnityEngine;

[System.Serializable]
public class QuestFinal
{
    public string sceneName;

    [Header("Main Objective")]
    public string mainQuestName;        
    public int mainKillRequired = 0;    

    [Header("Optional Objective")]
    public string optionalDescription;  
}

using UnityEngine;
using TMPro;

public class QuestUI : MonoBehaviour
{
    public TMP_Text questText;

    private void Start()
    {
        UpdateQuestUI();
    }

    private void Update()
    {
        UpdateQuestUI();
    }

    void UpdateQuestUI()
    {
        if (QuestManagerFinal.instance.currentQuest == null)
        {
            questText.text = "No Quest";
            return;
        }

        var quest = QuestManagerFinal.instance.currentQuest;
        int currentKills = KillManager.instance.totolkilcount;

        // ⭐ แสดงชื่อ Quest หลัก
        string main = $"{quest.mainQuestName}: {currentKills}/{quest.mainKillRequired}";
        string optional = quest.optionalDescription;

        questText.text = main + "\n" + optional;
    }
}

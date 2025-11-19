using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerLoadScene : Item
{
    public AudioClip BackgroundMusic;
    public string LoadSceneName;
    public string SpawnID;

   

    public override void OnCollect(Player player)
    {
        base.OnCollect(player);

        int required = QuestManagerFinal.instance.currentQuest.mainKillRequired;
        int currentKills = KillManager.instance.totolkilcount;

        if (currentKills < required)
        {
            Debug.Log($"ต้องฆ่าอย่างน้อย {required} ตัวก่อนจะไป {LoadSceneName}");
            return;
        }

        LoadSceneManager.instance.NextSpawnID = SpawnID;
        LoadSceneManager.instance.LoadNewScene(LoadSceneName);

        SoundManager.instance.PlayMusic(BackgroundMusic);

        KillManager.instance.ResetKill();
    }

}

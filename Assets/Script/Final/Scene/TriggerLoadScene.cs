using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerLoadScene : Item
{
    public AudioClip BackgroundMusic;
    public string LoadSceneName;
    public string SpawnID;

    private int GetRequiredKill()
    {
        string currentScene = SceneManager.GetActiveScene().name;

        if (currentScene == "MainGame" && LoadSceneName == "Room1") return 0;
        if (currentScene == "Room1" && LoadSceneName == "Room2") return 3;
        if (currentScene == "Room2" && LoadSceneName == "Room3") return 4;
        if (currentScene == "Room3" && LoadSceneName == "Dungeons") return 5;

        return 0;
    }

    public override void OnCollect(Player player)
    {
        base.OnCollect(player);

        int required = GetRequiredKill();
        int currentKills = KillManager.instance.killCount;

        if (currentKills < required)
        {
            Debug.Log($"ต้องฆ่าอย่างน้อย {required} ตัวก่อนจะไป {LoadSceneName} (ตอนนี้ฆ่า {currentKills})");
            return;
        }

        LoadSceneManager.instance.NextSpawnID = SpawnID;
        LoadSceneManager.instance.LoadNewScene(LoadSceneName);

        SoundManager.instance.PlayMusic(BackgroundMusic);

        KillManager.instance.ResetKill();
    }
}

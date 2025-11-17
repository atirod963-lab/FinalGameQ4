using UnityEngine;

public class TriggerLoadScene : Item
{
    public AudioClip BackgroundMusic;
    public string LoadSceneName;

    [Header("Spawn Setting")]
    public string SpawnID;  // ⭐ จุด spawn ที่จะให้ผู้เล่นไปเกิดตอนเข้าซีนถัดไป

    public override void OnCollect(Player player)
    {
        base.OnCollect(player);

        // ส่ง ID ไปให้ซีนถัดไป
        LoadSceneManager.instance.NextSpawnID = SpawnID;

        // โหลดซีน
        LoadSceneManager.instance.LoadNewScene(LoadSceneName);

        // เล่นเพลงพื้นหลัง
        SoundManager.instance.PlayMusic(BackgroundMusic);
    }
}

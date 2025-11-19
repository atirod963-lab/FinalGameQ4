using UnityEngine;
using UnityEngine.SceneManagement;

public class QuestManagerFinal : MonoBehaviour
{
    public static QuestManagerFinal instance;

    public QuestFinal currentQuest;
    public QuestFinal[] quests; // ใส่ข้อมูลแต่ละห้องใน Inspector

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(gameObject);

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        LoadQuestForScene(scene.name);
    }

    public void LoadQuestForScene(string sceneName)
    {
        foreach (var q in quests)
        {
            if (q.sceneName == sceneName)
            {
                currentQuest = q;
                KillManager.instance.ResetKill();

                Debug.Log("Loaded quest for " + sceneName);
                Debug.Log("Main: Kill " + q.mainKillRequired);
                Debug.Log("Optional: " + q.optionalDescription);

                return;
            }
        }

        currentQuest = null;
        Debug.Log("No quest for scene: " + sceneName);
    }

    public bool IsMainQuestComplete()
    {
        if (currentQuest == null) return true;

        return KillManager.instance.totolkilcount >= currentQuest.mainKillRequired;
    }
}

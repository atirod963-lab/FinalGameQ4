using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSpawnSetter : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        string spawnID = LoadSceneManager.instance.NextSpawnID;

        SpawnPoint[] spawnPoints = FindObjectsOfType<SpawnPoint>();

        foreach (var sp in spawnPoints)
        {
            if (sp.SpawnID == spawnID)
            {
                transform.position = sp.transform.position;
                transform.rotation = sp.transform.rotation;

                Debug.Log($"Player spawned at SpawnID: {spawnID}");
                return;
            }
        }

        Debug.LogWarning($"No SpawnPoint found for ID: {spawnID}");
    }
}
    
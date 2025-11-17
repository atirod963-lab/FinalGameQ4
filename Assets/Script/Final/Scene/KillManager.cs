using UnityEngine;

public class KillManager : MonoBehaviour
{
    public static KillManager instance;

    public int killCount = 0;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(gameObject);
    }

    public void AddKill()
    {
        killCount++;
    }

    public void ResetKill()
    {
        killCount = 0;
    }
}

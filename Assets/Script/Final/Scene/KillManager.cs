using UnityEngine;

public class KillManager : MonoBehaviour
{
    public static KillManager instance;

    public int totolkilcount = 0;
    public int KillCountUpgrate = 0;

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
        totolkilcount++;
        KillCountUpgrate++;
    }

    public void ResetKill()
    {
        totolkilcount = 0;
    }
}

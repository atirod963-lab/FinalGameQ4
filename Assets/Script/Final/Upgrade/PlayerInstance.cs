using UnityEngine;

public class PlayerInstance : MonoBehaviour
{
    private static PlayerInstance instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);  // ⭐ Player อยู่ข้ามซีน
        }
        else
        {
            Destroy(gameObject);  // ป้องกัน Player ซ้ำ
        }
    }
}

using UnityEngine;

public class TargetFinder : MonoBehaviour
{
    public Transform player;         
    public Transform currentTarget;

    [Header("Target Tags")]
    public string monsterTag = "Enemy";
    public string warpTag = "WarpGate";

    private void Start()
    {
        if (player == null)
            player = FindAnyObjectByType<Player>().transform;
    }

    void Update()
    {
        if (currentTarget == null)
        {
            currentTarget = FindClosestMonster();
            if (currentTarget == null)
                currentTarget = FindWarpGate();
        }
    }

    public Transform FindClosestMonster()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(monsterTag);

        Transform closest = null;
        float minDist = Mathf.Infinity;

        foreach (var e in enemies)
        {
            float dist = Vector3.Distance(player.position, e.transform.position);
            if (dist < minDist)
            {
                minDist = dist;
                closest = e.transform;
            }
        }

        return closest;
    }

    public Transform FindWarpGate()
    {
        GameObject gate = GameObject.FindWithTag(warpTag);
        return gate ? gate.transform : null;
    }
}

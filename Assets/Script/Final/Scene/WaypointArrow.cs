using UnityEngine;

public class WaypointArrow : MonoBehaviour
{
    public RectTransform arrowUI;
    public TargetFinder finder;

    private void Start()
    {
        if (finder == null)
            finder = FindAnyObjectByType<TargetFinder>();
    }

    void Update()
    {
        if (finder == null || finder.player == null || finder.currentTarget == null)
            return;

        Vector3 dir = finder.currentTarget.position - finder.player.position;
        float angle = Mathf.Atan2(dir.x, dir.z) * Mathf.Rad2Deg;

        arrowUI.rotation = Quaternion.Euler(0, 0, -angle);
    }
}

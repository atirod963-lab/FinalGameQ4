using UnityEngine;
using TMPro;

public class WeaponUIManager : MonoBehaviour
{
    public static WeaponUIManager Instance;

    [Header("Status UI (โชว์ตลอด)")]
    public TMP_Text weaponStatusText;

    [Header("Floating Upgrade Text (โชว์เฉพาะตอนอัปเกรด)")]
    public TMP_Text floatingText;
    public float fadeDuration = 1.5f;

    private void Awake()
    {
        Instance = this;
    }

    // อัปเดตข้อมูลอาวุธตลอดเวลา
    public void UpdateWeaponStatus(string text)
    {
        if (weaponStatusText != null)
            weaponStatusText.text = text;
    }

    // ข้อความตอนอัปเกรด แล้วค่อยจางหายไป
    public void ShowFloatingText(string text)
    {
        if (floatingText == null) return;

        floatingText.text = text;
        floatingText.alpha = 1;

        StopAllCoroutines();
        StartCoroutine(FadeOut());
    }

    private System.Collections.IEnumerator FadeOut()
    {
        float t = 0;
        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            floatingText.alpha = Mathf.Lerp(1, 0, t / fadeDuration);
            yield return null;
        }
    }
}

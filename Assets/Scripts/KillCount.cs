using UnityEngine;
using UnityEngine.UI;
public class KillCount : MonoBehaviour
{
    public Text killText;
    public static int currentKillCount;
    void Start()
    {
        currentKillCount = 0;
    }
    void Update()
    {
        killText.text = string.Format("{0:000}", currentKillCount);
    }
}

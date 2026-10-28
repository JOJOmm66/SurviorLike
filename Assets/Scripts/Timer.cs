using UnityEngine;
using UnityEngine.UI;
public class gameTimer : MonoBehaviour
{
    public float leftTime;
    public float maxTime;
    public Slider timeSlider;
    public GameObject gameOverCanvas;
    public Image imageWin;
    public Text timeText;
    public bool isWin = false;
    public void WinToGameOver()
    {
        if (isWin) return;
        if (leftTime>0)
        {
            leftTime -= Time.deltaTime;
            if(leftTime<0) leftTime = 0f;
            timeSlider.value=(maxTime-leftTime)/maxTime;
            timeText.text = FormatTime(leftTime);
        }
        else
        {
            isWin = true;
            Time.timeScale = 0;
            gameOverCanvas.SetActive(true);
            imageWin.gameObject.SetActive(true);
            PlayerAudio.playerAudio.playerWinAudio();
        }
    }
    public string FormatTime(float time)
    {
        int second = Mathf.FloorToInt(time % 60);
        float minute = Mathf.FloorToInt(time / 60);
        return string.Format("{0:00}:{1:00}", minute, second);

    }
    void Start()
    {
        leftTime = maxTime;
    }

    void Update()
    {
        WinToGameOver();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class SceneGreenRectClick : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler
{
    public Image image = null;
    public void OnPointerEnter(PointerEventData eventData)
    {
        Color c = image.color;
        c.a=1;
        image.color=c;
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        Color c = image.color;
        c.a = 0;
        image.color = c;
    }
    public void OnStartClick()
    {
        SceneManager.LoadScene("GameScene");
    }
    public void OnSettingsClick()
    {
        SceneManager.LoadScene("SettingsScene");
    }
    public void OnQuitClick()
    {
        Application.Quit();
    }
    public void OnReStartClick()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("GameScene");
    }
    void Start()
    {

    }
    void Update()
    {
        
    }
}

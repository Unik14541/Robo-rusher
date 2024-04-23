using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    [SerializeField] Sprite onPauseSprite;
    [SerializeField] Sprite offPauseSprite;
    [SerializeField] Image pauseImage;
    [SerializeField] TMP_Text pauseText;
    bool isPause = false;
    [SerializeField] GameObject backMenuButton;
    [SerializeField] GameObject panelTrigger;
    void Start () {
        pauseImage.sprite = offPauseSprite;
        pauseText.text = "";
        backMenuButton.SetActive(false);
    }
    public bool IsPause() {
        return isPause;
    }
    public void SetPause() {
        isPause = !isPause;
        if (isPause) {
            pauseImage.sprite = onPauseSprite;
            pauseText.text = "Pause";
            backMenuButton.SetActive(true);
            panelTrigger.SetActive(false);
        }
        else {
            pauseImage.sprite = offPauseSprite;
            pauseText.text = "";
            backMenuButton.SetActive(false);
            panelTrigger.SetActive(true);
        }
    }
    public void BackToMenu() {
        SceneManager.LoadScene("Menu");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] int indexLevelScene;
    [SerializeField] int indexInfiniteScene;
    void SetActiveScene(int active){
        SceneManager.LoadScene(active);
    }
    public void ActiveScene(){
        SceneManager.LoadScene(indexLevelScene);
    }
    public void Activeinfinite() {
        SetActiveScene(indexInfiniteScene);
    }
}

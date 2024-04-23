using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] int indexMainScene;
    [SerializeField] float loadDelayCrash = 1f;
    [SerializeField] float loadDelayWin = 5f;
    Animator anim;
    private void StopPlayer(){
        GetComponent<Playermove>().enabled = false;
        GetComponentInChildren<PlayerShooting>().enabled = false;
        FindObjectOfType<ScoreCount>().CantCount();
    }
    private void Awake() {
        anim = GetComponentInChildren<Animator>();
    }
    private void LoadMainScene() {
        SceneManager.LoadScene(indexMainScene);
    }
    private void Crash() {
        anim.SetTrigger("die");
        StopPlayer();
        Invoke("LoadMainScene", loadDelayCrash);
    }
    private void Win(){
        anim.SetTrigger("Win");
        StopPlayer();
        Invoke("LoadMainScene", loadDelayWin);
    }
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.GetComponent<Finish>() != null) {
            other.gameObject.GetComponent<Finish>().AddBustLevel();
            Win();
        }
    }
    private void OnControllerColliderHit(ControllerColliderHit hit) {
        if(hit.gameObject.GetComponent<Enemy>() != null)
        {
            hit.gameObject.GetComponent<Enemy>().Attack();
            Crash();
        }
    }
}
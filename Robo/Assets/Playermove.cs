using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Playermove : MonoBehaviour
{
    CharacterController chControl;
    [SerializeField] float speedMove, speedSide, gravity, lineDistance;
    [SerializeField] int indexLine = 1;
    Pause pause;
    [SerializeField]Animator anim;
    void Start()
    {
        pause = FindObjectOfType<Pause>();
        chControl = GetComponent<CharacterController>();
    }

    void Update()
    {
        if(pause.IsPause() == false) 
        {
        chControl.Move(new Vector3(0, gravity, speedMove) * Time.deltaTime);

        Vector3 targetPos = transform.position.z * transform.forward + transform.position.y * transform.up;
        if(indexLine == 0){
            targetPos += Vector3.left * lineDistance;
        }
        else if(indexLine == 2){
            targetPos += Vector3.right * lineDistance;
        }
        transform.position = targetPos;


            anim.SetBool("IsMove", true);
        }
        else
        {
            anim.SetBool("IsMove", false);
        }
    }
    public void MoveSide (bool isRight) {
        if(isRight) {
            if(indexLine < 2) {
                indexLine++;
            }
        }
        else if(!isRight){
            if(indexLine > 0){
                indexLine--;
            }
        }
    }
}

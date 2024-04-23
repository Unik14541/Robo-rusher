using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] LayerMask enemyLayer;
    [SerializeField] float distanceToShoot;
    private AudioSource audioO;
    ParticleSystem shootParticle;
    void Start()
    {
        audioO = GetComponent<AudioSource>();
        shootParticle = GetComponent<ParticleSystem>();
    }
    void Shoot() 
    {
       shootParticle.enableEmission = true;
       if(audioO.isPlaying == false) {
        audioO.Play();
       }
    }
    void StopShoot() {
      shootParticle.enableEmission = false;
      audioO.Stop();
    }
    void Update()
    {
       RaycastHit hit;
       Vector3 fwd = transform.TransformDirection(Vector3.forward);
       if(Physics.Raycast(transform.position, fwd, out hit, distanceToShoot, enemyLayer)){
         Shoot();
       }
       else{
        StopShoot();
       }
    }
}

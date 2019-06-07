using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class BulletScript : CameraScript
{
    public GameObject bulletPref;
    public Transform muzzle;
    public float power = 40f;
    private GameObject bullet;

    void Start(){

    }

    void Update(){
        if(Input.GetButtonDown("Fire1")){
        	Shot();
        }
    }
    void Shot(){
    	bullet = Instantiate(bulletPref, muzzle.position, muzzle.rotation);
        bullet.tag = "bullet";
    	bullet.GetComponent<Rigidbody>().AddForce(bullet.transform.forward * power, ForceMode.Impulse);
    	Destroy(bullet, 60f);
    }
    void OnCollisionEnter (Collision bulletGameObject){
        if(bulletGameObject.gameObject.tag == "enemy"){
            Destroy(bulletGameObject.gameObject);
            Destroy(gameObject);
        }else if(bulletGameObject.gameObject.tag == "wall"){
            Destroy(gameObject);
        }
    }
}

using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;


public class CameraScript : MonoBehaviour{
	float x;
    float y;
    float z;

    int hp = 100;

    Rigidbody rb;
    
    public Text tx;
    
    void Start(){
    	x = transform.position.x;
        y = transform.position.y;
        z = transform.position.z;

        rb = GetComponent<Rigidbody>();

        tx.text = "hp:" + hp;
    }

    void Update(){
        float moveVertical = Input.GetAxis("Vertical");
        rb.AddForce(transform.forward * moveVertical * 40f);
        float moveHorizontal = Input.GetAxis("Horizontal");
        rb.AddForce(transform.forward * moveHorizontal * 30f); 
    }
    void OnCollisionEnter (Collision playerGameObject){
        if(playerGameObject.gameObject.tag == "enemy"){
            hp -= 10;
            tx.text = "hp:" + hp;
    	}else if(hp==0){
                SceneManager.LoadScene(1);
        }
        if(playerGameObject.gameObject.tag == "cactus"){
                hp -= 5;
                tx.text = "hp:" + hp;
            
        }else if(hp==0){
                SceneManager.LoadScene(1);
        }
    }
}
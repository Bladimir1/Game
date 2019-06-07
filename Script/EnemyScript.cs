using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class EnemyScript : MonoBehaviour
{
    public Transform player;
    NavMeshAgent agent;
    static int score;
    public Text txScore;
    public void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        score = 0;
        txScore.text = "Score:" + txScore;
    }

    void Update()
    {
        agent.SetDestination(player.position);
    }
    public void OnCollisionEnter (Collision Damage){
        if(Damage.gameObject.tag == "bullet"){
            score += 5;
            Debug.Log(score);
            txScore.text = "Score:" + score;
            Destroy(gameObject);
            Destroy(Damage.gameObject);
            if(score==35){
                SceneManager.LoadScene(0);
                score=0;
            }
        }
    }
}
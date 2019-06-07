using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour
{
	public void SceneSwitcher(){
		SceneManager.LoadScene(2);
	}
}

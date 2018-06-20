using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menus_MiniGame : MonoBehaviour {

	
	public void ChangeScene(int index) {
		SceneManager.LoadScene(index);
	}

	public void QuitGame() {
		Application.Quit();
	}
}

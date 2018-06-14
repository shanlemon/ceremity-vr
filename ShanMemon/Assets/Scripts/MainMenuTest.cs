using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuTest : MonoBehaviour {

	[SerializeField]
	private Text text;

	public void ChangeScene(int sceneIndex) {
		SceneManager.LoadScene(sceneIndex);
	}

	public void QuitGame() {
		Debug.Log("Quit Game");
		Application.Quit();
	}

	public void UpdateTextFromSlider(float value) {
		text.text = value.ToString("N2");
	}


}


using UnityEngine;
using System.Collections;

/// <summary>
/// GUI全体を制御
/// </summary>
public class GUIController : MonoBehaviour
{
	void OnGUI ()
	{
		switch (GameController.Instance.gameState.Value) {
		case GameController.GameState.Title:
			GUITitle ();
			break;
		case GameController.GameState.GameOver:
			GUIGameOver ();
			break;
		}
	}

	void GUITitle ()
	{
		float x = Screen.width * 0.1f;
		float y = Screen.height * 0.6f;
		if (GUI.Button (new Rect (x, y, Screen.width - (x * 2), Screen.height * 0.3f), "PLAY")) {
			GameController.Instance.gameState.Value = GameController.GameState.Play;
		}
	}

	void GUIGameOver ()
	{
		float x = Screen.width * 0.1f;
		float y = Screen.height * 0.6f;
		if (GUI.Button (new Rect (x, y, Screen.width - (x * 2), Screen.height * 0.3f), "RETRY")) {
			Application.LoadLevel (Application.loadedLevel);
		}
	}
}

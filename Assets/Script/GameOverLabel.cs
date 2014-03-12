using UnityEngine;
using System.Collections;

/// <summary>
/// ゲームオーバーラベルの動作を制御
/// </summary>
public class GameOverLabel : MonoBehaviour
{
	void Start ()
	{
		GameStateChange(GameController.Instance.gameState.Value);
		GameController.Instance.gameState.changed += GameStateChange;
	}

	void OnDestroy ()
	{
		if (GameController.Instance != null)
			GameController.Instance.gameState.changed -= GameStateChange;
	}

	void GameStateChange (GameController.GameState state)
	{
		if (state == GameController.GameState.GameOver) {
			gameObject.SetActive (true);
		}else{
			gameObject.SetActive (false);
		}
	}


}

using UnityEngine;
using System.Collections;

/// <summary>
/// 接触時にスコアを加算する
/// </summary>
public class AddScore : MonoBehaviour
{
	void OnTriggerExit2D (Collider2D cal)
	{
		if (cal.CompareTag ("Player") && GameController.gameState.Value == GameController.GameState.Play) {
			GameController.score.Value += 1;
		}
	}
}

using UnityEngine;
using System.Collections;

/// <summary>
/// 接触時にスコアを加算する
/// </summary>
public class AddScore : MonoBehaviour
{
	void OnTriggerEnter2D (Collider2D cal)
	{
		if (cal.CompareTag ("Player")) {
			GameController.Instance.score.Value += 1;
		}
	}
}

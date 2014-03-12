using UnityEngine;
using System.Collections;

/// <summary>
/// スコアラベルの挙動を制御
/// </summary>
public class ScoreLabel : MonoBehaviour
{
	void Start ()
	{
		UpdateScoreLabel (GameController.Instance.score.Value);
		GameController.Instance.score.changed += UpdateScoreLabel;
	}

	void OnDestroy ()
	{
		if (GameController.Instance != null) {
			GameController.Instance.score.changed -= UpdateScoreLabel;
		}
	}

	void UpdateScoreLabel (int score)
	{
		GetComponent<TextMesh>().text = score.ToString ();
	}
}

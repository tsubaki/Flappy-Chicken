using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

/// <summary>
/// スコアラベルの挙動を制御
/// </summary>
[RequireComponent(typeof(Text))]
public class ScoreLabel : UIBehaviour
{
	private Text _label;

	public Text label {
		get {
			if (_label == null)
				_label = GetComponent<Text> ();
			return _label;
		}
	}

	protected override void Start ()
	{
		UpdateScoreLabel (GameController.score.Value);
		GameController.score.AddListener (UpdateScoreLabel);
	}

	protected override void OnDestroy ()
	{
		if (GameController.Instance != null) {
			GameController.score.RemoveListener (UpdateScoreLabel);
		}
	}

	void UpdateScoreLabel (int score)
	{
		label.text = score.ToString ();
	}
}

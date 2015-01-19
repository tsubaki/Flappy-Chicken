using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;


/// <summary>
/// ゲームオーバーラベルの動作を制御
/// </summary>
[RequireComponent(typeof(Text))]
public class GameOverLabel : UIBehaviour
{
	private Text _label;
	public Text label{
		get{
			if( _label == null )
				_label = GetComponent<Text>();
			return _label;
		}
	}

	protected override void Start ()
	{
		base.Start();
		GameStateChange(GameController.gameState.Value);
		GameController.gameState.AddListener( GameStateChange );
	}

	protected override void OnDestroy ()
	{
		base.OnDestroy();
		if (GameController.Instance != null)
			GameController.gameState.RemoveListener( GameStateChange);
	}

	void GameStateChange (GameController.GameState state)
	{
		if (state == GameController.GameState.GameOver) {
			label.enabled = true;
		}else{
			label.enabled = false;
		}
	}


}

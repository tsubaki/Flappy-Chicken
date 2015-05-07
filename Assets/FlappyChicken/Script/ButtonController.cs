using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonController : UIBehaviour {

	[SerializeField]
	Text label;

	protected override void Awake ()
	{
		base.Awake ();

		OnChangeGameState (GameController.gameState.Value);
		GameController.gameState.AddListener(OnChangeGameState);

		GetComponent<Button>().onClick.AddListener( OnClick );
	}

	protected override void OnDestroy ()
	{
		base.OnDestroy ();
		if( GameController.Instance != null )
			GameController.gameState.RemoveListener(OnChangeGameState);

		GetComponent<Button>().onClick.RemoveListener( OnClick );
	}

	void OnChangeGameState (GameController.GameState state)
	{
		switch( state )
		{
		case GameController.GameState.Title:
			gameObject.SetActive(true);
			label.text = "START";
			break;
		case GameController.GameState.GameOver:
			gameObject.SetActive(true);
			label.text = "RETRY";
			break;
		case GameController.GameState.Play:
			gameObject.SetActive(false);
			break;
		}
	}

	void OnClick()
	{
		switch( GameController.gameState.Value )
		{
		case GameController.GameState.Title:
			GameController.gameState.Value = GameController.GameState.Play;
			break;
		case GameController.GameState.GameOver:
			GameController.gameState.Value = GameController.GameState.Retry;
			break;
		}
	}
}

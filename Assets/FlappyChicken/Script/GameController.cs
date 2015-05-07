using UnityEngine;
using System.Collections;

/// <summary>
/// ゲームのステータスや状況を管理
/// </summary>
public class GameController : SingletonMonoBehaviour<GameController> 
{
	private NotificationObject<int> _score = new NotificationObject<int>(0);
	public static NotificationObject<int> score
	{
		get{ return Instance._score; }
	}

	private NotificationObject<GameState> _gameState = new NotificationObject<GameState>( GameState.Title );
	public static NotificationObject<GameState> gameState
	{
		get{ return Instance._gameState; }
	}

	public enum GameState
	{
		Title,
		Play,
		GameOver,
		Retry
	}

	public static int retryCount = 0;

	void Start()
	{
		Application.targetFrameRate = 60;

		gameState.AddListener( (state )=>{
			if( state == GameState.Retry ){
				StartCoroutine(Restart());
			}
		});
	}

	IEnumerator Restart()
	{
		yield return new WaitForSeconds(0.3f);
		retryCount += 1;
		Application.LoadLevel( Application.loadedLevel) ;
	}

	void OnDestroy()
	{
		score.Dispose();
		_gameState.Dispose();
	}
}

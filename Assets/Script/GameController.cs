using UnityEngine;
using System.Collections;

/// <summary>
/// ゲームのステータスや状況を管理
/// </summary>
public class GameController : SingletonMonoBehaviour<GameController> 
{
	public NotificationObject<int> score = new NotificationObject<int>(0);

	public enum GameState
	{
		Title,
		Play,
		GameOver
	}

	public NotificationObject<GameState> gameState = new NotificationObject<GameState>( GameState.Title );

	void OnDestroy()
	{
		score.Dispose();
		gameState.Dispose();
	}
}

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Cloud.Analytics;

public class Analytics : MonoBehaviour {

	static bool isCalled = false;
	readonly static string projectId = "ebc20cda-d373-40ce-b19b-b0db314c90af";

	void Start () 
	{
		if( isCalled == false ){
			UnityAnalytics.StartSDK (projectId);
			isCalled = true;
		}

		GameController.score.AddListener( (score) => {
			UnityAnalytics.Transaction("12345abcde", 0.99m, "USD", null, null);
		});

		GameController.gameState.AddListener( (state) =>{
			if( state == GameController.GameState.GameOver ){
				UnityAnalytics.CustomEvent("GameOver", new Dictionary<string, object>(){
					{ "score", GameController.score.Value },
					{ "time", Time.timeSinceLevelLoad} ,
					{ "retry", GameController.retryCount} 
				});
			}
		});
	}
}

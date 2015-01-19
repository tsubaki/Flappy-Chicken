using UnityEngine;
using System.Collections;

public class OpenWIndowController : MonoBehaviour {

	Animator _animator;
	Animator animator{
		get{
			if( _animator == null )
				_animator = GetComponent<Animator>();
			return _animator;
		}
	}

	// Use this for initialization
	void Start () {
		GameController.gameState.AddListener(OnChangeGameState);
	}

	void Destroy(){
		if( GameController.Instance != null )
			GameController.gameState.RemoveListener(OnChangeGameState);
	}


	void OnChangeGameState(GameController.GameState state)
	{
		if( state == GameController.GameState.Retry )
			animator.SetBool("IsOpen", false);
	}
}

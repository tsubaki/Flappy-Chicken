using UnityEngine;
using System.Collections;

/// <summary>
/// プレイヤーの挙動を制御
/// </summary>
public class PlayerController : MonoBehaviour
{
	[SerializeField]
	GameObject hitEffect;

	void Start ()
	{
		ChangeGameState (GameController.gameState.Value);
		GameController.gameState.AddListener( ChangeGameState );
	}

	void OnDestroy ()
	{
		if (GameController.Instance != null)
			GameController.gameState.RemoveListener( ChangeGameState );
	}

	void ChangeGameState (GameController.GameState state)
	{
		switch (state) {
		case GameController.GameState.Title:
			enabled = false;
			rigidbody2D.isKinematic = true;
			break;
		case GameController.GameState.Play:
			enabled = true;
			rigidbody2D.isKinematic = false;
			break;
		case GameController.GameState.GameOver:
			enabled = false;
			rigidbody2D.velocity = Vector3.zero;
			break;
		}
	}

	void OnCollisionEnter2D (Collision2D  cal)
	{
		if( GameController.gameState.Value == GameController.GameState.Play ){
			GameObject.Instantiate(hitEffect, cal.contacts[0].point, Quaternion.identity);
		}

		GameController.gameState.Value = GameController.GameState.GameOver;
	}

	private bool isJumpRequest;

	void Update ()
	{
		if (Input.GetMouseButtonDown (0))
			isJumpRequest = true;
	}

	public float power = 2;

	void FixedUpdate ()
	{
		if (isJumpRequest) {
			isJumpRequest = false;
			rigidbody2D.velocity = Vector3.up * power;
		}
	}
}

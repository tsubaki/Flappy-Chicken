using UnityEngine;
using System.Collections;

/// <summary>
/// ボードの移動を制御
/// </summary>
public class MoveBoad : MonoBehaviour 
{
	void FixedUpdate ()
	{
		GetComponent<Rigidbody2D>().velocity = -Vector2.right;
	}
}
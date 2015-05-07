using UnityEngine;
using System.Collections;

public class UVScroll : MonoBehaviour
{
	public float speed = 1;
	float current;

	void Update ()
	{
		current += Time.deltaTime * speed;
		if( current > 1 ){
			current -= 1;
		}


		GetComponent<Renderer>().material.SetTextureOffset ("_MainTex", new Vector2 (current, 0));
	}
}

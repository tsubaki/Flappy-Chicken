using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class FontScalable : MonoBehaviour {
	
	[Range(1, 6)]
	public float fontScale = 1;
	TextMesh tetxMesh;
	
	void Start () {
		tetxMesh = GetComponent<TextMesh>();
	}
	
	void Update () 
	{
		int fontSize = Mathf.Max(12, tetxMesh.fontSize);
		tetxMesh.fontSize = fontSize;
		float scale = 0.1f * 128 / fontSize;
		tetxMesh.characterSize = scale * fontScale;
	}
}
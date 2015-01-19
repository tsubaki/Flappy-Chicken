using UnityEngine;
using System.Collections;

public class LineRendererTrail : MonoBehaviour {

	[SerializeField]
	Transform followTarget;

	private LineRenderer _line;
	
	public LineRenderer line {
		get {
			if (_line == null)
				_line = GetComponent<LineRenderer> ();
			return _line;
		}
	}

	float[] ys = new float[20];

	// Use this for initialization
	void Start () {

		for(int i=0; i<ys.Length; i++)
		{
			ys[i] = followTarget.transform.position.y;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
		for(int i=ys.Length -2; i>=0; i--)
		{
			ys[i+1] = ys[i];
		}
		ys[0] = followTarget.transform.position.y;

		for(int i=0; i<ys.Length; i++)
		{
			line.SetPosition(i, new Vector3(i * -0.04f + followTarget.transform.position.x, ys[i], 0) );
		}
	}
}

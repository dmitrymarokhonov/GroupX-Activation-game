using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MoveCameraRight : MonoBehaviour
{
	public Button ButtonRight;
	float step = 10;

	public void MoveCamera()
	{
		Debug.Log("Right button pressed.");
		Camera.main.transform.Translate(step, 0, 0);
	}
}
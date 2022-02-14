using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MoveCameraLeft : MonoBehaviour
{
	public Button ButtonLeft;
	float step = 10;

	public void MoveCamera()
	{
		Debug.Log("Left button pressed.");
		Camera.main.transform.Translate(-step, 0, 0);
	}
}
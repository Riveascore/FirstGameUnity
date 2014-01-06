using UnityEngine;
using System.Collections;

public class MenuScript : MonoBehaviour {

	void OnGUI() {
		const int buttonWidth = 100;
		const int buttonHeight = 80;

		if (
			GUI.Button(
			// Center in X, 2/3 of the height in Y
			new Rect(
			Screen.width / 2 - (buttonWidth / 2),
			(2 * Screen.height / 3) - (buttonHeight / 2),
			buttonWidth,
			buttonHeight
			),
			"Start!"
			)
		)
		{
			// On Click, load the first level.
			// "Stage1" is the name of the first scene we created.
			Application.LoadLevel("Stage1");
		}
	}
}

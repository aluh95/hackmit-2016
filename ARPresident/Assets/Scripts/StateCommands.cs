using UnityEngine;
using System.Collections;

public class StateCommands : MonoBehaviour {

    // Called by GazeGestureManager when the user performs a Select gesture
    void OnSelect() {
        Debug.Log(this.name + " was selected");
    }

}

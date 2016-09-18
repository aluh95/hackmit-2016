using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class StateCommands : MonoBehaviour {

    public static float yScaleFactor = 14.28571f;
    public static List<Material> mats = new List<Material>();
    public bool selected = false;

    void Start() {
        mats.Add(Resources.Load("black") as Material);
    }

    // Called by GazeGestureManager when the user performs a Select gesture
    void OnSelect() {
        GameObject pop = GameObject.Find(this.name + " Popup");
        GameObject popText = GameObject.Find("Popup Text");
        selected = !selected;
        if (!selected) {
            selected = !selected;
            Destroy(pop);
            Destroy(popText);
        }
        if (selected) {
            selected = !selected;
            Debug.Log(this.name + " was selected");
            string stateName = this.name.Replace('_', ' ');
            float numVotes = (float)Math.Round(((this.transform.localScale.z / yScaleFactor) / 0.1f), 0);
            GameObject popup = GameObject.CreatePrimitive(PrimitiveType.Cube);
            popup.name = stateName + " Popup";
            popup.transform.parent = Camera.main.transform;
            popup.transform.position = new Vector3(0.4f, 0.18f, 2.5f);
            popup.transform.localScale = new Vector3(0.55f, 0.05f, 0.05f);
            popup.GetComponent<Renderer>().material = mats[0];
            Vector3 sc = popup.transform.localScale;
            GameObject popupText = new GameObject();
            popupText.name = "Popup Text";
            popupText.transform.parent = popup.transform;
            popupText.transform.position = popup.transform.position;
            popupText.transform.rotation = popup.transform.rotation;
            popupText.transform.localScale = new Vector3(0.0005775f / sc.x, 0.0003f / sc.y, .0025f / sc.z);
            TextMesh popupTextMesh = popupText.AddComponent<TextMesh>();
            popupTextMesh.text = stateName + "\n" + numVotes + " electoral votes";
            popupTextMesh.anchor = TextAnchor.MiddleCenter;
            popupTextMesh.offsetZ = -0.1f;
            popupTextMesh.color = Color.white;
            popupTextMesh.fontSize = 500;
            popupTextMesh.fontStyle = FontStyle.Bold;
        }
    }

}

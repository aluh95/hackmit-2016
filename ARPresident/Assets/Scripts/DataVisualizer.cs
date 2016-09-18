using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using electoralVote;
using electoralVoteParser;

public class DataVisualizer : MonoBehaviour {

    private string[] stateNames = { "AL", "AK", "AZ", "AR", "CA", "CO",
                                    "CT", "DE", "FL", "GA", "HI", "ID",
                                    "IL", "IN", "IA", "KS", "KY", "LA",
                                    "ME", "MD", "MA", "MI", "MN", "MS",
                                    "MO", "MT", "NE", "NV", "NH", "NJ",
                                    "NM", "NY", "NC", "ND", "OH", "OK",
                                    "OR", "PA", "RI", "SC", "SD", "TN",
                                    "TX", "UT", "VT", "VA", "WA", "WV", "WI", "WY" };
    private string electoralVoteData;
    private string electoralVotePath = "/Electoral.csv";

    public static List<ElectoralVote> electoralVotes = new List<ElectoralVote>();
    public static List<Material> stateMats = new List<Material>();
    public static List<Shader> textShader = new List<Shader>();
    public static float yScaleFactor = 14.28571f;

    private GameObject dateDisplay;

    // Use this for initialization
    void Start() {
        // read and parse state electoral vote data from local csv file
        electoralVotePath = Application.streamingAssetsPath + "/Electoral.csv";
        electoralVoteData = File.ReadAllText(electoralVotePath);
        List<ElectoralVote> electoralVotes = ElectoralVoteParser.Parse(electoralVoteData);
        // add materials
        stateMats.Add(Resources.Load("white") as Material);
        // add text shader
        textShader.Add(Resources.Load("3TextShader") as Shader);
        // initialize date display at fixed position relative to camera
        dateDisplay = GameObject.Find("Date Display");
        Vector3 sc = dateDisplay.transform.localScale;
        GameObject dateText = new GameObject();
        dateText.name = "Date Text";
        dateText.transform.parent = dateDisplay.transform;
        dateText.transform.position = dateDisplay.transform.position;
        dateText.transform.rotation = dateDisplay.transform.rotation;
        dateText.transform.localScale = new Vector3(0.0005775f / sc.x, 0.0003f / sc.y, .0025f / sc.z);
        TextMesh dateTextMesh = dateText.AddComponent<TextMesh>();
        dateTextMesh.text = "Current Date";
        dateTextMesh.anchor = TextAnchor.MiddleCenter;
        dateTextMesh.offsetZ = -0.1f;
        dateTextMesh.color = Color.white;
        dateTextMesh.fontSize = 500;
        dateTextMesh.fontStyle = FontStyle.Bold;
        // generate landscape of 50 states in the USA
        for (int i = 0; i < 5; i++) {
            for (int j = 0; j < 10; j++) {
                int index = i * 10 + j;
                /*
                GameObject state = GameObject.CreatePrimitive(PrimitiveType.Cube);
                ElectoralVote currentEV = electoralVotes[index];
                state.name = currentEV.State;
                state.transform.localScale = new Vector3(0.05f, 0.01f * (currentEV.Votes), 0.05f);
                state.transform.position = new Vector3((j - 4.5f) / 8, (0.01f * currentEV.Votes) / 2 - 0.5f, (10 - 2 * i) / 8.0f + 1.5f);
                state.GetComponent<Renderer>().material = stateMats[0];
                state.GetComponent<Renderer>().material.shader = textShader[0];
                */
                ElectoralVote currentEV = electoralVotes[index];
                GameObject state = GameObject.Find(((string)currentEV.State).Replace(' ', '_'));
                state.transform.localScale = new Vector3(1, 1, 0.1f * (currentEV.Votes) * yScaleFactor);
                Vector3 positionVector = state.transform.localPosition;
                state.transform.localPosition = new Vector3(positionVector.x, -(0.1f * currentEV.Votes) / 2, positionVector.z );
                state.GetComponent<Renderer>().material = stateMats[0];
                state.GetComponent<Renderer>().material.shader = textShader[0];
                state.AddComponent<UnityEngine.UI.Outline>();
                // create labels for state objects
                Vector3 scale = state.transform.localScale;
                GameObject labelText = new GameObject();
                labelText.name = stateNames[index] + " label";
                labelText.transform.parent = state.transform;
                labelText.transform.position = state.transform.position;
                labelText.transform.localScale = new Vector3(scale.x / 10f, 0.0000361f / scale.y, scale.z);
                TextMesh labelTextMesh = labelText.AddComponent<TextMesh>();
                labelTextMesh.GetComponent<Renderer>().material.shader = textShader[0];
                labelTextMesh.text = stateNames[index];
                labelTextMesh.offsetZ = (float)(state.transform.localScale.z*0.070d/2);
                labelTextMesh.anchor = TextAnchor.UpperCenter;
                labelTextMesh.color = Color.black;
                labelTextMesh.fontSize = 2000;
                labelTextMesh.fontStyle = FontStyle.Bold;
            }
        }

    }

    // Update is called once per frame
    void Update() {

    }
}


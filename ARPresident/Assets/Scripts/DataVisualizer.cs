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

    // Use this for initialization
    void Start() {
        // read and parse state electoral vote data from local csv file
        electoralVotePath = Application.streamingAssetsPath + "/Electoral.csv";
        electoralVoteData = File.ReadAllText(electoralVotePath);
        List<ElectoralVote> electoralVotes = ElectoralVoteParser.Parse(electoralVoteData);
        // generate landscape of 50 states in the USA
        for (int i = 0; i < 5; i++) {
            for (int j = 0; j < 10; j++) {
                int index = i * 10 + j;
                GameObject state = GameObject.CreatePrimitive(PrimitiveType.Cube);
                ElectoralVote currentEV = electoralVotes[index];
                state.name = currentEV.State;
                state.transform.localScale = new Vector3(0.05f, 0.01f * (currentEV.Votes), 0.05f);
                state.transform.position = new Vector3((j - 4.5f) / 8, (0.01f * currentEV.Votes) / 2 - 0.5f, (10 - 2 * i) / 2.5f + 1);
                // create labels for state objects
                Vector3 scale = state.transform.localScale;
                GameObject labelText = new GameObject();
                labelText.name = stateNames[index] + " label";
                labelText.transform.parent = state.transform;
                labelText.transform.position = state.transform.position;
                labelText.transform.localScale = new Vector3(scale.x / 3.0f, scale.y / 120.0f, scale.z);
                TextMesh labelTextMesh = labelText.AddComponent<TextMesh>();
                labelTextMesh.text = stateNames[index];
                labelTextMesh.anchor = TextAnchor.MiddleCenter;
                labelTextMesh.color = Color.black;
                labelTextMesh.fontSize = 1080;
                labelTextMesh.fontStyle = FontStyle.Bold;
            }
        }

    }

    // Update is called once per frame
    void Update() {

    }
}


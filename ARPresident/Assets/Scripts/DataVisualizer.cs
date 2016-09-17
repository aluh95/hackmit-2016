using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using electoralVote;
using electoralVoteParser;

public class DataVisualizer : MonoBehaviour {

    private string[] stateNames = { "Alabama", "Alaska", "Arizona", "Arkansas", "California", "Colorado",
                                    "Connecticut", "Delaware", "Florida", "Georgia", "Hawaii", "Idaho",
                                    "Illinois", "Indiana", "Iowa", "Kansas", "Kentucky", "Louisiana",
                                    "Maine", "Maryland", "Massachusetts", "Michigan", "Minnesota",
                                    "Mississippi", "Missouri", "Montana", "Nebraska", "Nevada",
                                    "New Hampshire", "New Jersey", "New Mexico", "New York",
                                    "North Carolina", "North Dakota", "Ohio", "Oklahoma", "Oregon",
                                    "Pennsylvania", "Rhode Island", "South Carolina", "South Dakota",
                                    "Tennessee", "Texas", "Utah", "Vermont", "Virginia", "Washington",
                                    "West Virginia", "Wisconsin", "Wyoming" };
    private string electoralVoteData;
    private string electoralVotePath = @"Assets\Data\Electoral.csv";

    public static List<ElectoralVote> electoralVotes = new List<ElectoralVote>();

    // Use this for initialization
    void Start() {
        // read and parse state electoral vote data from local csv file
        electoralVoteData = System.IO.File.ReadAllText(electoralVotePath);
        List<ElectoralVote> electoralVotes = ElectoralVoteParser.Parse(electoralVoteData);
        // create landscape of 50 states in the USA
        for (int i = 0; i < 5; i++) {
            for (int j = 0; j < 10; j++) {
                int index = i * 10 + j;
                GameObject state = GameObject.CreatePrimitive(PrimitiveType.Cube);
                ElectoralVote currentEV = electoralVotes[index];
                state.name = stateNames[index];
                state.transform.localScale = new Vector3(0.25f, 0.25f * currentEV.Votes, 0.25f);
                state.transform.position = new Vector3(j - 4.5f, (0.25f * currentEV.Votes) / 2, 10 - 2 * i);
            }
        }

    }

    // Update is called once per frame
    void Update() {

    }
}


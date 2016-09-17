using UnityEngine;
using System;
using System.Collections.Generic;
using electoralVote;

namespace electoralVoteParser {
    public class ElectoralVoteParser {

        public static List<ElectoralVote> Parse(string csvData) {
            List<ElectoralVote> electoralVotes = new List<ElectoralVote>();

            string[] states = csvData.Replace("\r", "").Split('\n');

            foreach (string state in states) {
                if (!string.IsNullOrEmpty(state)) {
                    string[] parameters = state.Split(',');
                    ElectoralVote ev = new ElectoralVote();
                    ev.State = parameters[0];
                    ev.Votes = Convert.ToSingle(parameters[1]);
                    electoralVotes.Add(ev);
                }
            }

            return electoralVotes;
        }
    }
}

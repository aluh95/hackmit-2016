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
                    ev.Date1 = Convert.ToSingle(parameters[2]);
                    ev.Date2 = Convert.ToSingle(parameters[3]);
                    ev.Date3 = Convert.ToSingle(parameters[4]);
                    ev.Date4 = Convert.ToSingle(parameters[5]);
                    ev.Date5 = Convert.ToSingle(parameters[6]);
                    ev.Date6 = Convert.ToSingle(parameters[7]);
                    ev.Date7 = Convert.ToSingle(parameters[8]);
                    electoralVotes.Add(ev);
                }
            }

            return electoralVotes;
        }
    }
}

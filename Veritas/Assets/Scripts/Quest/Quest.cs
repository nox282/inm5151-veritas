using System;
using System.Collections;
using System.Collections.Generic;
using SocketIO;

namespace Veritas {
	public interface IGoal {
		string Type{get;set;}
        string Level{get;set;}
        string Question{get;set;}
        string Answer{get;set;}
        bool Completed{get;set;}
	}

	public class Quest {
		private string title;
		private string subject;
		private string level;
		private List<Goal> objectives;

		public string Title{
			get{ return title; }
			set{ title = value; }
		}

		public string Subject{
			get{ return subject; }
			set{ subject = value; }
		}

		public string Level{
			get{ return level; }
			set{ level = value; }
		}

		public List<Goal> Objectives{ get { return objectives; } }

		public void setObjectives(JSONObject data) {
			foreach(JSONObject j in data.list){
				Goal g = new Goal();
				for(int i = 0; i < j.list.Count; i++){
					string key = (string) j.keys[i];
					g.setGoalAttributes(key, j.list[i]);
				}
				objectives.Add(g);
			}
		}

		public Quest(){
			title = "";
			subject = "";
			level = "";
			objectives = new List<Goal>();
		}

		public Quest(string _t, string _s, string _l, List<Goal> _o){
			title = _t;
			subject = _s;
			level = _l;
			objectives = _o;
		}

		public bool isCompleted(){
			foreach(Goal g in objectives){
				if(!g.Completed)
					return false;
			}
			return true;
		}
	}
}
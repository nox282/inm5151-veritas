using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Veritas {
	public interface IGoal {
		String Title{get;set;}
		String Description{get;set;}
		bool Completed{get;set;}

		void complete();
	}

	public class Quest {
		private String title;
		private String description;
		private List<IGoal> objectives;

		public String Title{
			get{ return title; }
			set{ title = value; }
		}

		public String Description{
			get{ return description; }
			set{ description = value; }
		}

		public List<IGoal> Objectives{get{return objectives;}}

		public Quest(String _t, String _d, List<IGoal> _o){
			title = _t;
			description = _d;
			objectives = _o;
		}

		public bool isCompleted(){
			foreach(IGoal g in objectives){
				if(!g.Completed)
					return false;
			}
			return true;
		}
	}
}
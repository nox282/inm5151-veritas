using System;
using System.Collections;
using System.Collections.Generic;

namespace Veritas {
    public class Goal : IGoal {
        private string type;
        private string level;
        private string question;
        private string answer;
        private bool completed;

        public string Type{
            get{ return type; }
            set{ type = value; }
        }
        public string Level{
            get{ return level; }
            set{ level = value; }
        }
        public string Question{
            get{ return question; }
            set{ question = value; }
        }
        public string Answer{
            get{ return answer; }
            set{ answer = value; }
        }
        public bool Completed{
            get{ return completed; }
            set{ completed = value; }
        }
        
        public bool tryAnswer(string a){
            if(answer.ToUpper().Contains(a.ToUpper()))
                completed = true;
            return completed;
        }

        public void setGoalAttributes(string key, JSONObject data){
            if(     key == "type"){
                this.type = data.str;
            } else if(key == "level"){
                this.level = data.str;
            } else if(key == "question"){
                this.question = data.str;
            } else if(key == "answer"){
                this.answer = data.str;
            }
        }
    }
}
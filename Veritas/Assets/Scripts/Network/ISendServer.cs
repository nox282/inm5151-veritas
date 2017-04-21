using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[Serializable]
public interface ISendServer {

    //public string name;
    //public int funlevel;
    //public string color;

    //public string Name { get { return name; } }
    //public int Funlevel { get { return funlevel; } }
    //public string Color { get { return color; } }

    Dictionary<string, string> toDictionnary();

    //public Dictionary<string, string> toDictionnary()
    //{
    //    Dictionary<string, string> ret = new Dictionary<string, string>();
    //    ret.Add("name", name);
    //    ret.Add("funlevel", funlevel.ToString());
    //    ret.Add("color", color);
    //    return ret;
    //}
}



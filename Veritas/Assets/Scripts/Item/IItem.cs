using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Veritas {

	public interface IItem {
		GameObject item{get;set;}

		void use();
	}
}
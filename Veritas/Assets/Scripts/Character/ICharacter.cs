using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Veritas {

	public interface ICharacter {

		String Name{get;set;}

		// Returns the type of cell the character is standing on;
		GameObject scan();
		GameObject[] scanAround();

		// Character picks up something he is standing on
		void pickUp(Item i);
		// Assign Quest to Character's QuestLog
		void pickUp(Quest q);

		void drop(Item i);
		void drop(Quest q);

		void equip(Item i);
		void unequip(Item i);
	}
}
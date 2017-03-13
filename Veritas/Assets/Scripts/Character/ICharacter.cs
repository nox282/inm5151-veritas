using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Veritas {

	public interface Character {

		String Name{get;set;}
		IInventory<IItem> Equipment{get;}
		IInventory<IItem> Bag{get;}
		IInventory<Quest> QuestLog{get;}

		// Returns the type of cell the character is standing on;
		Type scan();
		Type[] scanAround();

		// Character picks up something he is standing on
		void pickUp(IItem i);
		// Assign Quest to Character's QuestLog
		void pickUp(Quest q);

		void drop(IItem i);
		void drop(Quest q);

		void equip(IItem i);
		void unequip(IItem i);
	}
}
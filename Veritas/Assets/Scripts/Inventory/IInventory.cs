using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Veritas {

	public interface IInventory<T> where T : class {
		// Returns true if Inventory have this item
		bool isThere(T item);
		bool isThereTypeOf(T item);

		// Adds item to the Inventory
		void receive(T item);
		void receive(List<T> items);

		// Removes everything from the Inventory
		void drop();
		void drop(T item);
		// Removes everything of the type of this item
		void dropAllOf(T item);
		
		void sortByType();
		void revertSorting();

		// Returns the reference to an item
		T take(T item);

		void use(T item);
	}
}
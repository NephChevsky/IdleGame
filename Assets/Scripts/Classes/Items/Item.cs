using Assets.Scripts.Classes.Items.Affixes;
using System;
using System.Collections.Generic;

namespace Assets.Scripts.Classes
{
	public class Item
	{
		public ItemType Type { get; set; }

		public List<Affix> Affixes { get; set; } = new();

	}
}

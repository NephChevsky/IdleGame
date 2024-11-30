using Assets.Scripts.Classes;
using Assets.Scripts.Classes.Items.Affixes;
using System;
using UnityEngine;

namespace Assets.Scripts.Engines
{
	public static class ItemEngine
	{
		public static Item Generate()
		{
			Item item = new Item();
			item.Type = ((ItemType[]) Enum.GetValues(typeof(ItemType)))[UnityEngine.Random.Range(0, Enum.GetNames(typeof(ItemType)).Length)];
			Affix affix = new Affix();
			affix.Type = ((AffixType[])Enum.GetValues(typeof(AffixType)))[UnityEngine.Random.Range(0, Enum.GetNames(typeof(AffixType)).Length)];
			affix.Value = UnityEngine.Random.Range(0.1f, 0.5f);
			item.Affixes.Add(affix);
			return item;
		}
	}
}

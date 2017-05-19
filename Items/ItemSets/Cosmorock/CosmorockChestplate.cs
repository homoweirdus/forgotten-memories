using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.ItemSets.Cosmorock
{
	public class CosmorockChestplate : ModItem
	{
		public override bool Autoload(ref string name, ref string texture, IList<EquipType> equips)
		{
			equips.Add(EquipType.Body);
			return true;
		}

		public override void SetDefaults()
		{
			item.name = "Cosmic Chestplate";
			item.width = 18;
			item.height = 18;
			AddTooltip("+50 Max Health");
			item.value = 10000;
			item.rare = 4;
			item.defense = 18;
		}

		public override void UpdateEquip(Player player)
		{
			player.statLifeMax2 += 50;
		}
	}
}
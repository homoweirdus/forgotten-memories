using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.ItemSets.Blightstone
{
	public class BlightstoneHood : ModItem
	{
		public override bool Autoload(ref string name, ref string texture, IList<EquipType> equips)
		{
			equips.Add(EquipType.Head);
			return true;
		}

		public override void SetDefaults()
		{
			item.name = "Blightstone Hood";
			item.width = 18;
			item.height = 18;
			item.toolTip = "10% increased summon and magic damage";
			item.toolTip2 = "Max minions increased by 2 and Max mana increased by 80";
			item.value = 250000;
			item.rare = 5;
			item.defense = 4;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == mod.ItemType("VeilstoneBreastplate") && legs.type == mod.ItemType("VeilstoneGreaves");
		}
		
		public override bool DrawHead()
		{
			return false;
		}

		public override void UpdateEquip(Player player)
		{
			player.minionDamage += 0.11f;
			player.magicDamage += 0.11f;
			player.maxMinions += 2;
			player.statManaMax2 += 80;
		}

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "Summons an orb of blighted energy that damages nearby enemies";
			((TgemPlayer)player.GetModPlayer(mod, "TgemPlayer")).BlightOrb = true;
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "blight_bar", 12);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
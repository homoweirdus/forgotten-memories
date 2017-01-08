using Terraria.ID;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;


namespace ForgottenMemories.Items.Souls.ranged

{
	public class ranged5 : ModItem
	{
		public override void SetDefaults()
		{

			item.name = "Ranged Level 5";
			item.width = 40;
			item.height = 40;
			item.toolTip = "+ 8% Ranged Damage";
			item.toolTip2 = "Compatible with Forgotten Memories";
			item.value = 0;
			item.rare = 10;
			item.accessory = true;
			ItemID.Sets.ItemNoGravity[item.type] = true;
		}
		public override DrawAnimation GetAnimation()
		{
			return new DrawAnimationVertical(5, 3);
		}
		public override void UpdateEquip(Player player)
		{
			player.rangedDamage += 0.08f;
		}
		public override void AddRecipes()

		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "soul", 500);
			recipe.AddIngredient(null, "DominationCrystal", 5);
			recipe.AddIngredient(null, "ranged4", 1);
			recipe.SetResult(this);
			recipe.AddRecipe();
			
			recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "soul", 500);
			recipe.AddIngredient(null, "ConfusionCrystal", 5);
			recipe.AddIngredient(null, "ranged4", 1);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
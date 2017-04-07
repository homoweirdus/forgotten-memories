﻿using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.ItemSets.OreArrows
{
	public class SilverArrow : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Silver Arrow";
			item.width = 10;
			item.height = 28;
            item.value = 60;
            item.toolTip = "Can pierce 2 times";
            item.rare = 2;

            item.maxStack = 999;

            item.damage = 5;
			item.knockBack = 2f;
            item.ammo = AmmoID.Arrow;

            item.ranged = true;
            item.consumable = true;

            item.shoot = mod.ProjectileType("SilverArrow");
            item.shootSpeed = 1.33f;
        }

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.SilverBar, 1);
            recipe.AddIngredient(40, 30);
            recipe.AddTile(16);
            recipe.SetResult(this, 30);
            recipe.AddRecipe();
		}
	}
}
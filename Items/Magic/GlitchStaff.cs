using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.Magic
{
	public class GlitchStaff : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Glitch Staff";
			item.damage = 15;
			item.magic = true;
			item.width = 25;
			item.height = 26;
			item.toolTip = "Cheat Weapon! Unobtainable outside of cheat sheet.";
			item.useTime = 10;
			item.UseSound = SoundID.Item20;
			item.useAnimation = 10;
			item.useStyle = 5;
			item.noMelee = true;
			item.knockBack = 7;
			Item.staff[item.type] = true;
			item.value = 200000;
			item.rare = 5;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("Glitch");
			item.shootSpeed = 25f;
		}
	}
}
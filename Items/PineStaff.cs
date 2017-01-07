using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items
{
    public class PineStaff : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Pine Staff";
            item.damage = 12;
            item.magic = true;
            item.mana = 3;
            item.width = 25;
            item.height = 26;
            item.toolTip = "Fires pine needles";
            item.useTime = 9;
			item.UseSound = SoundID.Item20;
            item.useAnimation = 9;
            item.useStyle = 5;
            item.noMelee = true;
            item.knockBack = 7;
            Item.staff[item.type] = true;
            item.value = 10000;
            item.rare = 2;
            item.autoReuse = true;
            item.shoot = 336;
            item.shootSpeed = 10f;
        }
		
		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
    {
            float sX = speedX;
            float sY = speedY;
            sX += (float)Main.rand.Next(-60, 61) * 0.03f;
            sY += (float)Main.rand.Next(-60, 61) * 0.03f;
            Projectile.NewProjectile(position.X, position.Y, sX, sY, type, damage, knockBack, player.whoAmI);
			return false;
    }
	}
}
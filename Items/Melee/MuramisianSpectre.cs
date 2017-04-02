using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;

namespace ForgottenMemories.Items.Melee
{
	public class MuramisianSpectre : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Muramisian Spectre";
			item.damage = 45;
			item.melee = true;
			item.width = 62;
			item.height = 62;
			item.toolTip = "Creates a wall of spectre waves";
			item.useTime = 12;
			item.useAnimation = 12;
			item.useStyle = 1;
			item.knockBack = 3;
			item.value = 1000000;
			item.rare = 8;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("SpectreWave");
			item.shootSpeed = 15f;
			item.useTurn = true;
		}
		
		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			if (Main.rand.Next(2) == 0)
			{
				int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 15);
				Main.dust[dust].noGravity = true;
			}
			if (Main.rand.Next(10) == 0)
			{
				int dust2 = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 56);
				Main.dust[dust2].noGravity = true;
			}
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Muramasa, 1);
			recipe.AddIngredient(ItemID.Ectoplasm, 12);
			recipe.AddIngredient(ItemID.BrokenHeroSword, 1);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Projectile.NewProjectile(position.X, position.Y, speedX, speedY, type, damage, knockBack, player.whoAmI);
			for (int i = 0; i < 2; ++i)
			{
				Vector2 mouse = Main.MouseWorld;
				mouse.X += Main.rand.Next(-20, 21);
				float sX = 0;
				float sY = 25;
				sX += (float)Main.rand.Next(-10, 10) * 0.2f;
				sY += (float)Main.rand.Next(-20, 20) * 0.2f;
				Projectile.NewProjectile(mouse.X, (position.Y-1000), sX, sY, type, damage, knockBack, player.whoAmI);
			}
			for (int i = 0; i < 2; ++i)
			{
				Vector2 mouse = Main.MouseWorld;
				mouse.X += Main.rand.Next(-20, 21);
				float s2X = 0;
				float s2Y = -25;
				s2X += (float)Main.rand.Next(-10, 10) * 0.2f;
				s2Y += (float)Main.rand.Next(-20, 20) * 0.2f;
				Projectile.NewProjectile(mouse.X, (position.Y+1000), s2X, s2Y, type, damage, knockBack, player.whoAmI);
			}
			return false;
		}
		
	}
}
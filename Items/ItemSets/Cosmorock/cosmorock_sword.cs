using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;

namespace ForgottenMemories.Items.ItemSets.Cosmorock
{
	public class cosmorock_sword : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Cosmos Blade";
			item.damage = 56;
			item.melee = true;
			item.width = 88;
			item.height = 88;
			item.toolTip = "Fires a spread of short-ranged meteors";
			item.useTime = 44;
			item.useAnimation = 22;
			item.useStyle = 1;
			item.knockBack = 2;
			item.value = 50000;
			item.rare = 4;
			item.shoot = mod.ProjectileType("CosmirockMeteor");
			item.shootSpeed = 5f;
			item.useTurn = true;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}
		
		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			if (Main.rand.Next(2) == 0)
			{
				int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 15);
				Main.dust[dust].noGravity = true;
				Main.dust[dust].velocity *= 0.75f;
				Main.dust[dust].fadeIn = 1.3f;
				Main.dust[dust].scale = 0.7f;
			}
		}
		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
			int projectileAmount = Main.rand.Next(2, 3);
			for (int k = 0; k < projectileAmount; k++)
			{
				Vector2 velVect = new Vector2(speedX, speedY);
				Vector2 velVect2 = velVect.RotatedBy(MathHelper.ToRadians(Main.rand.Next(-15, 15)));
				
				Projectile.NewProjectile(player.Center.X, player.Center.Y, velVect2.X, velVect2.Y, type, damage, knockBack, Main.myPlayer, 0, 0);
			}
            return false;
        }
	}
}

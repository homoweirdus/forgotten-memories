using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Items.Ranged
{
	public class BeeCannon : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 22;
			item.ranged = true;
			item.width = 42;
			item.height = 30;


			item.useTime = 40;
			item.useAnimation = 40;
			item.useStyle = 5;
			item.noMelee = true;
			item.knockBack = 3f;
			item.value = 100000;
			item.rare = 3;
			item.UseSound = SoundID.Item11;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("StingerRocket");
			item.shootSpeed = 16f;
		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Bee Cannon");
      Tooltip.SetDefault("Uses stingers as ammo\n80% chance not to consume stingers");
    }


		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.BeeWax, 14);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
		
		public override bool ConsumeAmmo(Player player)
	    {
	    	if (Main.rand.Next(0, 100) <= 80)
			{
	    		return false;
			}
	    	return true;
	    }

		public override void GetWeaponDamage(Player player, ref int damage)
		{
			damage = (int)(damage * player.rocketDamage);
		}
	}
}

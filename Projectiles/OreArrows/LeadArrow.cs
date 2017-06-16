﻿using System;

using Microsoft.Xna.Framework;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenMemories.Projectiles.OreArrows
{
	public class LeadArrow : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.CloneDefaults(ProjectileID.WoodenArrowFriendly);
            projectile.penetrate = 1;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Lead Arrow");
		}
    }
}

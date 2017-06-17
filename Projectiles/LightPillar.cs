using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using Terraria.Utilities;

namespace ForgottenMemories.Projectiles
{
	public class LightPillar : ModProjectile
	{
		float ok;
		public override void SetDefaults()
		{
			projectile.width = 7;
			projectile.height = 7;
			projectile.friendly = true;
			projectile.melee = true;
			projectile.penetrate = -1;
			ProjectileID.Sets.TrailingMode[projectile.type] = 1;
			ProjectileID.Sets.TrailCacheLength[projectile.type] = 20;
			projectile.extraUpdates = 4;
			projectile.scale = 4f;
			projectile.timeLeft = 600;
			projectile.usesLocalNPCImmunity = true;
			projectile.localNPCHitCooldown = 60;
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Light Pillar");
		}
		
		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			if (projectile.localAI[1] < 1f)
			{
				projectile.localAI[1] += 2f;
				projectile.position += projectile.velocity;
				projectile.velocity = Vector2.Zero;
			}
			return false;
		}
		
		public override void Kill(int timeLeft)
		{
			for (int i = 0; i < 20; i++)
			{
				int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 160);
				Main.dust[dust].scale = 2.5f;
				Main.dust[dust].noGravity = true;
			}
		}
		
		public override Color? GetAlpha(Color lightColor)
		{
			return new Color(99, 38, 255, 255);
		}
		
		public override void AI()
		{
			if (projectile.position.Y > (double) projectile.ai[1])
				projectile.tileCollide = true;
			else
				projectile.tileCollide = false;
			
			if (projectile.ai[0] == 0)
			{
				projectile.ai[0] = projectile.velocity.ToRotation();
			}
			
			else
			{
				int num3 = projectile.frameCounter;
				projectile.frameCounter = num3 + 1;
				Lighting.AddLight(projectile.Center, 0.3f, 0.45f, 0.5f);
				if (projectile.velocity == Vector2.Zero)
				{
					if (projectile.frameCounter >= projectile.extraUpdates * 2)
					{
						projectile.frameCounter = 0;
						bool flag35 = true;
						for (int num854 = 1; num854 < projectile.oldPos.Length; num854 = num3 + 1)
						{
							if (projectile.oldPos[num854] != projectile.oldPos[0])
							{
								flag35 = false;
							}
							num3 = num854;
						}
						if (flag35)
						{
							projectile.Kill();
							return;
						}
					}
				}
				else if (projectile.frameCounter >= projectile.extraUpdates * 2)
				{
					projectile.frameCounter = 0;
					float num860 = projectile.velocity.Length();
					UnifiedRandom unifiedRandom = new UnifiedRandom((int)ok);
					int num861 = 0;
					Vector2 vector96 = -Vector2.UnitY;
					Vector2 vector97;
					do
					{
						int num862 = unifiedRandom.Next();
						ok = (float)num862;
						num862 %= 100;
						float f = (float)num862 / 100f * 6.28318548f;
						vector97 = f.ToRotationVector2();
						if (vector97.Y > 0f)
						{
							vector97.Y *= -1f;
						}
						bool flag36 = false;
						if (vector97.Y > -0.02f)
						{
							flag36 = true;
						}
						if (vector97.X * (float)(projectile.extraUpdates + 1) * 2f * num860 + projectile.localAI[0] > 40f)
						{
							flag36 = true;
						}
						if (vector97.X * (float)(projectile.extraUpdates + 1) * 2f * num860 + projectile.localAI[0] < -40f)
						{
							flag36 = true;
						}
						if (!flag36)
						{
							goto IL_260B5;
						}
						num3 = num861;
						num861 = num3 + 1;
					}
					while (num3 < 100);
						projectile.velocity = Vector2.Zero;
						projectile.localAI[1] = 1f;
					goto IL_260C1;
					IL_260B5:
					vector96 = vector97;
					IL_260C1:
					if (projectile.velocity != Vector2.Zero)
					{
						projectile.localAI[0] += vector96.X * (float)(projectile.extraUpdates + 1) * 2f * num860;
						//projectile.velocity = vector96.RotatedBy((double)(projectile.ai[0] + 1.57079637f), default(Vector2)) * num860;
						//projectile.rotation = projectile.velocity.ToRotation() + 1.57079637f;
						return;
					}
				}
			}
		}
		
		public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
		{
			Microsoft.Xna.Framework.Color color25 = Lighting.GetColor((int)((double)projectile.position.X + (double)projectile.width * 0.5) / 16, (int)(((double)projectile.position.Y + (double)projectile.height * 0.5) / 16.0));
			Vector2 end3 = projectile.position + new Vector2((float)projectile.width, (float)projectile.height) / 2f + Vector2.UnitY * projectile.gfxOffY - Main.screenPosition;
			Texture2D tex4 = Main.extraTexture[33];
			projectile.GetAlpha(color25);
			Vector2 scale17 = new Vector2(projectile.scale) / 8f;
			int num43;
			for (int num297 = 0; num297 < 2; num297 = num43 + 1)
			{
				float num298 = (projectile.localAI[1] == -1f || projectile.localAI[1] == 1f) ? -0.2f : 0f;
				if (num297 == 0)
				{
					scale17 = new Vector2(projectile.scale) * (0.5f + num298);
					DelegateMethods.c_1 = new Microsoft.Xna.Framework.Color(86, 255, 220) * 0.5f;
				}
				else
				{
					scale17 = new Vector2(projectile.scale) * (0.3f + num298);
					DelegateMethods.c_1 = new Microsoft.Xna.Framework.Color(232, 255, 250, 0) * 0.5f;
				}
				DelegateMethods.f_1 = 1f;
				for (int num299 = projectile.oldPos.Length - 1; num299 > 0; num299 = num43 - 1)
				{
					if (!(projectile.oldPos[num299] == Vector2.Zero))
					{
						Vector2 start3 = projectile.oldPos[num299] + new Vector2((float)projectile.width, (float)projectile.height) / 2f + Vector2.UnitY * projectile.gfxOffY - Main.screenPosition;
						Vector2 end4 = projectile.oldPos[num299 - 1] + new Vector2((float)projectile.width, (float)projectile.height) / 2f + Vector2.UnitY * projectile.gfxOffY - Main.screenPosition;
						Utils.DrawLaser(Main.spriteBatch, tex4, start3, end4, scale17, new Utils.LaserLineFraming(DelegateMethods.LightningLaserDraw));
					}
					num43 = num299;
				}
				if (projectile.oldPos[0] != Vector2.Zero)
				{
					DelegateMethods.f_1 = 1f;
					Vector2 start4 = projectile.oldPos[0] + new Vector2((float)projectile.width, (float)projectile.height) / 2f + Vector2.UnitY * projectile.gfxOffY - Main.screenPosition;
					Utils.DrawLaser(Main.spriteBatch, tex4, start4, end3, scale17, new Utils.LaserLineFraming(DelegateMethods.LightningLaserDraw));
				}
				num43 = num297;
			}
			return false;
		}
	}
}
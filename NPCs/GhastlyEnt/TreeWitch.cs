using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Events;
using System;

namespace ForgottenMemories.NPCs.GhastlyEnt
{
	public class TreeWitch : ModNPC
	{
		int counter = 0;
		int ai;
		public override void SetDefaults()
		{
			npc.width = 50;
			npc.height = 70;
			npc.damage = 28;
			npc.defense = 10;
			npc.lifeMax = 80;
			npc.HitSound = SoundID.NPCHit7;
			npc.DeathSound = SoundID.NPCDeath3;
			npc.value = 70f;
			npc.knockBackResist = 1f;
			npc.aiStyle = 3;
			aiType = NPCID.AngryBones;
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Ent Witch");
			Main.npcFrameCount[npc.type] = 4;
			animationType = NPCID.Zombie;
		}
		
		public override void AI()
		{
			ai++;
			if (ai >= 60)
			{
				Player player = Main.player[npc.target];
				Vector2 vel = (player.Center - npc.Center);
				vel.Normalize();
				vel *= 6;
				Projectile projectile = Main.projectile[Projectile.NewProjectile(npc.Center, vel, mod.ProjectileType("DarkMagic"), (int)(npc.damage/4), 0, Main.myPlayer, 0, 0)];
				projectile.friendly = false;
				projectile.hostile = true;
				ai = 0;
			}
		}
		
		public override void NPCLoot()
		{
			int amountToDrop = Main.rand.Next(2,8);
			int type = (WorldGen.crimson) ? ItemID.Shadewood : ItemID.Ebonwood;
			Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, type, amountToDrop);
		}
	}
}
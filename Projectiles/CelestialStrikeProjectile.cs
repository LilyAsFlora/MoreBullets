using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MoreBulletsMod.Projectiles
{
	class CelestialStrikeProjectile : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Celestial Strike");

			ProjectileID.Sets.TrailCacheLength[projectile.type] = 5;
			ProjectileID.Sets.TrailingMode[projectile.type] = 0;
		}

		public override void SetDefaults()
		{
			projectile.width = 5;
			projectile.height = 10;
			projectile.aiStyle = 1;
			projectile.friendly = true;
			projectile.hostile = false;
			projectile.ranged = true;
			projectile.penetrate = 10; 
			projectile.timeLeft = 60 * 10;
			projectile.alpha = 255;
			projectile.ignoreWater = true;
			projectile.tileCollide = true;
			aiType = ProjectileID.Bullet;
			projectile.light = 0.3f;
			projectile.extraUpdates = 2;
			projectile.usesLocalNPCImmunity = true;
			projectile.localNPCHitCooldown = -1;
		}

		public override Color? GetAlpha(Color lightColor)
		{
			return new Color(255, 255, 255, 200) * ((255f - projectile.alpha) / 255f);
		}

        public override void AI()
		{
			if (Main.rand.NextBool(10))
			{
				List<Color> colors = new List<Color>()
				{
					Color.Orange,
					Color.Blue,
					Color.Pink,
					Color.Green
				};

				Dust.NewDustPerfect(projectile.position + projectile.velocity, DustID.MagicMirror, default, 255, colors[Main.rand.Next(colors.Count)]);
			}
		}

		public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
		{
			Vector2 drawOrigin = new Vector2(Main.projectileTexture[projectile.type].Width * 0.5f, projectile.height * 0.5f);
			for (int k = 0; k < projectile.oldPos.Length; k++)
			{
				Vector2 drawPos = projectile.oldPos[k] - Main.screenPosition + drawOrigin + new Vector2(0f, projectile.gfxOffY);
				Color color = projectile.GetAlpha(lightColor) * ((float)(projectile.oldPos.Length - k) / (float)projectile.oldPos.Length);
				spriteBatch.Draw(Main.projectileTexture[projectile.type], drawPos, null, color, projectile.rotation, drawOrigin, projectile.scale, SpriteEffects.None, 0f);
			}
			return true;
		}

		public override void Kill(int timeLeft)
		{
			for (int i = 0; i < 3; i++)
			{
				Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, DustID.MagicMirror, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f, 0, default, 1.5f);
			}

			Collision.HitTiles(projectile.position + projectile.velocity, projectile.velocity, projectile.width, projectile.height);
			Main.PlaySound(SoundID.Item10, projectile.position);
		}
	}
}

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MoreBulletsMod.Projectiles
{
	class LifestealShotProjectile : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Lifesteal Shot");

			ProjectileID.Sets.TrailCacheLength[projectile.type] = 5;
			ProjectileID.Sets.TrailingMode[projectile.type] = 0;
		}

		public override void SetDefaults()
		{
			projectile.height = 8;
			projectile.width = 1;
			projectile.aiStyle = 1;
			projectile.friendly = true;
			projectile.hostile = false;
			projectile.ranged = true;
			projectile.penetrate = 1;
			projectile.timeLeft = 60 * 10;
			projectile.alpha = 255;
			projectile.light = 0.3f;
			projectile.ignoreWater = true;
			projectile.tileCollide = true;
			projectile.extraUpdates = 1;
			projectile.alpha = 255;
			aiType = ProjectileID.Bullet;
		}

		public override Color? GetAlpha(Color lightColor)
        {
			return new Color(255, 255, 255, 200) * ((255f - projectile.alpha) / 255f);
		}
		
        public override void AI()
		{
			if (Main.rand.NextBool(2))
			{
				Dust.NewDustPerfect(projectile.position + projectile.velocity, ModContent.DustType<Dusts.LifeHeart>(), default, 0, default, default);
			}
		}

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
			if (Main.rand.NextBool(2))
            {
				Player owner = Main.player[projectile.owner];
				int healAmount;

				healAmount = Main.rand.Next(1, 3);

				owner.statLife += healAmount;
				owner.HealEffect(healAmount);
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
				Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, ModContent.DustType<Dusts.LifeHeart>(), projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f, 0, default, 1.5f);
			}

			Collision.HitTiles(projectile.position + projectile.velocity, projectile.velocity, projectile.width, projectile.height);
			Main.PlaySound(SoundID.Item10, projectile.position);
		}
	}
}

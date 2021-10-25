using System.Collections.Generic;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace MoreBulletsMod.Items.Weapons
{
    class RandomizerBolt : ModItem
    {
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Converts to a random vanilla bullet when fired.");
			Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(7, 3));
		}

		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.MusketBall);
			item.damage = 11;            
			item.knockBack = 3f;
			item.value = Item.buyPrice(copper: 40);
			item.rare = ItemRarityID.Cyan;
		}

        public override void PickAmmo(Item weapon, Player player, ref int type, ref float speed, ref int damage, ref float knockback)
        {
			List<short> vanillaBulletProjectiles = new List<short>() 
			{ 
				ProjectileID.Bullet, 
				ProjectileID.MeteorShot, 
				ProjectileID.CrystalBullet, 
				ProjectileID.CursedBullet,
				ProjectileID.ChlorophyteBullet,
				ProjectileID.BulletHighVelocity,
				ProjectileID.IchorBullet,
				ProjectileID.VenomBullet,
				ProjectileID.PartyBullet,
				ProjectileID.NanoBullet,
				ProjectileID.ExplosiveBullet,
				ProjectileID.GoldenBullet,
				ProjectileID.MoonlordBullet,
			};

			type = vanillaBulletProjectiles[Main.rand.Next(vanillaBulletProjectiles.Count)];
        }
    }
}

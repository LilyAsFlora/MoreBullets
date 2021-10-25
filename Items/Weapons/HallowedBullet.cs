using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MoreBulletsMod.Items.Weapons
{
	class HallowedBullet : ModItem
	{
        public override void SetStaticDefaults()
        {
			Tooltip.SetDefault("[c/FF99CC:100% Real]\nHas a chance to replicate itself as a powerful mirage.\nMirage damage, knockback, and speed are increased by 150%.");
        }

        public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.CrystalBullet);
			item.damage = 11;
			item.shoot = ModContent.ProjectileType<Projectiles.HallowedBulletProjectile>();
		}

        public override void PickAmmo(Item weapon, Player player, ref int type, ref float speed, ref int damage, ref float knockback) 
        {
			if (Main.rand.NextBool(5))
            {
				type = ModContent.ProjectileType<Projectiles.HallowedBulletMirage>();

				damage += damage / 2;
				knockback += knockback / 2;
				speed += speed / 2;
            }
        }

        public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.HallowedBar);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this, 333);
			recipe.AddRecipe();
		}
	}
}

using Terraria.ID;
using Terraria.ModLoader;

namespace MoreBulletsMod.Items.Weapons
{
	class AdamantiteBullet : ModItem
	{
		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.CrystalBullet);
			item.damage = 11;
			item.shoot = ModContent.ProjectileType<Projectiles.AdamantiteBulletProjectile>();
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.AdamantiteBar);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this, 150);
			recipe.AddRecipe();
		}
	}
}

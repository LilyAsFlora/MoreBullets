using Terraria.ID;
using Terraria.ModLoader;

namespace MoreBulletsMod.Items.Weapons
{
	class TitaniumBullet : ModItem
	{
		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.CrystalBullet);
			item.damage = 11;
			item.shoot = ModContent.ProjectileType<Projectiles.TitaniumBulletProjectile>();
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.TitaniumBar);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this, 150);
			recipe.AddRecipe();
		}
	}
}

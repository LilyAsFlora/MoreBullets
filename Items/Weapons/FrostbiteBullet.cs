using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MoreBulletsMod.Items.Weapons
{
	class FrostbiteBullet : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("[c/BBCCFF:Is it me, or is it getting cold in here?]\nHas a chance to inflict frostburn.");
		}

		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.MusketBall);
			item.value = Item.buyPrice(copper: 8);
			item.shoot = ModContent.ProjectileType<Projectiles.FrostbiteBulletProjectile>(); 
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.MusketBall, 70);
			recipe.AddIngredient(ItemID.IceTorch, 2);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this, 70);
			recipe.AddRecipe();
		}
	}
}

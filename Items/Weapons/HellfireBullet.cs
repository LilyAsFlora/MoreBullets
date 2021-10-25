using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MoreBulletsMod.Items.Weapons
{
    class HellfireBullet : ModItem
    {
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("[c/FFCC55:Light 'em up!]\nSets targets on fire.");
		}

		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.MusketBall);
			item.damage = 9;          
			item.knockBack = 3f;
			item.value = Item.buyPrice(copper: 15);
			item.rare = ItemRarityID.Green;
			item.shoot = ModContent.ProjectileType<Projectiles.HellfireBulletProjectile>();         
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.MusketBall, 70);
			recipe.AddIngredient(ItemID.HellstoneBar);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this, 70);
			recipe.AddRecipe();
		}
	}
}

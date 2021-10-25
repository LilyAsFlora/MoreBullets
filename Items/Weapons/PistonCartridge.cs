using Terraria.ID;
using Terraria.ModLoader;

namespace MoreBulletsMod.Items.Weapons
{
    class PistonCartridge : ModItem
    {
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("To the moon.");
		}

		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.MusketBall);
			item.damage = 6;
			item.knockBack = 30f;
			item.shoot = ModContent.ProjectileType<Projectiles.PistonCartridgeProjectile>(); 
		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Wood, 2);
            recipe.AddIngredient(ItemID.IronBar);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this, 70);
			recipe.AddRecipe();
		}
	}
}

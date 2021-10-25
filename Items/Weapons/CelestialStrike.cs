using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace MoreBulletsMod.Items.Weapons
{
	class CelestialStrike : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("To the moon and back.\nIgnores immunity frames.");
			Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(8, 8));
		}

		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.MusketBall);
			item.damage = 19;
			item.value = Item.buyPrice(copper: 50);
			item.rare = ItemRarityID.Cyan;
			item.shoot = ModContent.ProjectileType<Projectiles.CelestialStrikeProjectile>();
			item.UseSound = SoundID.Item9;		
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.FragmentSolar);
			recipe.anyFragment = true;
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this, 150);
			recipe.AddRecipe();
		}
	}
}

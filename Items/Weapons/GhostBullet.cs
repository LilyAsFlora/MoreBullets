using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace MoreBulletsMod.Items.Weapons
{
    class GhostBullet : ModItem
    {
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("[c/555577:Spookiest shots in the west.]\nProjectiles pass through tiles.\nTargets become confused.");
			Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(5, 14));
		}

		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.MusketBall);
			item.damage = 15;             
			item.value = Item.buyPrice(copper: 40);
			item.rare = ItemRarityID.Yellow;
			item.shoot = ModContent.ProjectileType<Projectiles.GhostBulletProjectile>();
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Ectoplasm);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this, 150);
			recipe.AddRecipe();
		}
	}
}

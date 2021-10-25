using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MoreBulletsMod.Items.Weapons
{
    class CopperRound: ModItem
    {
        public override void SetDefaults()
        {
			item.CloneDefaults(ItemID.MusketBall);
			item.damage = 6;
			item.value = Item.buyPrice(copper: 5);
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.CopperBar);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this, 70);
			recipe.AddRecipe();
		}
	}
}
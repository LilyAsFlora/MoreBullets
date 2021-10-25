using Terraria.ID;
using Terraria.ModLoader;

namespace MoreBulletsMod
{
	public class MoreBulletsMod : Mod
	{
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.IronBar);
            recipe.anyIronBar = true;
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ItemID.MusketBall, 70);
            recipe.AddRecipe();
        }
	}
}
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MoreBulletsMod.Items.Armor
{
    [AutoloadEquip(EquipType.Head)]

	public class LilysRibbon : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Lily's Ribbon");
			Tooltip.SetDefault("[c/FF66BB:Somehow, it's made of steel.]");
		}
		public override void SetDefaults()
		{
			item.value = Item.buyPrice(gold: 1, silver: 10);
			item.rare = ItemRarityID.Pink;
			item.vanity = true;
		}

        public override void UpdateEquip(Player player)
        {
			if (!player.HasBuff(ModContent.BuffType<Buffs.Adorable>()))
			{
				player.AddBuff(ModContent.BuffType<Buffs.Adorable>(), 10);
			}
		}

		// Helmet doesn't remove hair from the player.
		public override void DrawHair(ref bool drawHair, ref bool drawAltHair)
        {
            drawHair = true;
        }
        public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Silk, 2);
			recipe.AddIngredient(ItemID.PinkThread, 1);
			recipe.AddTile(TileID.Loom);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}

}

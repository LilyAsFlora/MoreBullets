using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MoreBulletsMod.Items.Armor
{
    [AutoloadEquip(EquipType.Body)]

	public class LilysBlazer : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Lily's Blazer");
			Tooltip.SetDefault("[c/FF66BB:'U.D. Academy']");
		}
		public override void SetDefaults()
		{
			item.value = Item.buyPrice(gold: 4, silver: 30);
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

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Silk, 6);
			recipe.AddIngredient(ItemID.PinkThread, 4);
			recipe.AddTile(TileID.Loom);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}

}

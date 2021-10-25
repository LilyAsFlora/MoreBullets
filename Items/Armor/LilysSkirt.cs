using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MoreBulletsMod.Items.Armor
{
    [AutoloadEquip(EquipType.Legs)]

	public class LilysSkirt : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Lily's Skirt");
			Tooltip.SetDefault("[c/FF66BB:Feels familiar.]");
		}
		public override void SetDefaults()
		{
			item.value = Item.buyPrice(gold: 3, silver: 50);
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

        public override bool DrawLegs()
        {
			return false;
        }

        public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Silk, 5);
			recipe.AddIngredient(ItemID.PinkThread, 3);
			recipe.AddTile(TileID.Loom);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}

}

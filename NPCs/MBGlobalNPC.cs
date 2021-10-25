using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MoreBulletsMod.NPCs
{
    class MBGlobalNPC : GlobalNPC
    {
		public override void SetupShop(int type, Chest shop, ref int nextSlot)
		{
			if (type == NPCID.ArmsDealer) 
			{
				shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.Weapons.CopperRound>());
				nextSlot++;

				shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.Weapons.TinRound>());
				nextSlot++;

				if (NPC.downedBoss1)
                {
					shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.Weapons.PistonCartridge>());
					nextSlot++;

					shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.Weapons.FrostbiteBullet>());
					nextSlot++;
				}

				if (NPC.downedBoss2)
				{
					shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.Weapons.HellfireBullet>());
					nextSlot++;
				}

				if (Main.hardMode)
                {
					shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.Weapons.LifestealShot>());
					nextSlot++;

					shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.Weapons.AdamantiteBullet>());
					nextSlot++;

					shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.Weapons.TitaniumBullet>());
					nextSlot++;
				}

				if (NPC.downedMechBoss1 || NPC.downedMechBoss2 || NPC.downedMechBoss3)
                {
					shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.Weapons.HallowedBullet>());
					nextSlot++;
				}

				if (NPC.downedPlantBoss)
				{
					shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.Weapons.GhostBullet>());
					nextSlot++;

					shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.Weapons.RandomizerBolt>());
					nextSlot++;
				}

				if (NPC.downedAncientCultist)
                {
					shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.Weapons.CelestialStrike>());
					nextSlot++;
				}
			}

			if (type == NPCID.Clothier)
			{
				shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.Armor.LilysRibbon>());
				nextSlot++;

				shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.Armor.LilysBlazer>());
				nextSlot++;

				shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.Armor.LilysSkirt>());
				nextSlot++;
			}
		}

		public override void NPCLoot(NPC npc)
		{
			if (npc.type == NPCID.Pixie)
            {
				List<int> lilysSet = new List<int>()
				{
					ModContent.ItemType<Items.Armor.LilysRibbon>(),
					ModContent.ItemType<Items.Armor.LilysBlazer>(),
					ModContent.ItemType<Items.Armor.LilysSkirt>()
				};
				
				if (Main.rand.NextBool(10))
                {
					Item.NewItem(npc.getRect(), lilysSet[Main.rand.Next(lilysSet.Count)]);
                }
            }
		}
	}
}

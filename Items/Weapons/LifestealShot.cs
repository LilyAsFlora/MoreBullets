using System.Collections.Generic;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace MoreBulletsMod.Items.Weapons
{
    class LifestealShot : ModItem
    {
        public override void SetStaticDefaults() 
        { 
            Tooltip.SetDefault("[c/FF55B4:Don't have a life? Just steal one!]\nHas a chance to heal you on hit.\nLife is used as a crafting ingredient.");
            Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(5, 4));
        }

        public override void SetDefaults()
        {
            // Alternative to crystal bullets.
            item.CloneDefaults(ItemID.CrystalBullet);
            item.shoot = ModContent.ProjectileType<Projectiles.LifestealShotProjectile>();
        }

        public override void OnCraft(Recipe recipe)
        {
            Player player = Main.player[Main.myPlayer];

            List<string> deathReasons = new List<string>()
            {
                $"{player.name} was negligent.",
                $"{player.name} was impetuous.",
                $"{player.name} was incautious.",
                $"{player.name} was heedless.",
                $"{player.name} was reckless."
            };

            /*
             * By default, health cost is 20 - 35 HP for each set of 70 bullets.
             * If all 3 mechanical bosses are defeated, this is increased to 20 - 50.
             * If expert mode is active, health cost is increased by 150%.
             * The maximum possible health cost, is therefore 75 HP.
            */

            int damage;

            if (NPC.downedMechBoss1 && NPC.downedMechBoss2 && NPC.downedMechBoss3)
            {
                damage = Main.rand.Next(20, 51);
            }
            else
            {
                damage = Main.rand.Next(20, 36);
            }

            if (Main.expertMode)
            {
                damage += damage / 2;
            }

            player.Hurt(PlayerDeathReason.ByCustomReason(deathReasons[Main.rand.Next(deathReasons.Count)]), damage, -player.direction);
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.MusketBall, 70);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this, 70);
            recipe.AddRecipe();
        }
    }
}

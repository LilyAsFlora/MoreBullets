using Terraria;
using Terraria.ModLoader;

namespace MoreBulletsMod.Dusts
{
    class LifeHeart : ModDust
    {
        public override void OnSpawn(Dust dust)
        {
            dust.noGravity = true;
            dust.scale = 1f;
        }

        /*public override bool Update(Dust dust)
        {
            dust.position += dust.velocity;
            dust.scale -= 0.1f;

            if (dust.scale < 0.5f)
            {
                dust.active = false;
            }

            return false;
        }*/
    }
}

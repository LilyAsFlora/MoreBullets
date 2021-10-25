using Terraria.ModLoader;

namespace MoreBulletsMod
{
    public class MBPlayer : ModPlayer
    {
        public bool adorable;

        public override void ResetEffects()
        {
            adorable = false;
		}

		public override void UpdateDead()
		{
            adorable = false;
		}
	}
}

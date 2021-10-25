using Terraria;
using Terraria.ModLoader;

namespace MoreBulletsMod.Buffs
{
	public class Adorable : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Adorable");
			Description.SetDefault("You're so cute!");
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			player.GetModPlayer<MBPlayer>().adorable = true;
		}
	}
}
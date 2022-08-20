using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace TrueHardcore
{
	public class TrueHardcore : Mod
	{
		public class TrueHardcorePlayer : ModPlayer
		{
			public override bool PreKill(double damage, int hitDirection, bool pvp, ref bool playSound, ref bool genGore, ref PlayerDeathReason damageSource)
			{
                if (Player.difficulty == PlayerDifficultyID.Hardcore)
                {
                    foreach (Item item in Player.inventory)
                    {
                        item.TurnToAir();
                    }
                }

                return base.PreKill(damage, hitDirection, pvp, ref playSound, ref genGore, ref damageSource);
			}
        }
	}
}
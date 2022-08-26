using System.Reflection;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Default;

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
                    Erase(Player.inventory);
                    Erase(Player.armor);
                    Erase(Player.dye);
                    Erase(Player.miscEquips);
                    Erase(Player.miscDyes);
                    EraseFromModSlots();
                }

                return base.PreKill(damage, hitDirection, pvp, ref playSound, ref genGore, ref damageSource);
			}

            private void Erase(Item[] items)
            {
                foreach (Item item in items)
                {
                    item.TurnToAir();
                }
            }

            private void EraseFromModSlots()
            {
                ModAccessorySlotPlayer modAccessorySlotPlayer = Player.GetModPlayer<ModAccessorySlotPlayer>();

                FieldInfo[] fieldInfos = modAccessorySlotPlayer.GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic);
                foreach (FieldInfo fieldInfo in fieldInfos)
                {
                    if (fieldInfo.FieldType.IsArray && fieldInfo.FieldType == typeof(Item[]))
                    {
                        Item[] list = (Item[])fieldInfo.GetValue(modAccessorySlotPlayer);
                        Erase(list);
                    }
                }
            }
        }
	}
}
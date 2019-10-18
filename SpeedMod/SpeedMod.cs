using UnderMine.Modding;
using Thor;

namespace SpeedMod
{
    public class SpeedMod : ModHooks
    {
        public override void OnPlayerTick(SimulationPlayer player)
        {
            Entity avatar = player.Avatar;
            var extension = avatar.GetExtension<MoverExt>();
            extension.SetMaximumSpeed(15f);
        }
    }
}

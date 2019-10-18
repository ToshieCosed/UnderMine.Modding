using Thor;

namespace UnderMine.Modding
{    
    public abstract class ModHooks
    {
        /// <summary>
        /// Todo
        /// </summary>
        public virtual void OnModLoaded() { }

        /// <summary>
        /// Todo
        /// </summary>
        public virtual void OnMainMenuOpen() { }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="player">Todo</param>
        public virtual void OnPlayerTick(SimulationPlayer player) { }
    }
}

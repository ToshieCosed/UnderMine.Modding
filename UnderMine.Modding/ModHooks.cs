using Thor;
using UnityEngine;
using System.Linq;
using System;
using System.Collections.Generic;

namespace UnderMine.Modding
{    
    public abstract class ModHooks : MonoBehaviour
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

        /// <summary>
        /// Allows a mod to compile a list of strings to draw post-runtime, dynamically.
        /// </summary>
        /// <returns></returns>
        public virtual List<(string, Rect)> GetDrawables()
        {
            return null;
        }

    }
}

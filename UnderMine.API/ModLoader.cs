using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Thor;
using UnderMine.Modding;
using UnityEngine;

namespace UnderMine
{
    public class ModLoader
    {
        public List<ModHooks> hooks = new List<ModHooks>();

        public void LoadMods()
        {
            var modPath = Path.Combine(Application.dataPath, "Mods");
            if (!Directory.Exists(modPath))
                Directory.CreateDirectory(modPath);
            
            foreach (var path in Directory.GetFiles(modPath, "*.dll").Where(x => !x.StartsWith("_")))
            {
                try
                {
                    var assembly = Assembly.LoadFrom(path);
                    hooks.AddRange(from t in assembly.GetExportedTypes()
                                   where typeof(ModHooks).IsAssignableFrom(t)
                                   select assembly.CreateInstance(t.FullName) as ModHooks);
                }
                catch { }

                // Todo: Determine run order priority between mods and/or classes
            }
        }

        public virtual void OnMainMenuOpen()
        {
            foreach (var target in hooks)
            {
                target.OnMainMenuOpen();
            }
        }

        public void OnPlayerTick(SimulationPlayer player)
        {
            foreach (var target in hooks)
            {
                target.OnPlayerTick(player);
            }
        }
    }
}

using System;
using UnderMine.Modding;
using Thor;
using UnityEngine;
using System.Collections.Generic;

namespace GUIMod
{
    public class GuiMod : ModHooks
    {
        public override void OnPlayerTick(SimulationPlayer player)
        {
            //base.OnPlayerTick(player);
            //GameObject b = new GameObject();

            //was testing if we can do this, there was a class inhereting MonoBehavior but now may be un-needed.
            ///<summary>
            /*
            MonoBehaviour script = b.AddComponent(typeof(MonoBehaviour)) as MonoBehaviour;
            script = new GuiBehavior();
            b.SetActive(true);
            */

            /// </summary>
            /// 
            
           

        }

        public override List<(string, Rect)> GetDrawables()
        {
            List<(string, Rect)> debugs = new List<(string, Rect)>();
            debugs.Add( ("Hello OnGuiMod", new Rect(10, 10, 100, 20)) );
            return debugs;
        }

    }


}


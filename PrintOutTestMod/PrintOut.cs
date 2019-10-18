using System;
using System.Collections.Generic;
using System.IO;
using Thor;
using UnderMine.Modding;
using UnityEngine;


namespace PrintOutTestMod
{
    public class PrintOut : ModHooks
    {
        public float scrolly = 0;
        public int lasthp = 200; //game default
        List<string> postmessages = new List<string>();
        public float speed = 5; // like default
        public float normal_speed = 5;
        public bool slowed = false;
        public int slowness_ticks_base = 500;
        public int slowness_ticks_remaining = 0;
        SimulationPlayer player_ref;

        public override void OnModLoaded()
        {
            string loadfilename = "Printout.txt";
            if (File.Exists(loadfilename))
            {
                postmessages = File.ReadAllLines(loadfilename).ToList();
            }
        }

        public override void OnPlayerTick(SimulationPlayer player)
        {
            ScrollCanvas(0.5f);
            player_ref = player;
            bool took_hit = false;

            ///summary
            /// Try to curse the player every time they take damage


            Entity avatar = player_ref.Avatar;

            HealthExt e = avatar.GetExtension<HealthExt>();
            MoverExt extension = avatar.GetExtension<MoverExt>();
            if (e.CurrentHP < lasthp)
            {

                if (!slowed)
                {
                    float potspeed = extension.MaximumSpeed;
                    if (potspeed > speed)
                    {
                        speed = potspeed;
                    }
                }


            int chance = UnityEngine.Random.Range(0, 3);
                switch (chance)
                {
                    case 1:
                        e.AddRandomCurse(HealthExt.CurseType.Major, avatar);
                        took_hit = true;
                        break;

                    case 2:
                        if (!slowed)
                        {
                            slowed = true;
                            CreatePlayerPopup("SLOWNESS EFFECT");
                            slowness_ticks_remaining = slowness_ticks_base;
                            normal_speed = speed;
                            extension.SetMaximumSpeed(normal_speed / 3f);
                            speed = (normal_speed / 3f);
                        }
                        break;
                }
            }
           

            lasthp = e.CurrentHP;

            if (e.CurrentHP < 60 && took_hit ) {CreatePlayerPopup("It hurts, I can feel my health sapping away!"); }


            //Unslow the player
            //And tick
            if (slowed)
            {
                slowness_ticks_remaining -= 1;
                if (slowness_ticks_remaining <= 0)
                {
                    slowness_ticks_remaining = 0;
                    slowed = false;
                    extension.SetMaximumSpeed(normal_speed);
                    speed = normal_speed;
                    CreatePlayerPopup("SLOWNESS FADED");
                }
            }

            int value = UnityEngine.Random.Range(0, 1000);
            
            if (player_ref != null)
            {
                if (value == 5)
                {
                    CreatePlayerPopup(postmessages[UnityEngine.Random.Range(0, postmessages.Count-1)]);
                }
            }

        }   

        public void CreatePlayerPopup(string textItem)
        {
            Entity avatar = player_ref.Avatar;
            
                Popup KpopupCenter = Resources.Load<Popup>("UI/Popups/Dialog/SpeechPopup");
                Popup popup = KpopupCenter;

                LocID id = new LocID(10);
                id.Text = textItem;

              
                Popup popup2 = Game.Instance.PopupManager.CreatePopup(popup, id, avatar, avatar.gameObject.transform.localPosition, null);
                popup.Duration = 1000;
                
                
                
        }


        public override List<(string, Rect)> GetDrawables()
        {
            List<(string, Rect)> messagelist = ComposeVirtualCanvas();
            return messagelist;
        }

        public void AddMessage(string message)
        {
            postmessages.Add(message);
        }

        public List<(string, Rect)> ComposeVirtualCanvas()
        {
            List<(string, Rect)> CanvasMessages = new List<(string, Rect)>();
            int scrolloffset = 0;
            foreach(var m in postmessages)
            {
                CanvasMessages.Add((m, new Rect(0, scrolly + (scrolloffset*20), 100, 20)));
                scrolloffset += 1;
               
               
            }

            

            return CanvasMessages;
        }

        public void ScrollCanvas(float amount)
        {
            scrolly -= amount;
        }
    }
}

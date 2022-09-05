﻿using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace Verdant.Foreground
{
    public static class ForegroundManager
    {
        private static readonly List<ForegroundItem> items = new List<ForegroundItem>();

        public static void Run()
        {
            List<ForegroundItem> removals = new List<ForegroundItem>();

            //Rectangle screen = new Rectangle((int)Main.screenPosition.X - Main.offScreenRange, (int)Main.screenPosition.Y - Main.offScreenRange, Main.screenWidth + Main.offScreenRange, Main.screenHeight + Main.offScreenRange);

            foreach (var val in items)
            {
                if (Main.hasFocus && !Main.gamePaused)
                val.Update();

                val.Draw();
                if (val.killMe)
                    removals.Add(val);
            }

            foreach (var item in removals)
                items.Remove(item);
        }

        //public static void Load(TagCompound info)
        //{
        //}

        public static void Unload() => items.Clear();

        public static void AddItem(ForegroundItem item)
        {
            if (!ModContent.GetInstance<VerdantServerConfig>().BackgroundObjects) //Skip if option is turned off
                return;

            items.Add(item);
        }

        /// <summary>Shorthand for ModContent.ModContent.Request<Texture2D>("Verdant/Foreground/Textures/" + name).</summary>
        /// <param name="name">Name of the requested texture.</param>
        public static Texture2D GetTexture(string name) => VerdantMod.Instance.Assets.Request<Texture2D>("Foreground/Textures/" + name).Value;

        internal static TagCompound Save()
        {
            TagCompound compound = new TagCompound();
            foreach (var item in items)
            {
                if (item.SaveMe)
                {
                    var value = item.Save();
                    if (value == null)
                        continue;

                    compound.Add("fgInfo", value);
                }
            }
            return compound;
        }
    }
}

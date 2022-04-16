﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ModLoader;

namespace Verdant.Backgrounds.BGItem.Verdant
{
    public class FlotieBG : BaseBGItem
    {
        private int scaleTimer = 0;
        private float timer = 0;

        public const int SpawnChance = 150;

        private readonly int scaleDecay = 0;
        private readonly float scaleSpd = 0f;

        public FlotieBG(Vector2 pos) : base(pos, Vector2.Zero, new Point(0, 0))
        {
            tex = ModContent.GetTexture("Verdant/Backgrounds/BGItem/Verdant/Flotie");
            source = new Rectangle(0, 0, tex.Width, tex.Height);

            scaleDecay = Main.rand.Next(2500, 2800);
            scaleSpd = Main.rand.NextFloat(0.002f, 0.005f);
            parallax = Main.rand.NextFloat(0.5f, 0.95f);

            timer = Main.rand.Next(10000);

            source = new Rectangle(63 * Main.rand.Next(3), 0, 62, 82);
        }

        internal override void Behaviour()
        {
            base.Behaviour();
            velocity.X = (float)Math.Sin((timer++ * 2) * 0.004f) * 0.4f;
            velocity.Y = (float)Math.Sin(timer * 0.004f) * 0.4f;

            scaleTimer++;
            if (scaleTimer++ < scaleDecay - 120 && Scale < parallax)
                Scale += scaleSpd;
            else if (scaleTimer > scaleDecay - 100)
                scale *= 0.987f;

            if (scaleTimer > scaleDecay && Scale < 0.005f)
                killMe = true;

            rotation = velocity.X * 0.4f;
        }

        internal override void Draw(Vector2 off)
        {
            drawColor = Color.Lerp(new Color(0.6f, 0.24f, 0.42f), Main.bgColor, (drawColor.R - 10) / 245f);
            base.Draw(Vector2.Zero);
            Color col = Color.Lerp(new Color(0.72f, 0.230f, 0.50f), Color.White, (drawColor.R - 10) / 245f);
            Main.spriteBatch.Draw(tex, DrawPosition - Main.screenPosition, new Rectangle(source.X, 90, 62, 23), col, rotation, tex.Bounds.Center.ToVector2(), scale, SpriteEffects.None, 0f);
        }
    }
}

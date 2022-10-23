﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using Terraria;

namespace Verdant
{
    public static class Extensions
    {
        public static Point Add(this Point p, Point other) => new Point(p.X + other.X, p.Y + other.Y);
        public static Point Mul(this Point p, int mult) => new Point(p.X * mult, p.Y * mult);

        public static Point TileCoordsBottomCentred(this Player p, Vector2? offset = null)
        {
            Vector2 off = offset ?? Vector2.Zero;
            return new Point((int)((p.Center.X + off.X - 8) / 16f), (int)((p.Bottom.Y + off.Y + 4) / 16f));
        }

        public static Point TileCoordsBottomLeft(this Player p, Vector2? offset = null)
        {
            Vector2 off = offset ?? Vector2.Zero;
            return new Point((int)((p.BottomLeft.X + off.X) / 16f), (int)((p.BottomLeft.Y + off.Y + 4) / 16f));
        }

        public static Point TileCoordsBottomRight(this Player p, Vector2? offset = null)
        {
            Vector2 off = offset ?? Vector2.Zero;
            return new Point((int)((p.BottomRight.X + off.X) / 16f), (int)((p.BottomRight.Y + off.Y + 4) / 16f));
        }

        public static Color GetLightColor(this NPC n) => Lighting.GetColor((int)(n.Center.X / 16f), (int)(n.Center.Y / 16f));

        public static bool ArmourEquipped(this Player player, int type)
        {
            for (int k = 0; k <= 3; k++)
                if (player.armor[k].type == type) return true;
            return false;
        }
        public static bool ArmourEquipped(this Player player, Item item) => player.ArmourEquipped(item.type);

        public static bool ArmourSetEquipped(this Player player, int head, int body, int legs) => (player.armor[0].type == head && player.armor[1].type == body && player.armor[2].type == legs);

        public static bool AccessoryEquipped(this Player player, int type)
        {
            for (int k = 3; k <= 7 + player.extraAccessorySlots; k++)
                if (player.armor[k].type == type) return true;
            return false;
        }
        public static bool AccessoryEquipped(this Player player, Item item) => player.AccessoryEquipped(item.type);

        public static Player Owner(this Projectile p) => Main.player[p.owner];

        public static IEnumerable<T> Distinct<T, U>(this IEnumerable<T> seq, Func<T, U> getKey)
        {
            return  from item in seq
                    group item by getKey(item) into gp
                    select gp.First();
        }
    }
}
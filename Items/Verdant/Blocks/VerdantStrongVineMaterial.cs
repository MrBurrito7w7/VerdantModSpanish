﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Verdant.Tiles.Verdant.Basic.Blocks;
using Verdant.Tiles.Verdant.Basic.Plants;
using static Terraria.ModLoader.ModContent;

namespace Verdant.Items.Verdant.Blocks
{
    public class VerdantStrongVineMaterial : ModItem
    {
        public override void SetStaticDefaults() => QuickItem.SetStatic(this, "Hardy Vine", "'It takes quite the sharp blade to cut through these'");
        public override void SetDefaults() => QuickItem.SetMaterial(this, 16, 16, 0, 999, true);

        public override bool CanUseItem(Player player)
        {
            Point p = Main.MouseWorld.ToTileCoordinates();
            bool c = !Framing.GetTileSafely(p.X, p.Y).active() || Main.tileCut[Framing.GetTileSafely(p.X, p.Y).type];
            bool a = Helper.ActiveType(p.X, p.Y - 1, TileType<VerdantGrassLeaves>()) || Helper.ActiveType(p.X, p.Y - 1, TileType<VerdantStrongVine>());
            return c && a;
        }

        public override bool UseItem(Player player)
        {
            Point p = Main.MouseWorld.ToTileCoordinates();
            WorldGen.PlaceTile(p.X, p.Y, TileType<VerdantStrongVine>(), false, false);
            return true;
        }

        public override void HoldItem(Player player)
        {
            if (CanUseItem(player))
            {
                player.showItemIconText = "";
                player.showItemIcon2 = item.type;
                player.noThrow = 2;
                player.showItemIcon = true;
            }
        }
    }
}

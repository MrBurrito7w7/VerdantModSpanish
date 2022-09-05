﻿using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria;
using Verdant.Tiles.Verdant.Basic.Blocks;
using Microsoft.Xna.Framework.Graphics;

namespace Verdant.Tiles.Verdant.Basic
{
    internal class VerdantDecor1x1 : ModTile, IFlowerTile
    {
        public override void SetStaticDefaults()
        {
            TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile, 1, 0);
            TileObjectData.newTile.AnchorValidTiles = new int[] { ModContent.TileType<VerdantGrassLeaves>(), ModContent.TileType<LushSoil>() };
            TileObjectData.newTile.RandomStyleRange = 7;
            TileObjectData.newTile.StyleHorizontal = true;
            QuickTile.SetMulti(this, 1, 1, DustID.Grass, SoundID.Grass, false, new Color(161, 226, 99));
            Main.tileCut[Type] = true;

            Terraria.GameContent.Metadata.TileMaterials.SetForTileId(Type, Terraria.GameContent.Metadata.TileMaterials._materialsByName["Plant"]);
            TileID.Sets.SwaysInWindBasic[Type] = true;
        }

        public override void NumDust(int i, int j, bool fail, ref int num) => num = 3;
        public override void SetSpriteEffects(int i, int j, ref SpriteEffects effects) => effects = (i % 2 == 0) ? SpriteEffects.None : SpriteEffects.FlipHorizontally;

        public Vector2[] GetOffsets() => new Vector2[] { new Vector2(12, 6), new Vector2(8, 10) };
        public bool IsFlower(int i, int j) => Main.tile[i, j].TileFrameX != 18 && Main.tile[i, j].TileFrameX != 36;

        public Vector2[] OffsetAt(int i, int j)
        {
            var offsets = GetOffsets();
            Tile tile = Main.tile[i, j];

            if (tile.TileFrameX == 0)
                return new[] { offsets[0] };
            return new[] { offsets[1] };
        }
    }

    internal class VerdantDecor1x1NoCut : ModTile
    {
        public override void SetStaticDefaults()
        {
            TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile, 1, 0);
            TileObjectData.newTile.AnchorValidTiles = new int[] { ModContent.TileType<VerdantGrassLeaves>(), ModContent.TileType<LushSoil>() };
            TileObjectData.newTile.RandomStyleRange = 4;
            TileObjectData.newTile.StyleHorizontal = true;
            Main.tileCut[Type] = false;
            QuickTile.SetMulti(this, 1, 1, DustID.Stone, SoundID.Dig, false, new Color(161, 226, 99));
        }

        public override void NumDust(int i, int j, bool fail, ref int num) => num = 3;
        public override void SetSpriteEffects(int i, int j, ref SpriteEffects effects) => effects = (i % 2 == 0) ? SpriteEffects.None : SpriteEffects.FlipHorizontally;
    }

    internal class VerdantDecor2x1 : ModTile, IFlowerTile
    {
        public override void SetStaticDefaults()
        {
            TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile, 2, 0);
            TileObjectData.newTile.AnchorValidTiles = new int[] { ModContent.TileType<VerdantGrassLeaves>(), ModContent.TileType<LushSoil>() };
            TileObjectData.newTile.RandomStyleRange = 6;
            TileObjectData.newTile.StyleHorizontal = true;
            QuickTile.SetMulti(this, 2, 1, DustID.Grass, SoundID.Grass, true, new Color(161, 226, 99));

            Terraria.GameContent.Metadata.TileMaterials.SetForTileId(Type, Terraria.GameContent.Metadata.TileMaterials._materialsByName["Plant"]);
            TileID.Sets.SwaysInWindBasic[Type] = true;
        }

        public Vector2[] GetOffsets() => new Vector2[] { new Vector2(16, 8) };
        public bool IsFlower(int i, int j) => true;
        public Vector2[] OffsetAt(int i, int j) => GetOffsets();
    }

    internal class VerdantDecor2x2 : ModTile, IFlowerTile
    {
        public override void SetStaticDefaults()
        {
            TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile, 2, 0);
            TileObjectData.newTile.AnchorValidTiles = new int[] { ModContent.TileType<VerdantGrassLeaves>(), ModContent.TileType<LushSoil>() };
            TileObjectData.newTile.RandomStyleRange = 8;
            TileObjectData.newTile.StyleHorizontal = true;
            QuickTile.SetMulti(this, 2, 2, DustID.Grass, SoundID.Grass, true, new Color(161, 226, 99));
        }

        public Vector2[] GetOffsets() => new Vector2[] { new Vector2(16, 16), new Vector2(7, 10), new Vector2(30, 12), new Vector2(3, 23) };

        public bool IsFlower(int i, int j)
        {
            Tile tile = Main.tile[i, j];
            return tile.TileFrameX == 180 || tile.TileFrameX == 144;
        }

        public Vector2[] OffsetAt(int i, int j) => GetOffsets();
    }

    internal class VerdantDecor1x2 : ModTile
    {
        public override void SetStaticDefaults()
        {
            TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile, 1, 0);
            TileObjectData.newTile.AnchorValidTiles = new int[] { ModContent.TileType<VerdantGrassLeaves>(), ModContent.TileType<LushSoil>() };
            TileObjectData.newTile.RandomStyleRange = 6;
            TileObjectData.newTile.StyleHorizontal = true;
            QuickTile.SetMulti(this, 1, 2, DustID.Grass, SoundID.Grass, true, new Color(161, 226, 99));
            Main.tileCut[Type] = true;
        }
        public override void SetSpriteEffects(int i, int j, ref SpriteEffects effects) => effects = (i % 2 == 0) ? SpriteEffects.None : SpriteEffects.FlipHorizontally;
    }

    internal class VerdantDecor1x3 : ModTile
    {
        public override void SetStaticDefaults()
        {
            TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile, 1, 0);
            TileObjectData.newTile.AnchorValidTiles = new int[] { ModContent.TileType<VerdantGrassLeaves>(), ModContent.TileType<LushSoil>() };
            TileObjectData.newTile.RandomStyleRange = 7;
            TileObjectData.newTile.StyleHorizontal = true;
            QuickTile.SetMulti(this, 1, 3, DustID.Grass, SoundID.Grass, true, new Color(161, 226, 99));
            Main.tileCut[Type] = true;
        }
        public override void SetSpriteEffects(int i, int j, ref SpriteEffects effects) => effects = (i % 2 == 0) ? SpriteEffects.None : SpriteEffects.FlipHorizontally;
    }
}
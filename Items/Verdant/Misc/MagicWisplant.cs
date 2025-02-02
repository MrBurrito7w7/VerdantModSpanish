﻿using Terraria.ID;
using Terraria.ModLoader;
using Verdant.Items.Verdant.Materials;
using Verdant.Projectiles.Misc;

namespace Verdant.Items.Verdant.Misc;

[Sacrifice(3)]
internal class MagicWisplant : ModItem
{
    public override void SetDefaults()
    {
        Item.CloneDefaults(ItemID.ThrowingKnife);
        Item.damage = 0;
        Item.useTime = 25;
        Item.useAnimation = 25;
        Item.autoReuse = true;
        Item.shoot = ModContent.ProjectileType<MagicWisplantProj>();
        Item.shootSpeed = 6f;
        Item.rare = ItemRarityID.Green;
    }

    public override void AddRecipes() => QuickItem.AddRecipe(this, TileID.Bottles, 1, (ModContent.ItemType<LushLeaf>(), 6), (ModContent.ItemType<WisplantItem>(), 1), (ItemID.FallenStar, 3));
}

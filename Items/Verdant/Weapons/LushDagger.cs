﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Verdant.Projectiles.Throwing;
using Verdant.Systems.ScreenText.Caches;
using Verdant.Systems.ScreenText;

namespace Verdant.Items.Verdant.Weapons;

class LushDagger : ApotheoticItem
{
    public override void SetDefaults()
    {
        Item.CloneDefaults(ItemID.ThrowingKnife);
        Item.damage = 8;
        Item.useTime = 5;
        Item.useAnimation = 15;
        Item.reuseDelay = 15;
        Item.autoReuse = true;
        Item.shoot = ModContent.ProjectileType<LushDaggerProj>();
    }

    public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
    {
        velocity = velocity.RotatedByRandom(0.07f) * Main.rand.NextFloat(0.96f, 1.04f);
    }

    [DialogueCacheKey(nameof(ApotheoticItem) + "." + nameof(LushDagger))]
    public override ScreenText Dialogue(bool forServer)
    {
        if (forServer)
            return null;

        if (!ModContent.GetInstance<VerdantClientConfig>().CustomDialogue)
            return ApotheosisDialogueCache.ChatLength("$Mods.Verdant.ScreenText.Apotheosis.ItemInteractions.LushDagger.", 2, true);

        return ApotheosisDialogueCache.StartLine("$Mods.Verdant.ScreenText.Apotheosis.ItemInteractions.LushDagger.0").
            FinishWith(new ScreenText("$Mods.Verdant.ScreenText.Apotheosis.ItemInteractions.LushDagger.1"));
    }
}

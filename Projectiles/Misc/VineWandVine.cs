﻿using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.ID;

namespace Verdant.Projectiles.Misc
{
    public class VineWandVine : ModProjectile
    {
        public int nextVine = -1;
        public int priorVine = -1;

        public ref float Timer => ref Projectile.ai[0];
        public ref float VineIndex => ref Projectile.ai[1];

        public Projectile NextVine => Main.projectile[nextVine];
        public Projectile PriorVine => Main.projectile[priorVine];

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Vine");

            Main.projFrames[Projectile.type] = 2;
        }

        public override void SetDefaults()
        {
            Projectile.hostile = false;
            Projectile.friendly = false;
            Projectile.width = 20;
            Projectile.height = 18;
            Projectile.tileCollide = false;
            Projectile.ignoreWater = true;
            Projectile.timeLeft = 10 * 60;
        }

        public override void AI()
        {
            Player p = Main.player[Projectile.owner];
            p.heldProj = Projectile.whoAmI;

            if (p.whoAmI != Main.myPlayer)
                return; //mp check (hopefully)

            if (priorVine != -1 && !PriorVine.active)
                priorVine = 1;

            if (nextVine != -1 && !NextVine.active)
                nextVine = 1;

            float rotOff = (float)System.Math.Sin((Timer++ + (VineIndex * 12)) * 0.05f) * 0.2f;
            if (priorVine != -1)
                Projectile.rotation = Projectile.AngleTo(PriorVine.Center) - MathHelper.PiOver2 + rotOff;
            else if (nextVine != -1)
                Projectile.rotation = Projectile.AngleTo(NextVine.Center) - MathHelper.PiOver2 + rotOff;

            Rectangle playerTop = new Rectangle((int)p.position.X, (int)p.position.Y, p.width, 2);

            if (playerTop.Intersects(Projectile.Hitbox) && (p.controlUp || p.controlDown) && !p.controlJump && !p.pulley && p.grappling[0] < 0 && !p.mount.Active && !Collision.SolidCollision(PulleyPosition(p), p.width, p.height) && Projectile.timeLeft > 3)
            {
                p.pulley = true;
                p.pulleyDir = 1;
                p.position = Projectile.position;
                p.fallStart = (int)(Projectile.position.Y / 16f);

                p.GetModPlayer<VinePulleyPlayer>().currentVine = Projectile.whoAmI;
            }
        }

        public Vector2 PulleyPosition(Player player)
        {
            float vineOff = player.GetModPlayer<VinePulleyPlayer>().vineOffset;
            float factor = 0;
            Vector2 otherPos = Projectile.Center;

            if (nextVine != -1 && vineOff <= 0.5f)
            {
                otherPos = Vector2.Lerp(NextVine.Center, Projectile.Center, 0.5f);
                factor = vineOff * 2f; 
            }
            else if (priorVine != -1 && vineOff > 0.5f)
            {
                otherPos = Vector2.Lerp(PriorVine.Center, Projectile.Center, 0.5f);
                factor = 1 - ((vineOff - 0.5f) * 2f);
            }

            return Vector2.Lerp(otherPos, Projectile.Center, factor) - new Vector2(player.width / 2f, -4);
        }

        public override void Kill(int timeLeft)
        {
            for (int i = 0; i < 3; ++i)
                Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.Grass, 0, 0);
        }
    }
}

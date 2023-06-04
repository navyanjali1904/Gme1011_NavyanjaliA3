using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GME1011_NavyanjaliA03
{
    internal class SunMoon
    {
        private int SunMoonX;
        private int SunMoonY;

        private Texture2D SunMoonTexture;

        private SpriteFont GameFont;

        public SunMoon(int MainSunX, int MainSunY, Texture2D MainSunSprite, SpriteFont GameFont)
        {
            if (SunMoonX< 0 ||SunMoonX> 500)
            {
                SunMoonX = 250;
            }
            if (SunMoonY < 0 || SunMoonY > 500)
            {
                SunMoonY = 75;
            }

            SunMoonX = MainSunX;
            SunMoonY = MainSunY;

            SunMoonTexture = MainSunSprite;
            this.GameFont = GameFont;

        }

        public int GetSunMoonX() { return SunMoonX; }
        public int GetSunMoonY() { return SunMoonY; }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin(SpriteSortMode.Deferred, null, SamplerState.PointClamp, null, null);
            spriteBatch.Draw(SunMoonTexture, new Vector2(SunMoonX, SunMoonY), null, Color.White, 0f, Vector2.Zero, 1, SpriteEffects.None, 0f);

            spriteBatch.End();
        }

    }





}

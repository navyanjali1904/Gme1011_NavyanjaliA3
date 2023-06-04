using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;



namespace GME1011_NavyanjaliA03
{
    internal class Cloud
    {
        private int CloudX;
        private int CloudY;
        private int cloudLifetime;
        private Texture2D CloudTexture;
        private Random rng;
        private int scale;

        private int MoveSpeed;
        private SpriteFont GameFont;


        public Cloud(int bluecloudX, int bluecloudY, Texture2D bluecloudSprite, SpriteFont GameFont, int CloudMoveSpeed, int SkyCloudLifetime)
        {
            if (CloudX <0 || CloudX> 1000)
            {
                CloudX = 250;
            }
            if (CloudY < 0 || CloudY > 75)
            {
                CloudY = 75;
            }
           
            if(cloudLifetime < 0 || cloudLifetime > 500)
            {
                cloudLifetime = 500;
            }
            if(MoveSpeed <0 || MoveSpeed > 1)
            {
                MoveSpeed = 1;
            }

            cloudLifetime = SkyCloudLifetime;
            CloudX = bluecloudX;
            CloudY = bluecloudY;
            CloudTexture = bluecloudSprite;
            this.GameFont = GameFont;
            MoveSpeed = CloudMoveSpeed;
            rng = new Random();
            scale = rng.Next(3, 6);
            

        }

        public int SkyCloudX() { return CloudX; }
        public int SkyCloudY() { return CloudY; }
        public float GetMoveSpeed() { return MoveSpeed; }

        public bool HasExpired() { return cloudLifetime <= 0; } //checks if the cloudLifetime is > 0 and returns true/false value 

        public void Update() //constantly updates cloud's x position by adding it with movespeed each frame
        {

            CloudX = CloudX + MoveSpeed;
            cloudLifetime--; //reduces cloud's lifetime by 1 each frame
        }
        


        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin(SpriteSortMode.Deferred, null, SamplerState.PointClamp, null, null);
            spriteBatch.Draw(CloudTexture, new Vector2(CloudX, CloudY), null, Color.White, 0f, Vector2.Zero, scale , SpriteEffects.None, 1f);
            spriteBatch.End();
        }
    }
}

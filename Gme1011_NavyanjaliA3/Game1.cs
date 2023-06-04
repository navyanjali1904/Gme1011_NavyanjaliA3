using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace GME1011_NavyanjaliA03
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Texture2D cloudTexture;
        private Texture2D SunTexture;
        private Texture2D MoonTexture;
        private Texture2D GroundTexture;
        private SpriteFont GameFont;
        private Cloud _cloud;
        private SunMoon _sunMoon;
        private SunMoon _sunMoon2;
        private int timer;


        private Random rng;

        List<Cloud> SkyCloud; //cloud list
        List<SunMoon> SkySunMoon; //sun + moon list
        List<Color> SkyColor; //color list
        private bool spacebarDown = false;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            _graphics.PreferredBackBufferWidth = 1000;
            _graphics.PreferredBackBufferHeight = 600;
            _graphics.ApplyChanges();

            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            rng = new Random();
            SkyCloud = new List<Cloud>();
            SkySunMoon = new List<SunMoon>();
            SkyColor = new List<Color>();
            base.Initialize();
            timer = 0; // timer for cloud generation
        }

        protected override void LoadContent()
        { //adding assets
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            cloudTexture = Content.Load<Texture2D>("Clouds");
            SunTexture = Content.Load<Texture2D>("sun");
            MoonTexture = Content.Load<Texture2D>("moonok");
            GroundTexture = Content.Load<Texture2D>("groundFinal");


            GameFont = Content.Load<SpriteFont>("GameFont");



            for (int i = 0; i < 20; i++) //this is not drawing -  this is just creating 20 clouds
            {
                _cloud = new Cloud(i * rng.Next(150, 250), rng.Next(-20, 100), cloudTexture, GameFont, 1, 500);
                SkyCloud.Add(_cloud);
            }



            _sunMoon = new SunMoon(rng.Next(0, 500), rng.Next(0, 75), SunTexture, GameFont); //making sun
            _sunMoon2 = new SunMoon(rng.Next(500, 900), rng.Next(0, 75), MoonTexture, GameFont); //making moon


            SkySunMoon.Add(_sunMoon); //adding sun to the list - SkySunMoon
            SkySunMoon.Add(_sunMoon2); //adding moon to the list - SkySunMoon

            SkyColor.Add(Color.SandyBrown); //adding sandy brown color to list SkyColor
            SkyColor.Add(Color.MidnightBlue); //adding midnightblue to the list SkyColor





            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            timer++;
            if (timer % 250 == 0) //add a new cloud to the list 
            {
                _cloud = new Cloud(-200, rng.Next(-100, 100), cloudTexture, GameFont, 1, 900);
                SkyCloud.Add(_cloud);
            }

            for (int i = 0; i < SkyCloud.Count; i++) //call cloud update method for each clouds in the list
            {
                SkyCloud[i].Update();
                if (SkyCloud[i].HasExpired()) //check the return value from cloud hasexpired method
                {
                    SkyCloud.RemoveAt(i); //if true, remove cloud from specific list index

                }

            }



            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {

            GraphicsDevice.Clear(SkyColor[0]); //drawing the sky color from the 0 index
            SkySunMoon[0].Draw(_spriteBatch); //this is drawing the sun from the 0 index of the SkySunMoon list

            if (Keyboard.GetState().IsKeyDown(Keys.Space) && !spacebarDown) //this is drawing the moon while also updating the list
            {

                spacebarDown = true;
                SkySunMoon.RemoveAt(0); //removing sun from 0 index and shifting moon to 0 index in the list
                SkyColor.RemoveAt(0); //removing sandybrown from 0 index and shifting midnight blue to that index

                SkySunMoon[0].Draw(_spriteBatch); //drawing 0 index from list SkySunMoon -  ie moon 
                GraphicsDevice.Clear(SkyColor[0]); //bg color from 0 index of the list SkyColor - ie midnight blue 

                SkySunMoon.Add(_sunMoon); //re-adding sun to the list
                SkySunMoon.Add(_sunMoon2);//re-adding moon to the list 

                SkyColor.Add(Color.SandyBrown); //readding sandybrwon to the list 
                SkyColor.Add(Color.MidnightBlue); // readding midnight blue to the list 


            }

            foreach (var cloud in SkyCloud) // this is drawing the 10 clouds
            {
                cloud.Draw(_spriteBatch);

            }

            if (Keyboard.GetState().IsKeyUp(Keys.Space))
            {
                spacebarDown = false;
            }

            _spriteBatch.Begin();
            _spriteBatch.Draw(GroundTexture, new Vector2(0, 200), Color.White); //this is drawing the ground

            _spriteBatch.End();


            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
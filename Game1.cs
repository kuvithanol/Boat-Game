using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace boatgame
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        public static Texture2D ball;
        public static Texture2D boat;

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            ball = this.Content.Load<Texture2D>("ball");
            boat = this.Content.Load<Texture2D>("boat");
            // TODO: use this.Content to load your game content here
        }

        private static List<GameObject> gameObjects = new List<GameObject>();

        internal static List<GameObject> iGameObjects { get => gameObjects; set => gameObjects = value; }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            if (Keyboard.GetState().IsKeyDown(Keys.N)) iGameObjects.Add(new boatClass(new Vector2(100, 100), 0));

            foreach(GameObject obj in iGameObjects)
            {
                obj.Update((float)gameTime.ElapsedGameTime.TotalMilliseconds/1000);
            }
            base.Update(gameTime);
        }


        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.SteelBlue);
            

            SpriteBatch batch = new SpriteBatch(GraphicsDevice);
            batch.Begin();

            foreach(GameObject obj in iGameObjects)
            {
                if (obj.texture != null)
                {
                    batch.Draw(obj.texture, obj.posCoord, null, Color.White, obj.posAngle, obj.texture.Bounds.Center.ToVector2(), new Vector2(1,1), SpriteEffects.None, 1);
                    //if(obj is boatclass boat)
                    //batch.DrawString(Spri, boat.momentum.ToString(), new Vector2(0, 0), Color.Red);             ^ this fucking sucks, add to customMath
                }
            }

            batch.End();
            base.Draw(gameTime);
        }
    }
}

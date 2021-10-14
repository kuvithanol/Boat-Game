using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Linq;

namespace boatgame
{
    public class MasterGame : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        public MasterGame()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            masterGame = this;
        }

        static MasterGame masterGame;

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();


            iGameObjects.Add(new Player(new Vector2(500, 50), MathHelper.Pi));
            iGameObjects.Add(new Boat(new Vector2(500, 50), MathHelper.Pi/2));

            Boat boat = (Boat)iGameObjects.Last();

            //shit does work wtf??? ^ ^ ^
        }

        public static Texture2D debugCircle;
        public static Texture2D boat;

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            debugCircle = this.Content.Load<Texture2D>("debugCircle");
            boat = this.Content.Load<Texture2D>("boat");
            // TODO: use this.Content to load your game content here
        }

        private static List<GameObject> gameObjects = new List<GameObject>();

        private static List<GameObject> slatedForDeletion = new List<GameObject>();

        private static List<GameObject> slatedForCreation = new List<GameObject>();

        internal static List<GameObject> iGameObjects { get => gameObjects; set => gameObjects = value; }
        internal static List<GameObject> iSlatedForDeletion { get => slatedForDeletion; set => slatedForDeletion = value; }
        internal static List<GameObject> iSlatedForCreation { get => slatedForCreation; set => slatedForCreation = value; }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            foreach (GameObject obj in iSlatedForCreation)
            {
                iGameObjects.Add(obj);
            }
            iSlatedForCreation.Clear();
            foreach (GameObject obj in iGameObjects)
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
                    batch.Draw(obj.texture, obj.positionalCoord, null, Color.White, obj.positionalAngle, obj.texture.Bounds.Center.ToVector2(), new Vector2(1,1), SpriteEffects.None, 1);
                    //if(obj is Boat boat)
                    //batch.DrawString(Spri, boat.momentum.ToString(), new Vector2(0, 0), Color.Red);     
                    if(obj is PhysicalGameObject physical)
                    {
                        foreach (Hitzone hitzone in physical.hitzones)
                        {
                            batch.Draw(debugCircle, hitzone.position, null, Color.White, obj.positionalAngle, debugCircle.Bounds.Center.ToVector2(), hitzone.radius/100, SpriteEffects.None, 0);
                        }
                    }
                }
            }

            batch.End();
            base.Draw(gameTime);
        }
    }
}

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GameProject
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Player player1;
        ColissionManager colissionmanager;
        Texture2D background;
        Rectangle mainFrame;
        private int GameWidth=768, GameHeight=432;

        private Block[] Floor = new Block[6];


        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferHeight = GameHeight;
            graphics.PreferredBackBufferWidth = GameWidth;
            graphics.ApplyChanges();
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();

        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            background = Content.Load<Texture2D>("background");
            mainFrame = new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height);
            Texture2D RunRight = Content.Load<Texture2D>("RunRight");
            Texture2D IdleRight = Content.Load<Texture2D>("IdleRight");
            Texture2D RunLeft = Content.Load<Texture2D>("RunLeft");
            Texture2D IdleLeft = Content.Load<Texture2D>("IdleLeft");
            Remote pad1 = new KeyBoard() { leftk = Keys.Q, rightk = Keys.D, jumpk = Keys.Space };
            Texture2D ground = Content.Load<Texture2D>("Floor");
            int x = 0;
            for (int i = 0; i < Floor.Length; i++)
            {
                Floor[i] = new Block(ground);
                Floor[i].Position = new Vector2(x, 383);
                x += 158;
            }

            player1 = new Player(new Vector2(200, 350), RunRight, RunLeft, IdleRight, IdleLeft, pad1);
            colissionmanager = new ColissionManager();
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            for (int i = 0; i < Floor.Length; i++)
            {
                Floor[i].Update(gameTime);
                if (colissionmanager.Update(player1, Floor[i]))
                    player1.hasJumped = false;
            }
            
            
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();


            player1.Update(gameTime);
            
            

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);
            

            // TODO: Add your drawing code here

            spriteBatch.Begin();

            spriteBatch.Draw(background,mainFrame,Color.White);

            player1.Draw(spriteBatch);
            for (int i = 0; i < Floor.Length; i++)
            {
                Floor[i].Draw(spriteBatch);
            }
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}

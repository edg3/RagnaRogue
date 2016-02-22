﻿using Microsoft.Xna.Framework;

namespace RagnaRogue
{
    public class RagnaRogueGame : Game
    {
        GraphicsDeviceManager graphics;

        public RagnaRogueGame() : base()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            var sadConsoleComponent = new SadConsole.EngineGameComponent(this, () =>
            {
                // Use the default square font
                using (var stream = System.IO.File.OpenRead("Fonts/Cheepicus12.font"))
                    SadConsole.Engine.DefaultFont = SadConsole.Serializer.Deserialize<SadConsole.Font>(stream);

                int width = 112;
                int height = 63;

                // Use the IBM console style font
                //using (var stream = System.IO.File.OpenRead("Fonts/IBM.font"))
                //    SadConsole.Engine.DefaultFont = SadConsole.Serializer.Deserialize<SadConsole.Font>(stream);

                //int width = 80;
                //int height = 30;

                SadConsole.Engine.DefaultFont.ResizeGraphicsDeviceManager(graphics, width, height, 0, 0);
                SadConsole.Engine.UseMouse = true;
                SadConsole.Engine.UseKeyboard = true;

                var sampleConsole = new SadConsole.Consoles.Console(width, height);

                sampleConsole.FillWithRandomGarbage(true);

                SadConsole.Engine.ConsoleRenderStack.Add(sampleConsole);
                SadConsole.Engine.ActiveConsole = sampleConsole;
            });

            Components.Add(sadConsoleComponent);
        }

        protected override void Initialize()
        {
            // Makes the mouse visible on top of the game. Does not affect the SadConsole mouse behavior.
            IsMouseVisible = true;

            base.Initialize();
        }

        protected override void LoadContent()
        {
            // LoadContent will be called once per game and is the place to load all of your content.
        }

        protected override void UnloadContent()
        {
            // UnloadContent will be called once per game and is the place to unload all content.
        }

        protected override void Update(GameTime gameTime)
        {
            // Allows the game to run logic such as updating the world,
            // checking for collisions, gathering input, and playing audio.
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            // This is called when the game should draw itself.
            GraphicsDevice.Clear(Color.Black);

            base.Draw(gameTime);
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace CognitiveCloud
{
	/// <summary>
	/// This is the main type for your game
	/// </summary>
	public class Game1 : Microsoft.Xna.Framework.Game
	{
		GraphicsDeviceManager graphics;
		SpriteBatch spriteBatch;

		float aspectRatio;
		Model myModel;
		Vector3 modelPosition = Vector3.Zero;
		float modelRotation = 0.0f;

		// Set the position of the camera in world space, for our view matrix.
		Vector3 cameraPosition = new Vector3(50.0f, 50.0f, 5000.0f);
		Vector3 center = new Vector3(10.0f, 10.0f, 0.0f);
		int width = 10;
		int height = 10;
		private short[] triangleListIndices;
		private VertexPositionColor[] pointList;
		private int points=20;

		public Game1()
		{
			graphics = new GraphicsDeviceManager(this);
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
			//myModel = 

			aspectRatio = graphics.GraphicsDevice.Viewport.AspectRatio;

			triangleListIndices = new short[(width - 1) * (height - 1) * 6];
			 width = 10;
			 height = 10;

			for (int x = 0; x < width - 1; x++)
			{
				for (int y = 0; y < height - 1; y++)
				{
					triangleListIndices[(x + y * (width - 1)) * 6] = (short)(2 * x);
					triangleListIndices[(x + y * (width - 1)) * 6 + 1] = (short)(2 * x + 1);
					triangleListIndices[(x + y * (width - 1)) * 6 + 2] = (short)(2 * x + 2);

					triangleListIndices[(x + y * (width - 1)) * 6 + 3] = (short)(2 * x + 2);
					triangleListIndices[(x + y * (width - 1)) * 6 + 4] = (short)(2 * x + 1);
					triangleListIndices[(x + y * (width - 1)) * 6 + 5] = (short)(2 * x + 3);
				}
			}

			pointList = new VertexPositionColor[points];

			for (int x = 0; x < points / 2; x++)
			{
				for (int y = 0; y < 2; y++)
				{
					pointList[(x * 2) + y] = new VertexPositionColor(
						new Vector3(x * 100, y * 100, 0), Color.White);
				}
			}
		}

		/// <summary>
		/// UnloadContent will be called once per game and is the place to unload
		/// all content.
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
			// Allows the game to exit
			// Allows the game to exit
			var kbState = Keyboard.GetState();
			if (kbState.IsKeyDown(Keys.Escape) || kbState.IsKeyDown(Keys.Q))
				this.Exit();


			// TODO: Add your update logic here

			base.Update(gameTime);
		}

		/// <summary>
		/// This is called when the game should draw itself.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		protected override void Draw(GameTime gameTime)
		{
			GraphicsDevice.Clear(Color.CornflowerBlue);

			var device = graphics.GraphicsDevice;
			//Sphere sp = new Sphere(3, GraphicsDevice);
			// Copy any parent transforms.
			//Matrix[] transforms = new Matrix[myModel.Bones.Count];
			//myModel.CopyAbsoluteBoneTransformsTo(transforms);

			//var cam = new Camera();
			//graphics.GraphicsDevice.DrawUserPrimitives(PrimitiveType.LineStrip, ;
			//sp.Draw(cam);
			BoundingSphereRenderer.InitializeGraphics(device, 100);
			var look=Matrix.CreateLookAt(cameraPosition, Vector3.Zero, Vector3.Up);
			var projection=Matrix.CreatePerspectiveFieldOfView(
                MathHelper.ToRadians(45.0f), aspectRatio, 
                1.0f, 10000.0f);
			BoundingSphereRenderer.Render(new BoundingSphere(center, 2), device, look, projection, Color.Red, Color.Blue, Color.Green);

			// TODO: Add your drawing code here

			base.Draw(gameTime);
		}
	}
}

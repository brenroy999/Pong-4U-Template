﻿/*
 * Description:     A basic PONG simulator
 * Author:   Brendon Roy
 * Date:	February 8th, 2019
 */

#region libraries

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Media;

#endregion

namespace Pong
{
	public partial class Form1 : Form
	{
		#region global values

		//random
		Random randGen = new Random();

		//graphics objects for drawing
		SolidBrush drawBrush = new SolidBrush(Color.White);
		Font drawFont = new Font("Courier New", 10);

		// Sounds for game
		SoundPlayer scoreSound = new SoundPlayer(Properties.Resources.score);
		SoundPlayer collisionSound = new SoundPlayer(Properties.Resources.collision);
		SoundPlayer powerSound = new SoundPlayer(Properties.Resources.power_shot);
		SoundPlayer chargeSound = new SoundPlayer(Properties.Resources.fullcharge);

		//determines whether a key is being pressed or not
		Boolean aKeyDown, zKeyDown, jKeyDown, mKeyDown, kKeyDown, sKeyDown;

		// check to see if a new game can be started
		Boolean newGameOk = true;

		//ball directions, speed, and rectangle
		Boolean ballMoveRight = true;
		Boolean ballMoveDown = true;
		int BALL_SPEED = 4;
		Rectangle ball;

		//paddle speeds and rectangles
		const int PADDLE_SPEED = 4;
		Rectangle p1, p2;

		//player and game scores
		int player1Score = 0;
		int player2Score = 0;
		int gameWinScore = 2;  // number of points needed to win game

		//power strikes
		Boolean p1Power = false;
		Boolean p2Power = false;
		int p1Charge = 0;
		int p2Charge = 0;

		#endregion


		public Form1()
		{
			InitializeComponent();
		}

		// -- YOU DO NOT NEED TO MAKE CHANGES TO THIS METHOD
		private void Form1_KeyDown(object sender, KeyEventArgs e)
		{
			//check to see if a key is pressed and set is KeyDown value to true if it has
			switch (e.KeyCode)
			{
				case Keys.A:
					aKeyDown = true;
					break;
				case Keys.Z:
					zKeyDown = true;
					break;
				case Keys.J:
					jKeyDown = true;
					break;
				case Keys.K:
					kKeyDown = true;
					break;
				case Keys.M:
					mKeyDown = true;
					break;
				case Keys.S:
					sKeyDown = true;
					break;
				case Keys.Y:
				case Keys.Space:
					if (newGameOk)
					{
						SetParameters();
					}
					break;
				case Keys.N:
					if (newGameOk)
					{
						Close();
					}
					break;
			}
		}

		// -- YOU DO NOT NEED TO MAKE CHANGES TO THIS METHOD
		private void Form1_KeyUp(object sender, KeyEventArgs e)
		{
			//check to see if a key has been released and set its KeyDown value to false if it has
			switch (e.KeyCode)
			{
				case Keys.A:
					aKeyDown = false;
					break;
				case Keys.Z:
					zKeyDown = false;
					break;
				case Keys.J:
					jKeyDown = false;
					break;
				case Keys.M:
					mKeyDown = false;
					break;
			}
		}

		/// <summary>
		/// sets the ball and paddle positions for game start
		/// </summary>

		private void SetParameters()
		{
			if (newGameOk)
			{
				player1Score = player2Score = 0;
				newGameOk = false;
				startLabel.Visible = false;
				//				scoreLabel.Visible = true;
				gameUpdateLoop.Start();
				p1Bar.Visible = true;
				p2Bar.Visible = true;
				p1Charge = 0;
				p2Charge = 0;
				p1Bar.Value = p1Charge;
				p2Bar.Value = p2Charge;
			}

			//set starting position for paddles on new game and point scored 
			const int PADDLE_EDGE = 20;  // buffer distance between screen edge and paddle            

			p1.Width = p2.Width = 10;    //height for both paddles set the same
			p1.Height = p2.Height = 40;  //width for both paddles set the same

			//p1 starting position
			p1.X = PADDLE_EDGE;
			p1.Y = this.Height / 2 - p1.Height / 2;

			//p2 starting position
			p2.X = this.Width - PADDLE_EDGE - p2.Width;
			p2.Y = this.Height / 2 - p2.Height / 2;

			// TODO set Width and Height of ball
			ball.Width = 13;
			ball.Height = 13;

			// TODO set starting X position for ball to middle of screen, (use this.Width and ball.Width)
			ball.X = (this.Width / 2) - (ball.Width / 2);

			// TODO set starting Y position for ball to middle of screen, (use this.Height and ball.Height)

			ball.Y = (this.Height / 2) - (ball.Height / 2); ;


		}

		/// <summary>
		/// This method is the game engine loop that updates the position of all elements
		/// and checks for collisions.
		/// </summary>
		private void gameUpdateLoop_Tick(object sender, EventArgs e)
		{
			#region update ball position

			// TODO create code to move ball either left or right based on ballMoveRight and using BALL_SPEED
			if (ballMoveRight == true)
			{
				ball.X += 1 * BALL_SPEED;
			}
			else
			{
				ball.X -= 1 * BALL_SPEED;
			}

			// TODO create code move ball either down or up based on ballMoveDown and using BALL_SPEED
			if (ballMoveDown == false)
			{
				ball.Y -= 1 * BALL_SPEED;
			}
			else
			{
				ball.Y += 1 * BALL_SPEED;
			}

			#endregion

			#region update paddle positions

			if (aKeyDown == true && p1.Y > 0)
			{
				// TODO create code to move player 1 paddle up using p1.Y and PADDLE_SPEED
				p1.Y -= 1 * PADDLE_SPEED;
			}

			if (zKeyDown == true && p1.Y < (this.Height - p1.Height))
			{
				// TODO create an if statement and code to move player 1 paddle down using p1.Y and PADDLE_SPEED
				p1.Y += 1 * PADDLE_SPEED;
			}

			if (jKeyDown == true && p2.Y > 0)
			{
				// TODO create an if statement and code to move player 2 paddle up using p2.Y and PADDLE_SPEED
				p2.Y -= 1 * PADDLE_SPEED;
			}

			if (mKeyDown == true && p2.Y < (this.Height - p2.Height))
			{
				// TODO create an if statement and code to move player 2 paddle down using p2.Y and PADDLE_SPEED
				p2.Y += 1 * PADDLE_SPEED;
			}
			#endregion

			#region ball collision with top and bottom lines

			if (ball.Y < 0) // if ball hits top line
			{
				// TODO use ballMoveDown boolean to change direction
				ballMoveDown = true;
				// TODO play a collision sound
				collisionSound.Play();
			}
			else if (ball.Y > (this.Height - ball.Height))
			{
				// TODO In an else if statement use ball.Y, this.Height, and ball.Width to check for collision with bottom line
				ballMoveDown = false;
				// If true use ballMoveDown down boolean to change direction
				collisionSound.Play();
			}

			#endregion

			#region power strike functions
			if (p1Charge >= 100 && sKeyDown == true && ball.IntersectsWith(p1))
			{
				p1Power = true;
			}
			if (p2Charge >= 100 && kKeyDown == true && ball.IntersectsWith(p2))
			{
				p2Power = true;
			}

			if (p1Power || p2Power)
			{
				BALL_SPEED = 7;
			}
			else
			{
				if (BALL_SPEED > 4)
				{
					BALL_SPEED--;
				}
			}

			#endregion

			#region ball collision with paddles

			// TODO create if statment that checks p1 collides with ball and if it does
			// --- play a "paddle hit" sound and
			// --- use ballMoveRight boolean to change direction

			if (ball.IntersectsWith(p1))
			{
				p1Charge += 10;
				try
				{
					p1Bar.Value = p1Charge;
				}
				catch
				{
					p1Charge = 100;
					chargeSound.PlayLooping();
				}
				ballMoveRight = true;
				collisionSound.Play();

				if (p2Power == true)
				{
					kKeyDown = false;
					p2Power = false;
					p2Charge = 0;
					p2Bar.Value = 0;
				}
			}

			// TODO create if statment that checks p2 collides with ball and if it does
			// --- play a "paddle hit" sound and
			// --- use ballMoveRight boolean to change direction

			if (ball.IntersectsWith(p2))
			{
				p2Charge += 10;
				try
				{
					p2Bar.Value = p2Charge;
				}
				catch
				{
					p2Charge = 100;
					chargeSound.PlayLooping();
				}
				ballMoveRight = false;
				collisionSound.Play();

				if (p1Power == true)
				{
					powerSound.Play();
					sKeyDown = false;
					p1Power = false;
					p1Charge = 0;
					p1Bar.Value = p1Charge;
				}
			}

			if (p1Power == true && p1.IntersectsWith(ball) || p2Power == true && p2.IntersectsWith(ball))
			{
				powerSound.PlayLooping();
			}

			/*  ENRICHMENT
             *  Instead of using two if statments as noted above see if you can create one
             *  if statement with multiple conditions to play a sound and change direction
             */

			#endregion

			#region ball collision with side walls (point scored)

			if (ball.X < 0 - ball.Width)  // ball hits left wall logic
			{
				// TODO
				// --- play score sound
				scoreSound.Play();
				// --- update player 2 score
				player2Score += 1;
				if (player2Score == gameWinScore)
				{
					// TODO use if statement to check to see if player 2 has won the game. If true run 
					// GameOver method. Else change direction of ball and call SetParameters method.
					GameOver("Player 2");
				}
				else
				{
					ballMoveRight = false;
					if (p2Power == true)
					{
						p2Power = false;
						p2Charge = 0;
						p2Bar.Value = 0;
						kKeyDown = false;
					}
					SetParameters();
				}
			}

			// TODO same as above but this time check for collision with the right wall

			if (ball.X > this.Width)
			{
				scoreSound.Play();
				player1Score += 1;
				if (player1Score == gameWinScore)
				{
					GameOver("Player 1");
				}
				else
				{
					ballMoveRight = true;
					if (p1Power == true)
					{
						p1Power = false;
						p1Charge = 0;
						p1Bar.Value = p1Charge;
						sKeyDown = false;
					}
					SetParameters();
				}
			}

			#endregion

			//refresh the screen, which causes the Form1_Paint method to run
			this.Refresh();
		}

		/// <summary>
		/// Displays a message for the winner when the game is over and allows the user to either select
		/// to play again or end the program
		/// </summary>
		/// <param name="winner">The player name to be shown as the winner</param>
		private void GameOver(string winner)
		{
			newGameOk = true;

			// TODO create game over logic
			// --- stop the gameUpdateLoop
			gameUpdateLoop.Stop();
			p1Bar.Visible = false;
			p2Bar.Visible = false;
			p1Power = false;
			p2Power = false;
			// --- show a message on the startLabel to indicate a winner, (need to Refresh).
			startLabel.Visible = true;
			startLabel.Text = winner + " is the Winner!";
			Refresh();
			// --- pause for two seconds 
			Thread.Sleep(2000);
			// --- use the startLabel to ask the user if they want to play again
			startLabel.Text = "Play Again?" + "\n[Press Space or Y Key]"
				+ "\n[Press N to Quit]";

		}

		private void Form1_Paint(object sender, PaintEventArgs e)
		{
			#region field graphics

			Pen drawPen = new Pen(Color.LightGray, 5);
			e.Graphics.DrawRectangle(drawPen, (this.Width / 8 * 3), (18), (this.Width / 8) * 2, (this.Height) - 36);
			e.Graphics.DrawRectangle(drawPen, (18), (18), ((this.Width) - 38), (this.Height) - 36);
			e.Graphics.DrawLine(drawPen, (this.Width / 2), 18, (this.Width / 2), this.Height - 18);

			e.Graphics.DrawLine(drawPen, 18, (this.Height / 2), (this.Width / 8 * 3), (this.Height / 2));
			e.Graphics.DrawLine(drawPen, (this.Width) - 18, (this.Height / 2), (this.Width / 8 * 5), (this.Height / 2));

			#endregion

			// TODO draw paddles using FillRectangle
			e.Graphics.FillRectangle(drawBrush, p1);
			e.Graphics.FillRectangle(drawBrush, p2);

			// TODO draw ball using FillRectangle
			{
			SolidBrush ballBrush = new SolidBrush(Color.FromArgb(255, 182, 255, 0));
			e.Graphics.FillEllipse(ballBrush, ball);
			}
			// TODO draw scores to the screen using DrawString

			e.Graphics.DrawString(player1Score + "", drawFont, drawBrush, (this.Width / 4), 34);
			e.Graphics.DrawString(player2Score + "", drawFont, drawBrush, (this.Width / 4) * 3, 34);
		}

	}
}

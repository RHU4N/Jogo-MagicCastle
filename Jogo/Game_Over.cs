/*
 * Created by SharpDevelop.
 * User: Hugo
 * Date: 30/09/2022
 * Time: 03:11
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Media;
namespace Jogo
{
	/// <summary>
	/// Description of Game_Over.
	/// </summary>
	public partial class Game_Over : Form
	{
		public Game_Over()
		{

			InitializeComponent();
			
				SoundPlayer gameOver = new SoundPlayer ("game_over.wav");
				gameOver.Play();
				
		}
		void Button1Click(object sender, EventArgs e)
		{
			Application.Restart();
			this.Close();
		}
	}
}

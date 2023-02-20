/*
 * Created by SharpDevelop.
 * User: Hugo
 * Date: 30/09/2022
 * Time: 02:50
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
	/// Description of Vitoria.
	/// </summary>
	public partial class Vitoria : Form
	{
		public Vitoria()
		{
	
			InitializeComponent();
			
			SoundPlayer ganhar = new SoundPlayer ("ganhou.wav");
			ganhar.Play();
		}
		void Button1Click(object sender, EventArgs e)
		{
			Application.Restart();
			this.Close();
		}
	}
}

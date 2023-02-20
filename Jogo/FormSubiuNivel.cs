/*
 * Created by SharpDevelop.
 * User: joilma
 * Date: 25/09/2022
 * Time: 16:47
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
	/// Description of FormSubiuNivel.
	/// </summary>
	public partial class FormSubiuNivel : Form
	{
		public FormSubiuNivel()
		{
			uppar.Play();
			InitializeComponent();
	
		}
		public int upp = 0;
			SoundPlayer uppar = new SoundPlayer ("uppar.wav");
		void Button2Click(object sender, EventArgs e)
		{
			upp = 2;
			uppar.Play();
			this.Close();
		}
		void Button1Click(object sender, EventArgs e)
		{
			upp = 1;
			uppar.Play();
			this.Close();
		}
		void Button3Click(object sender, EventArgs e)
		{
			upp = 3;
			uppar.Play();
			this.Close();
		} 
		void Button4Click(object sender, EventArgs e)
		{
			upp = 4;
			uppar.Play();
			this.Close();
		}
	
	}
	
}

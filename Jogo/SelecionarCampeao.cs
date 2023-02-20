/*
 * Created by SharpDevelop.
 * User: Hugo
 * Date: 29/09/2022
 * Time: 18:59
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
	/// Description of SelecionarCampeao.
	/// </summary>
	public partial class SelecionarCampeao : Form
	{
		public SelecionarCampeao()
		{
			
			InitializeComponent();
			
			button1.Image = Image.FromFile("mago.gif");
			button1.ImageAlign = ContentAlignment.MiddleRight;    
		}

		public int escolha = 0;
		SoundPlayer selecionar = new SoundPlayer ("Selecionar.wav");
		public void Button1Click(object sender, EventArgs e)
		{
			
			selecionar.Play();
			escolha = 1;
			this.Close();

		}
		public void Button2Click(object sender, EventArgs e)
		{
			selecionar.Play();
			escolha = 2;
			this.Close();
		}
	}
}

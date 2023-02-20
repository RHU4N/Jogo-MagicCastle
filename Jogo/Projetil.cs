/*
 * Created by SharpDevelop.
 * User: Hugo
 * Date: 19/08/2022
 * Time: 08:38
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Runtime.Remoting.Channels;
using System.Windows.Forms;
namespace Jogo
{
	/// <summary>
	/// Description of Projetil.
	/// </summary>
	public class Projetil : PictureBox
	{
		public Projetil(int leftDragao, int topDragao)
			
		{
			
			Load("projetil.png");
			SizeMode = PictureBoxSizeMode.StretchImage;
			BackColor = Color.Transparent;
			Width = 80;
			Height = 80;
			
			Left = leftDragao +100;
			Top = topDragao + 20;
			timerTiro.Tick += Movimentar;
			timerTiro.Interval = 100;
			timerTiro.Enabled = true;

			
		}

		public int dano;
		public  int speed = 90;
		public int fundoWitch;
		public Timer timerTiro = new Timer();
		
		public void Movimentar (object sender, EventArgs e)
		{
			Left+= speed;
			
			if(Left>fundoWitch-100)
			{
				Lista.RemoveItem(this);
				timerTiro.Enabled = false;
				Dispose();
			}
			else
				if (Colide.TesteColisao(this))
			{
				timerTiro.Enabled = false;
				Dispose();
			}
			
		}
	}
}

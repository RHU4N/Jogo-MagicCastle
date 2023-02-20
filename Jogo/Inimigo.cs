/*
 * Created by SharpDevelop.
 * User: Aluno
 * Date: 03/06/2022
 * Time: 09:13
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
	/// Description of Inimigo.
	/// </summary>
	public class Inimigo:Personagem
	{
		
		public Inimigo(int largura, int altura)
			
		{

			Load("mosquito.gif");
			
			SizeMode = PictureBoxSizeMode.StretchImage;
			BackColor = Color.Transparent;
			Width = 80;
			Height = 80;
			Top = rnd.Next(90, 380) - 50;
			Left = largura - rnd.Next(100,200);
			timerVilao.Interval = 100;
			timerVilao.Tick += movimentarVilao;
			timerVilao.Enabled = true;
			
		
		}
		public Heroi dragao;
		public int dano = 20;
		public int hp_vilao;
		public int speed_vilao;
		
		Random rnd = new Random();
		public Timer timerVilao = new Timer();
		
		public void movimentarVilao (object sender, EventArgs e)
		{
			
		
				Left -= speed;
				if (Left< 0)
					{
					Lista.RemoveItem(this);
					Dispose();
					timerVilao.Enabled = false;
				}
				
					if (Colide.TesteColisao(this))
						{
							Lista.RemoveItem(this);
							timerVilao.Enabled= false;
							Dispose();
						}
		}
												
	}
		
 } 



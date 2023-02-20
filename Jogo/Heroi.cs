/*
 * Created by SharpDevelop.
 * User: Aluno
 * Date: 03/06/2022
 * Time: 09:04
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Media;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace Jogo
{
	/// <summary>
	/// Description of Heroi.
	/// </summary>
	public class Heroi:Personagem
	{
		public Heroi()
		{
		
			SizeMode = PictureBoxSizeMode.StretchImage;
			BackColor = Color.Transparent;
			Width = 150;
			Height = 150;
			Left = 40;
		}
		Inimigo vilao;
		MainForm form;
		
			public string img = " ";
			public void TrocarHeroi()
		{
				var formSe = new SelecionarCampeao();
			if (!this.IsDisposed)
			{
				
			formSe.ShowDialog();
			switch (formSe.escolha)
			{
				case 1:
					img = "vermelho.gif";
					Load(img);
					break;
				case 2:
				img = "mago.gif";
				Load(img);
				break;
			}
			
			}
			formSe.Close();
		}
		public int hp = 200;
		int hpMax = 200;
		
		public int speed = 25;
		int speedMax = 25;
		
		public int shld = 30;
		int shldMax = 30;
		
		public int dano = 20;
		int danoMax = 20;
		
		public int xp = 0;
		public int lvl = 0;
		
		public string imgFundo = "fundo0.jpg";
		
		//Largura e Altura no Cenário
		public int larguraCen = 500, alturaCen = 500;
		
		public int contFundo = 0, contUp = 0;
		
	
		public void GanharXP()
		{		
			xp +=1;		
			if (xp>9)
			{
			contFundo ++;
			imgFundo= "fundo"+contFundo+".jpg";
					
				 int aux =  this.Left;
				this.Left = -1000;
				Lista.MataTudo();
				
				var frm = new FormSubiuNivel();
				frm.ShowDialog();
				lvl++;

				switch (frm.upp)
				{
					case 1:
						hpMax += 20;
						hp = hpMax;
						break;
					case 2:
						shldMax += 10;
						shld = shldMax;
						break;
					case 3:
						speedMax += 10;
						speed = speedMax;
						break;
					case 4:
						danoMax += 20;
						dano = danoMax;
						break;
				}
		 		Left = 0;
		 		
		 		if (contFundo == 3)
		 		{
		 		contFundo = 0;
		 		Lista.MataTudo();
		 		var vitoria = new Vitoria();
				vitoria.ShowDialog();
		 		}
		 		
			this.Left = aux;
			xp=0;
			SoundPlayer musicaJogo = new SoundPlayer ("musica.wav");
			musicaJogo.Play();

			}

		}
		
		public void LevouDano(int vilaodano)
		{
			//Quando o tiro atinge o escudo, ele tira um pouco dele e bloqueia um pouco da "dor"
			int danoRem = vilaodano - shld;
			shld -= vilaodano;
			if(shld <0) shld =0;
			if(danoRem<0) danoRem= 0;
			
			//atingiu o herói
			hp -= danoRem;
			if(hp<0) hp =0;
		}
		
		//MOVIMENTAÇÃO DO MAGO
		
		 public void cima ()
		 {
		 	Top -= speed;
			if (Top <=0)
			{

				Top = 0;	
				
			
			}
		}
		 
		 public void baixo ()
		 		{
		 	     Top += speed;
			if (Top > 250)
			{ 			
					Top = 250;
					 Left = 50;
				}
			}
		
	}
}
	
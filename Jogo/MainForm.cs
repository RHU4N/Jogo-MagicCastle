/*
 * Created by SharpDevelop.
 * User: Aluno
 * Date: 29/04/2022
 * Time: 08:44
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Drawing;
using System.Media;
using System.Windows.Forms;

namespace Jogo
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
	
		public MainForm()
		{
			
			
			musicaInicial.Play();
			InitializeComponent();
			
			label2.Visible = false;
			label3.Visible = false;
			
		}
		SoundPlayer musicaInicial = new SoundPlayer ("Inicial.wav");
		SoundPlayer musicaJogo = new SoundPlayer ("musica.wav");
		Random rnd = new Random();
		PictureBox fundo = new PictureBox();
		 Heroi mago = new Heroi();

		
		Timer timer_CriarInim = new Timer();
		Timer timer_Colisao = new Timer();
		
		Label lblHP = new Label();
		Label lblDEF = new Label();
		Label lblATK = new Label();
		Label lblLVL = new Label();
		Label lblInim = new Label();
		

		
		void Button1Click(object sender, EventArgs e)
		{
			var fv = new FormVideoIntro();
			fv.ShowDialog();
			
			label2.Visible =true;
			label3.Visible =true;
			
			label2.Parent = fundo;
			label3.Parent = fundo;
			label1.Visible = false;
			
			musicaInicial.Dispose();
			
			//Mudar Mago
			mago.TrocarHeroi();
		
			SoundPlayer iniciar = new SoundPlayer ("comecar.wav");
			iniciar.Play();
			
			musicaJogo.Play();
			
			button1.Visible = false;
			button1.Enabled = false;
			this.KeyPreview = true;
			
			
			
			//Dados
			string[] atributos = {"HP"+mago.hp, "DEF"+mago.shld,"ATK"+mago.dano,"LVL"+ mago.lvl};
			
			//Popular Label e Criar
			lblInim.Parent = fundo;
			lblInim.AutoSize = true;
			lblInim.Text = mago.xp.ToString();
			lblInim.Top = 34;
			lblInim.Left = 460;
			lblInim.BackColor = System.Drawing.Color.Transparent;
			lblInim.ForeColor = System.Drawing.Color.Yellow;
			lblInim.Font = new Font ("PixelGameFont", 28);
			
			
			Label[] lbl = {lblHP, lblDEF, lblATK, lblLVL};
			for(int i = 0; i <4; i++)
			{
				lbl[i].Parent = fundo;
				lbl[i].AutoSize = true;
				lbl[i].Text = atributos[i];
				lbl[i].Top = 400;
				lbl[i].Left = 120 +i*200;
				lbl[i].ForeColor = System.Drawing.Color.Snow;
				lbl[i].BackColor = System.Drawing.Color.Transparent;
				lbl[i].Font = new Font ("PixelGameFont", 20);
			}
			
			//Cenário
			fundo.Parent = this;
			fundo.Load(mago.imgFundo);
			fundo.Tag = "fundo0.png";
			fundo.SizeMode = PictureBoxSizeMode.StretchImage;
			fundo.Width = 1000;
			fundo.Height = 450;
			Colide.mago = mago;
			
	
			
			//Mago
			mago.Parent = fundo;
			mago.larguraCen = fundo.Width;
			mago.alturaCen = fundo.Height;
			mago.Disposed += MagoDispose;

			CriarInimigo();
			
			timer_CriarInim.Interval = 1;
			timer_CriarInim.Tick += Timer_GerarInimigo;
			
			timer_Colisao.Interval = 1;
			timer_Colisao.Tick  += Timer_Colisoes;
			
			ChaveTimer(true);
		
			
			
			
	
		}
		
		void MainFormKeyDown(object sender, KeyEventArgs e)
		{
			e.Handled = e.SuppressKeyPress = true;
			if(!mago.IsDisposed)
		{
				if(e.KeyCode == Keys.W) mago.cima();
				if(e.KeyCode == Keys.S) mago.baixo();
			
			if(e.KeyCode == Keys.Space)
			{
			if (Lista.listaTiro.Items.Count<4)
				{
		
				Atirar();
				}
			}
			if (mago.imgFundo != fundo.Tag.ToString())
			{
				fundo.Tag = mago.imgFundo;
				fundo.Load(mago.imgFundo);
				CriarInimigo();
			}
	
		}
		
	
	}

		public void CriarInimigo ()
		{
			Inimigo vilao = new Inimigo (fundo.Width, fundo.Height);
			vilao.Parent = fundo;
			Lista.AddItem(vilao);
			switch (mago.contFundo)
			{
				case 1:
					vilao.Load("olho.gif");
					vilao.dano = 40;
					break;
				case 2:
					vilao.Load ("capacete.png");
					vilao.dano  = 60;
					break;
			}
		}
	
		public void Atirar()
		{
			
			Projetil tiro = new Projetil(mago.Left, mago.Top);
			tiro.Parent = fundo;
			tiro.fundoWitch = fundo.Width;
			Lista.AddItem(tiro);
		}
		void ChaveTimer(bool ligaDesliga)
		{
			timer_Colisao.Enabled = ligaDesliga;
			timer_CriarInim.Enabled = ligaDesliga;
		}
		void  Timer_GerarInimigo(object sender, EventArgs e)
		{
			if (rnd.Next(0,300) <2) CriarInimigo();
			
			this.Text = "número de Inimigos na Tela:"+Lista.listaInimigos.Items.Count 
				+"E tiros"+Lista.listaTiro.Items.Count;
		}
		void Timer_Colisoes(object sender, EventArgs e)
		{
			AtualizarLabel();
		}
		void AtualizarLabel()
		{
						Label[] lbl = {lblHP, lblDEF, lblATK, lblLVL};
						
			string[] atributos = {"HP"+mago.hp, "DEF"+mago.shld,"ATK"+mago.dano,"LVL"+ mago.lvl};
			for (int i = 0; i<4; i++)
			{
				lbl[i].Text = atributos[i];
			}
			
			lblInim.Text = mago.xp.ToString();
		}
		void MagoDispose(object sender, EventArgs e)
		{
			var acabou = new Game_Over();
			acabou.ShowDialog();
			this.Close();
			if (mago.IsDisposed)
				for (int i=0; i<Lista.listaInimigos.Items.Count; i++)
			{
				Inimigo vilao = (Inimigo) Lista.listaInimigos.Items[i];
				vilao.Dispose();
			}
			
		}
		public void AcabaJogo ()
		{
			this.Close();
			Lista.MataTudo();
			fundo.Load ("vitoria.jpg");
			
		}
	}
}

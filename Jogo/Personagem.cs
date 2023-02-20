/*
 * Created by SharpDevelop.
 * User: Aluno
 * Date: 27/05/2022
 * Time: 08:16
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Jogo
{
	/// <summary>
	/// Description of Personagem.
	/// </summary>
	public class Personagem: PictureBox
	{
		public Personagem()
		{

		}
		 
			 public int hp = 200;
			 public int speed = 25;
			 public int ataque = 20;
			 public int defesa = 10;
			 public int exp = 0;
			 public int lvl = 1;

			 
	}
}

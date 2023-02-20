/*
 * Created by SharpDevelop.
 * User: Hugo
 * Date: 22/09/2022
 * Time: 18:11
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;
namespace Jogo
{
	/// <summary>
	/// Description of Lista.
	/// </summary>
	public static  class Lista
	{
		static Lista()
		{
		}
		public static ListBox listaInimigos = new ListBox();
		public static ListBox listaTiro = new ListBox();
		public static ListBox listaItem = new ListBox();
		
		public static void AddItem (Inimigo vilao)
		{
			listaInimigos.Items.Add(vilao);
		}
		public static void RemoveItem(Inimigo vilao)
		{
			listaInimigos.Items.Remove(vilao);
		}
		public static void RemoveItem (Projetil tiro)
		{
			listaTiro.Items.Remove(tiro);
		}
		public static void AddItem (Projetil tiro)
		{
			listaTiro.Items.Add(tiro);
		}
		public static void MataTudo()
		{
			for (int i = 0; i<listaInimigos.Items.Count; i++)
			{
				Inimigo vilao = (Inimigo) listaInimigos.Items[i];
				vilao.Dispose();
				RemoveItem(vilao);
				vilao.timerVilao.Enabled = false;
			}
		}
	}
}

/*
 * Created by SharpDevelop.
 * User: Hugo
 * Date: 22/09/2022
 * Time: 18:15
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Windows.Forms;

namespace Jogo
{
	/// <summary>
	/// Description of Colide.
	/// </summary>
	public static class Colide
	{
		static Colide()
		{
		}
		public static Heroi mago;
		
		public static bool TesteColisao (Inimigo vilao)
		{
			bool retorno = false;
			
			if (vilao.Bounds.IntersectsWith(mago.Bounds))
			{
				mago.LevouDano(vilao.dano);
				if (mago.hp<=0)
				    {
					Explode.DestroiIem(mago);
				    }
				retorno = true;
			}
			return retorno;
		}
		
		public static bool TesteColisao(Projetil tiro)
		{
			bool retorno = false;
			foreach( object ob in Lista.listaInimigos.Items)
			{
				var vilao = ob as Inimigo;
				if (vilao.Bounds.IntersectsWith(tiro.Bounds))
				{
					Lista.RemoveItem(tiro);
					Lista.RemoveItem(vilao);
					Explode.DestroiIem(vilao);
					vilao.timerVilao.Enabled = false;
					mago.GanharXP();
					retorno = true;
					break;
				}
			}
			return retorno;
		}
		

	}
}

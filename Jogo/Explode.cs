/*
 * Created by SharpDevelop.
 * User: Hugo
 * Date: 30/09/2022
 * Time: 09:17
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Media;
using System.Threading.Tasks;
namespace Jogo
{
	/// <summary>
	/// Description of Explode.
	/// </summary>
	public static class Explode
	{
		public async static void DestroiIem(Heroi ob)
		{
			ob.Load("explosion.gif");
			SoundPlayer explosao = new SoundPlayer ("explode.wav");
			explosao.Play();
			await Task.Delay(300);
			ob.Dispose();
			SoundPlayer musicaJogo = new SoundPlayer ("musica.wav");
			musicaJogo.Play();
			
			
		}
		public async static void DestroiIem(Inimigo ob)
		{
			ob.Load("explosion.gif");
			SoundPlayer explosao = new SoundPlayer ("explode.wav");
			explosao.Play();
			await Task.Delay(300);
			ob.Dispose();
			SoundPlayer musicaJogo = new SoundPlayer ("musica.wav");
			musicaJogo.Play();
			
		}
	}
}

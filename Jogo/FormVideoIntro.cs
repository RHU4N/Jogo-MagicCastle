/*
 * Created by SharpDevelop.
 * User: Hugo
 * Date: 30/09/2022
 * Time: 08:31
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Jogo
{
	/// <summary>
	/// Description of FormVideoIntro.
	/// </summary>
	public partial class FormVideoIntro : Form
	{
		public FormVideoIntro()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		void FormVideoIntroLoad(object sender, EventArgs e)
		{
			MessageBox.Show("Aqui a Historia Começa","Inicio",MessageBoxButtons.OK,MessageBoxIcon.Information);
			
			string html = "<html><head>";
			html += "<meta content='IE=EDGE' http-equiv='X-UA-Compatible'/>";
			html += "<center><iframe id='video' src='https://www.youtube.com/embed/{0}?autoplay=true' width='{1}' height='{2}' frameborder='0'allowfullscreen='true'></iframe><center>";
			html += "</body></html>";
			
			wbVideo.DocumentText = string.Format(html,"fNeQj601eQ8", wbVideo.Width -22,wbVideo.Height -22);
//			//https://youtu.be/fNeQj601eQ8
		}
		void Button1Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}

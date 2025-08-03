using Muzicka_skola.Entiteti;
using Muzicka_skola.Forme;
using NHibernate;
using NHibernate.Hql.Ast;
using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Muzicka_skola
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();
		}





		#region GlobalForm_Prikaz
		private void buttunPolaznici_Click(object sender, EventArgs e)
		{
			GlobalForm formaPolaznici = new GlobalForm(Tip.Polaznici);
			formaPolaznici.Show();
		}

		private void buttonNastavnici_Click(object sender, EventArgs e)
		{
			GlobalForm formaNastavnici = new GlobalForm(Tip.Nastavnici);
			formaNastavnici.Show();
		}

		private void buttonKursevi_Click(object sender, EventArgs e)
		{
			GlobalForm formaKursevi = new GlobalForm(Tip.Kursevi);
			formaKursevi.Show();
		}

		private void buttonIspiti_Click(object sender, EventArgs e)
		{
			GlobalForm formaIspiti = new GlobalForm(Tip.Ispiti);
			formaIspiti.Show();
		}
		#endregion
	}
}

using Muzicka_skola.Entiteti;
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
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
			this.Load += Form1_Load;
		}
		private void Form1_Load(object sender, EventArgs e)
		{
			try
			{
				using (ISession session = DataLayer.GetSession())
				{
					var podaci = session.Query<Osoba>().ToList();

					string show = $"Ukupno: {podaci.Count}\n\n";
					foreach (var podatak in podaci) {
						show += $"{podatak.Ime} {podatak.Prezime} {podatak.JMBG}\n";
					}
					MessageBox.Show(show);
				}
			}
			catch (Exception ex)
			{
				var error = ex.Message;
				Exception inner = ex.InnerException;
				while (inner != null)
				{
					error += "\nInner Exception: " + inner.Message;
					inner = inner.InnerException;
				}
				MessageBox.Show("Greška pri konekciji ili čitanju:\n" + error);
			}
		}
	}
}

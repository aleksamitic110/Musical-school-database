using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Muzicka_skola.Entiteti;

namespace Muzicka_skola.Forme.Kursevi
{
    public partial class DodajCas : Form
    {
        private GlobalForm _globalForm;
        private KursDTO Kurs;

        public DodajCas(GlobalForm globalForm, KursDTO kurs)
        {
            InitializeComponent();
            _globalForm = globalForm;
            Kurs = kurs;
            labelIdKursa.Text = Kurs.Id;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxIdCasa.Text))
            {
                MessageBox.Show("ID casa mora biti unet");
                return;
            }

            if (DTOManager.nadjiCas(textBoxIdCasa.Text) != null)
            {
                MessageBox.Show("ID casa vec postoji");
                return;
            }

            if (string.IsNullOrWhiteSpace(textBoxLekcija.Text))
            {
                MessageBox.Show("Ime lekcije mora biti uneta");
                return;
            }
            DateTime selectedDate = dateTimePicker1.Value.Date;   // date part
            string selectedTime = dateTimePicker1.Value.ToString("HH:mm");  // time as string

            var cas = new CasDTO(
                textBoxIdCasa.Text,   // or however you generate idCasa
                Kurs.Id,
                (string)comboBoxIdUcionice.SelectedValue,
                selectedDate,
                selectedTime,
                textBoxLekcija.Text
            );

            DTOManager.addCas(cas);
            Close();
        }

        private void DodajCas_Load(object sender, EventArgs e)
        {
            var ucionice = DTOManager.vratiSveUcionice(); // returns list of DTOs
            comboBoxIdUcionice.DataSource = ucionice;
            comboBoxIdUcionice.DisplayMember = "Id"; // what user sees
            comboBoxIdUcionice.ValueMember = "Id";      // actual value stored
        }
    }
}

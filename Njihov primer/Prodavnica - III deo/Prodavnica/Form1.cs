using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.Linq;
using Prodavnica.Entiteti;

namespace Prodavnica
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void cmdRead_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                //Ucitavaju se podaci o prodavnici za zadatim brojem
                Prodavnica.Entiteti.Prodavnica p = s.Load<Prodavnica.Entiteti.Prodavnica>(61);

                MessageBox.Show(p.Naziv);

                s.Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void cmdCreate_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();


                Entiteti.Prodavnica p = new Entiteti.Prodavnica();
           
                p.Naziv = "Emmi Shop VII";
                p.RadniDan = "08-20";
                p.Subota = "08-14";
                p.Nedelja = "Ne radi";

                s.Save(p);

                s.Flush();
                s.Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void cmdManytoOne_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                //Ucitavaju se podaci o prodavnici za zadatim brojem
                Odeljenje o = s.Load<Odeljenje>(5);

                MessageBox.Show(o.Tip);
                MessageBox.Show(o.PripadaProdavnici.Naziv);

                s.Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void cmdOneToMany_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                //Ucitavaju se podaci o prodavnici sa zadatim brojem
                Prodavnica.Entiteti.Prodavnica p = s.Load<Prodavnica.Entiteti.Prodavnica>(61);

                foreach (Odeljenje o in p.Odeljenja)
                {
                    MessageBox.Show(o.Tip + " " + o.Lokacija);
                }

                s.Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }


        private void cmdCreateOdeljenje_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Entiteti.Prodavnica p = new Entiteti.Prodavnica() {Naziv = "Emi Shop",
                                                                    RadniDan = "08-20",
                                                                    Subota = "08-14",
                                                                    Nedelja = "Ne radi"};

                OdeljenjeDo5 o = new OdeljenjeDo5() { Lokacija = "Niš", 
                                                BrojKasa = 1, InfoPult = "Da"};

                OdeljenjeDo5 o1 = new OdeljenjeDo5() { Lokacija = "Niš",
                                                BrojKasa = 1, InfoPult = "Da"};
                 


                s.Save(p);

                o.PripadaProdavnici = p;
                s.Save(o);

                o1.PripadaProdavnici = p;
                s.Save(o1);

                p.Odeljenja.Add(o);
                p.Odeljenja.Add(o1);

                s.Save(p);

            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void cmdManyToMany_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Radnik r1 = s.Load<Radnik>(81);

                foreach (Entiteti.Prodavnica p1 in r1.Prodavnice)
                {
                    MessageBox.Show(p1.Naziv);
                }
                 

                Entiteti.Prodavnica p2 = s.Load<Entiteti.Prodavnica>(61);

                foreach (Radnik r2 in p2.Radnici)
                {
                    MessageBox.Show(r2.Ime + " " + r2.Prezime);
                }

                s.Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void cmdCreateRadnik_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Entiteti.Prodavnica p = new Entiteti.Prodavnica()
                {
                    Naziv = "Emi Shop XXII",
                    RadniDan = "08-20",
                    Subota = "08-14",
                    Nedelja = "Ne radi"
                };

                Radnik r = new Radnik()
                {
                    Ime = "Petar",
                    SrednjeSlovo = 'P',
                    Prezime = "Perić",
                    Mbr = 3322222,
                    DatumRodjenja = new DateTime(1982, 11, 13),
                    StrucnaSpema = "VII-1",
                    //Sef = false
                };

                r.Prodavnice.Add(p);
                p.Radnici.Add(r);
                s.Save(p);

                s.Flush();
                s.Close();

                

            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }

        }

        private void cmdCreateRadiU_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Radnik r = s.Load<Radnik>(109);
                Entiteti.Prodavnica p = s.Load<Entiteti.Prodavnica>(105);

                RadiU ru = new RadiU();
                ru.Id.RadnikRadiU = r;
                ru.Id.RadiUProdavnica = p;
                ru.DatumOd = DateTime.Now;


                s.Save(ru);

                s.Flush();
                s.Close();



            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void cmdTPC_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

        
                IList<Proizvod> proizvodi = s.QueryOver<Proizvod>()
                                                .Where(p => p.BarKod == 13)
                                                .List<Proizvod>();

                Vojnik v = (Vojnik)proizvodi[0];
                
                s.Close();



            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void cmdCreateVojnik_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();


                Vojnik v = new Vojnik();


                v.Tip = "VOJNICI";
                v.Naziv = "Specijalac od olova";
                v.Proizvodjac = "Proizvodjac vojnika";

                v.NazivSerije = "Leto 2015";
                v.Baterije = "Da";
                v.Metal = "Da";
                v.Plastika = "Ne";

                s.Save(v);

                s.Close();

            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();


                IList<Odeljenje> odeljenja = s.QueryOver<Odeljenje>()
                                                .List<Odeljenje>();

                foreach (Odeljenje o in odeljenja)
                {
                    if (o.GetType() == typeof(OdeljenjeDo5))
                    {
                        OdeljenjeDo5 o5 = (OdeljenjeDo5)o;
                    }
                    else if (o.GetType() == typeof(OdeljenjeOd6Do15))
                    {
                        OdeljenjeOd6Do15 o615 = (OdeljenjeOd6Do15)o;
                    }
                    else
                    {
                        OdeljenjeOdrasli oo = (OdeljenjeOdrasli)o;
                    }
                }

                s.Close();



            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void cmdCreateSubclassOdeljenje_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Entiteti.Prodavnica p = s.Load<Entiteti.Prodavnica>(61);

                //kolona TIP automatski dobija vrednost DO5
                OdeljenjeDo5 o1 = new OdeljenjeDo5()
                {
                    Lokacija = "Niš",
                    BrojKasa = 1,
                    InfoPult = "Da",
                    PripadaProdavnici = p
                };

                s.Save(o1);

                s.Close();



            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void cmdGet_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Odeljenje o = s.Get<Odeljenje>(100);

                if (o != null)
                {
                    MessageBox.Show(o.PripadaProdavnici.Naziv);
                }
                else
                {
                    MessageBox.Show("Ne postoji odeljenje sa zadatim identifikatorom");
                }

              
                s.Close();

            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }

        }

        private void cmdRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Odeljenje o = s.Get<Odeljenje>(55);

                //obrada podataka o odeljenju

                s.Refresh(o);

                s.Close();

            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void cmdFind1_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                IQuery q = s.CreateQuery("from Odeljenje");

                IList<Odeljenje> odeljenja = q.List<Odeljenje>();

                foreach(Odeljenje o in odeljenja)
                {
                    MessageBox.Show(o.Lokacija);
                }

                s.Close();

            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void cmdQuery1_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                //Odeljenja koja nemaju info pult
                IQuery q = s.CreateQuery("from Odeljenje as o where o.InfoPult = 'Ne'");

                IList<Odeljenje> odeljenja = q.List<Odeljenje>();

                foreach (Odeljenje o in odeljenja)
                {
                    MessageBox.Show(o.Id + " " + o.Lokacija);
                }

                s.Close();

            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }

        }

        private void cmdQueryParameters_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                //Paramterizovani upit
                IQuery q = s.CreateQuery("from Odeljenje as o where o.InfoPult = ? and o.BrojKasa >= ?");
                q.SetParameter(0, "Ne");
                q.SetInt32(1, 1);

                IList<Odeljenje> odeljenja = q.List<Odeljenje>();

                foreach (Odeljenje o in odeljenja)
                {
                    MessageBox.Show(o.Id + " " + o.Lokacija);
                }

                s.Close();

            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void cmdQueryNamedParamters_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                //Paramterizovani upit
                IQuery q = s.CreateQuery("select o.PripadaProdavnici from Odeljenje as o "
                                        + " where o.InfoPult = :pult and o.BrojKasa >= :kase");
                q.SetString("pult", "Ne");
                q.SetInt32("kase", 1);

                IList<Entiteti.Prodavnica> prodavnice = q.List<Entiteti.Prodavnica>();

                foreach (Entiteti.Prodavnica p in prodavnice)
                {
                    MessageBox.Show(p.Naziv);
                }

                s.Close();

            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void cmdQueryNamedParameters1_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                //Paramterizovani upit
                IQuery q = s.CreateQuery("select o.PripadaProdavnici from Odeljenje as o "
                                        + " where o.InfoPult = :pult and o.BrojKasa >= :kase "
                                        + " and o.PripadaProdavnici.RadniDan = :radni_dan");
                q.SetString("pult", "Ne");
                q.SetInt32("kase", 1);
                q.SetString("radni_dan", "07-20");

                IList<Entiteti.Prodavnica> prodavnice = q.List<Entiteti.Prodavnica>();

                foreach (Entiteti.Prodavnica p in prodavnice)
                {
                    MessageBox.Show(p.Naziv);
                }

                s.Close();

            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void smdEnumerable_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                IQuery q = s.CreateQuery("from Odeljenje");

                IEnumerable<Odeljenje> odeljenja = q.Enumerable<Odeljenje>();

                foreach (Odeljenje o in odeljenja)
                {
                    if (o.InfoPult == "Ne")
                        break;
                }

                s.Close();

            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }

        }

        private void cmdScalar_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                IQuery q = s.CreateQuery("select sum(o.BrojKasa) from Odeljenje o ");

                //za slucaj da upit vraca samo jednu vrednost
                Int64 kase = q.UniqueResult<Int64>();

                MessageBox.Show(kase.ToString());

                s.Close();

            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void cmdUnique_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                IQuery q = s.CreateQuery("select o from Odeljenje o where o.Id = 55 ");

                //za slucaj da upit vraca samo jednu vrednost
                Odeljenje o = q.UniqueResult<Odeljenje>();

                MessageBox.Show(o.Lokacija);

                s.Close();

            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void cmdMultiple_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                IQuery q = s.CreateQuery("select o.Lokacija, sum(o.BrojKasa), count(o) from Odeljenje o "
                                        + " group by o.Lokacija ");

                //za slucaj da upit vraca visestruku vrednost
                IList<object[]> result = q.List<object[]>();

                foreach (object[] r in result)
                {
                    string tip = (string)r[0];
                    Int64 kase = (Int64)r[1];
                    long broj = (long)r[2];

                    MessageBox.Show(tip + " " + broj.ToString() + " " + kase.ToString());
                }

                s.Close();

            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }

        }

        private void cmdPaging_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                IQuery q = s.CreateQuery("from Odeljenje");
                q.SetFirstResult(10);
                q.SetMaxResults(10);

                IList<Odeljenje> odeljenja = q.List<Odeljenje>();

                foreach (Odeljenje o in odeljenja)
                {
                    MessageBox.Show(o.Id.ToString());
                }

                s.Close();

            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void cmdCriteria_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                ICriteria c = s.CreateCriteria<Odeljenje>();

                c.Add(Expression.Ge("BrojKasa", 1));
                c.Add(Expression.Eq("InfoPult", "Ne"));

                IList<Odeljenje> odeljenja = c.List<Odeljenje>();

                foreach(Odeljenje o in odeljenja)
                {
                    MessageBox.Show(o.Id.ToString());
                }

                s.Close();

            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void cmdSQL_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                ISQLQuery q = s.CreateSQLQuery("SELECT O.* FROM ODELJENJE O");
                q.AddEntity(typeof(Odeljenje));
                
                
                IList<Odeljenje> odeljenja = q.List<Odeljenje>();

                foreach (Odeljenje o in odeljenja)
                {
                    MessageBox.Show(o.Id.ToString());
                }

                s.Close();

            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void cmdQueryOver_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                IList<Odeljenje> odeljenja = s.QueryOver<Odeljenje>()
                                                .Where(x => x.BrojKasa >= 1)
                                                .Where(x => x.InfoPult == "Ne")
                                                .List<Odeljenje>();

                foreach (Odeljenje o in odeljenja)
                {
                    MessageBox.Show(o.Id.ToString());
                }

                s.Close();

            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void cmdUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Odeljenje o = s.Load<Odeljenje>(54);

                //originalna sesija se zatvara i raskida se veza izmedju objekta i sesije
                s.Close();

                //objekat se modifikuje potpuno nezavisno od sesije
                o.BrojKasa = 10;

                //otvara se nova sesija
                ISession s1 = DataLayer.GetSession();

                //poziva se Update i objekat se povezuje sa novom sesijom
                s1.Update(o);

                s1.Flush();
                s1.Close();

            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Odeljenje o = s.Load<Odeljenje>(53);

                //brise se objekat iz baze ali ne i instanca objekta u memroiji
                s.Delete(o);
                //s.Delete("from Odeljenje");

                s.Flush();
                s.Close();

            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void cmdTransaction_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Odeljenje o = s.Load<Odeljenje>(52);

                ITransaction t = s.BeginTransaction();

                s.Delete(o);

                //t.Commit();
                t.Rollback();

                s.Close();

            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void cmdLINQ_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                IList<Odeljenje> odeljenja = (from o in s.Query<Odeljenje>()
                                              where (o.BrojKasa >= 1 && o.InfoPult == "Ne")
                                              select o).ToList<Odeljenje>();

                foreach (Odeljenje o in odeljenja)
                {
                    MessageBox.Show(o.Id.ToString());
                }


                s.Close();

            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void cmdLINQ1_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<Proizvod> proizvodi = from p in s.Query<Proizvod>()
                                                  where (p.Tip == "LUTKE" || p.Tip == "DODACI ZA LUTKE")
                                                  orderby p.Tip, p.Naziv.Length
                                                  select p;

                foreach (Proizvod p in proizvodi)
                {
                    MessageBox.Show(p.Naziv);
                }
                
                s.Close();

            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }

        }

        private void cmdLINQ2_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<Proizvod> proizvodi = s.Query<Proizvod>()
                                                    .Where(p => (p.Tip == "LUTKE" || p.Tip == "DODACI ZA LUTKE"))
                                                    .OrderBy(p => p.Tip).ThenBy(p => p.Naziv.Length)
                                                    .Select(p => p);
                                                  
                foreach (Proizvod p in proizvodi)
                {
                    MessageBox.Show(p.Naziv);
                }


                s.Close();

            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void button_dtoexample1_Click(object sender, EventArgs e)
        {
            //OdeljenjaInformacije odInfoForm = new OdeljenjaInformacije(61);

           // odInfoForm.Show();
        }


    }
}

using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate.Linq;
using Prodavnica.Entiteti;
using System.Windows.Forms;

namespace Prodavnica
{
    
    public class DTOManager
    {
        #region Odeljenja

        #region OdeljenjaDo5
        public static void obrisiOdeljenje(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                OdeljenjeDo5 odeljenje = s.Load<OdeljenjeDo5>(id);

                s.Delete(odeljenje);
                s.Flush();



                s.Close();

            }
            catch (Exception ec)
            {
                //handle exceptions
            }


        }
        public static  OdeljenjeDo5Basic vratiOdeljenjaDo5(int id)
        {
            OdeljenjeDo5Basic o = new OdeljenjeDo5Basic();
            try
            {
                ISession s = DataLayer.GetSession();

                OdeljenjeDo5 odeljenje = s.Load<OdeljenjeDo5>(id);
               
                o.OdeljenjeId = odeljenje.Id;
                o.Lokacija = odeljenje.Lokacija;
                o.BrojKasa = odeljenje.BrojKasa;
                o.infoPult = odeljenje.InfoPult;

                

               
                s.Close();

            }
            catch (Exception ec)
            {
                //handle exceptions
            }

            return o;

        }
        public static List<OdeljenjeBasic> GetOdInfos(int prodavnicaId)
        {
            List<OdeljenjeBasic> odInfos = new List<OdeljenjeBasic>();
            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<Odeljenje> odeljenja = from o in s.Query<Odeljenje>()
                                                   where o.PripadaProdavnici.Id == prodavnicaId
                                                   select o;

                foreach (Odeljenje o in odeljenja)
                {
                    odInfos.Add(new OdeljenjeBasic(o.Id, o.Lokacija, o.PripadaProdavnici.Naziv, o.ProdajeSeProizvod.Count));
                }

                s.Close();

            }
            catch (Exception ec)
            {
                //handle exceptions
            }

            return odInfos;
        }
        public static List<OdeljenjeDo5Pregled> vratiOdeljenjaDo5Prodavnice(int prodavnicaId)
        {
            List<OdeljenjeDo5Pregled> odInfos = new List<OdeljenjeDo5Pregled>();
            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<OdeljenjeDo5> odeljenja = from o in s.Query<OdeljenjeDo5>()
                                                   where o.PripadaProdavnici.Id == prodavnicaId
                                                   select o;

                foreach (OdeljenjeDo5 o in odeljenja)
                {
                    odInfos.Add(new OdeljenjeDo5Pregled(o.Id, o.Lokacija, o.BrojKasa, o.InfoPult));
                }

                s.Close();

            }
            catch (Exception ec)
            {
                //handle exceptions
            }

            return odInfos;
        }
        public static void izmeniOdeljenjeDo5(OdeljenjeDo5Basic odeljenje)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Prodavnica.Entiteti.OdeljenjeDo5 o = s.Load<OdeljenjeDo5>(odeljenje.OdeljenjeId);

                o.Lokacija = odeljenje.Lokacija;
                o.BrojKasa = odeljenje.BrojKasa;
                o.InfoPult = odeljenje.infoPult;
               


                s.SaveOrUpdate(o);

                s.Flush();

                s.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }
        }

    
        public static void sacuvajOdeljenjeDo5(OdeljenjeDo5Basic odeljenje)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Prodavnica.Entiteti.OdeljenjeDo5 o = new Prodavnica.Entiteti.OdeljenjeDo5();

                o.Lokacija = odeljenje.Lokacija;
                o.BrojKasa = odeljenje.BrojKasa;
                o.InfoPult = odeljenje.infoPult;
                Prodavnica.Entiteti.Prodavnica p = s.Load<Prodavnica.Entiteti.Prodavnica>(odeljenje.Prodavnica.Id);
                o.PripadaProdavnici = p;
               

                s.Save(o);

                s.Flush();

                s.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }
        }
        #endregion

        #region OdeljenjaOd6Do15
        public static void obrisiOdeljenjeOd6Do15(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                OdeljenjeOd6Do15 odeljenje = s.Load<OdeljenjeOd6Do15>(id);

                s.Delete(odeljenje);
                s.Flush();



                s.Close();

            }
            catch (Exception ec)
            {
                //handle exceptions
            }


        }
        public static OdeljenjeOd6Do15Basic vratiOdeljenjaOd6Do15(int id)
        {
            OdeljenjeOd6Do15Basic o = new OdeljenjeOd6Do15Basic();
            try
            {
                ISession s = DataLayer.GetSession();

                OdeljenjeOd6Do15 odeljenje = s.Load<OdeljenjeOd6Do15>(id);

                o.OdeljenjeId = odeljenje.Id;
                o.Lokacija = odeljenje.Lokacija;
                o.BrojKasa = odeljenje.BrojKasa;
                o.infoPult = odeljenje.InfoPult;




                s.Close();

            }
            catch (Exception ec)
            {
                //handle exceptions
            }

            return o;

        }
        
        public static List<OdeljenjeOd6Do15Pregled> vratiOdeljenjaOd6Do15Prodavnice(int prodavnicaId)
        {
            List<OdeljenjeOd6Do15Pregled> odInfos = new List<OdeljenjeOd6Do15Pregled>();
            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<OdeljenjeOd6Do15> odeljenja = from o in s.Query<OdeljenjeOd6Do15>()
                                                      where o.PripadaProdavnici.Id == prodavnicaId
                                                      select o;

                foreach (OdeljenjeOd6Do15 o in odeljenja)
                {
                    odInfos.Add(new OdeljenjeOd6Do15Pregled(o.Id, o.Lokacija, o.BrojKasa, o.InfoPult));
                }

                s.Close();

            }
            catch (Exception ec)
            {
                //handle exceptions
            }

            return odInfos;
        }
        public static void izmeniOdeljenjeOd6Do15(OdeljenjeOd6Do15Basic odeljenje)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Prodavnica.Entiteti.OdeljenjeOd6Do15 o = s.Load<OdeljenjeOd6Do15>(odeljenje.OdeljenjeId);

                o.Lokacija = odeljenje.Lokacija;
                o.BrojKasa = odeljenje.BrojKasa;
                o.InfoPult = odeljenje.infoPult;



                s.SaveOrUpdate(o);

                s.Flush();

                s.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }
        }


        public static void sacuvajOdeljenjeOd6Do15(OdeljenjeOd6Do15Basic odeljenje)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Prodavnica.Entiteti.OdeljenjeOd6Do15 o = new Prodavnica.Entiteti.OdeljenjeOd6Do15();
              
                o.Lokacija = odeljenje.Lokacija;
                o.BrojKasa = odeljenje.BrojKasa;
                o.InfoPult = odeljenje.infoPult;
                Prodavnica.Entiteti.Prodavnica p = s.Load<Prodavnica.Entiteti.Prodavnica>(odeljenje.Prodavnica.Id);
                o.PripadaProdavnici = p;


                s.SaveOrUpdate(o);

                s.Flush();

                s.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }
        }
        #endregion

        #region OdeljenjeZaOdrasle
        public static void obrisiOdeljenjeZaOdrsla(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                OdeljenjeOdrasli odeljenje = s.Load<OdeljenjeOdrasli>(id);

                s.Delete(odeljenje);
                s.Flush();



                s.Close();

            }
            catch (Exception ec)
            {
                //handle exceptions
            }


        }
        public static OdeljenjeOdrasliBasic vratiOdeljenjaOdrasli(int id)
        {
            OdeljenjeOdrasliBasic o = new OdeljenjeOdrasliBasic();
            try
            {
                ISession s = DataLayer.GetSession();

                OdeljenjeOdrasli odeljenje = s.Load<OdeljenjeOdrasli>(id);

                o.OdeljenjeId = odeljenje.Id;
                o.Lokacija = odeljenje.Lokacija;
                o.BrojKasa = odeljenje.BrojKasa;
                o.infoPult = odeljenje.InfoPult;




                s.Close();

            }
            catch (Exception ec)
            {
                //handle exceptions
            }

            return o;

        }

        public static List<OdeljenjeOdrasliPregled> vratiOdeljenjaOdrasliProdavnice(int prodavnicaId)
        {
            List<OdeljenjeOdrasliPregled> odInfos = new List<OdeljenjeOdrasliPregled>();
            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<OdeljenjeOdrasli> odeljenja = from o in s.Query<OdeljenjeOdrasli>()
                                                          where o.PripadaProdavnici.Id == prodavnicaId
                                                          select o;

                foreach (OdeljenjeOdrasli o in odeljenja)
                {
                    odInfos.Add(new OdeljenjeOdrasliPregled(o.Id, o.Lokacija, o.BrojKasa, o.InfoPult));
                }

                s.Close();

            }
            catch (Exception ec)
            {
                //handle exceptions
            }

            return odInfos;
        }
        public static void izmeniOdeljenjeOdrasli(OdeljenjeOdrasliBasic odeljenje)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Prodavnica.Entiteti.OdeljenjeOdrasli o = s.Load<OdeljenjeOdrasli>(odeljenje.OdeljenjeId);

                o.Lokacija = odeljenje.Lokacija;
                o.BrojKasa = odeljenje.BrojKasa;
                o.InfoPult = odeljenje.infoPult;



                s.SaveOrUpdate(o);

                s.Flush();

                s.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }
        }


        public static void sacuvajOdeljenjeOdrasli(OdeljenjeOdrasliBasic odeljenje)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Prodavnica.Entiteti.OdeljenjeOdrasli o = new Prodavnica.Entiteti.OdeljenjeOdrasli();

                o.Lokacija = odeljenje.Lokacija;
                o.BrojKasa = odeljenje.BrojKasa;
                o.InfoPult = odeljenje.infoPult;
                Prodavnica.Entiteti.Prodavnica p = s.Load<Prodavnica.Entiteti.Prodavnica>(odeljenje.Prodavnica.Id);
                o.PripadaProdavnici = p;


                s.Save(o);

                s.Flush();

                s.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }
        }

        #endregion

        #endregion

        #region Prodavnica
        public static List<ProdavnicaPregled> vratiSveProdavnice()
        {
            List<ProdavnicaPregled> prodavnice = new List<ProdavnicaPregled>();
            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<Prodavnica.Entiteti.Prodavnica> sveProdavnice = from o in s.Query<Prodavnica.Entiteti.Prodavnica>()
                                                               select o;

                foreach (Prodavnica.Entiteti.Prodavnica p in sveProdavnice)
                {
                    prodavnice.Add(new ProdavnicaPregled(p.Id, p.Naziv, p.Adresa, p.BrojTelefona, p.RadniDan, p.Subota, p.Nedelja));
                }

                s.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }

            return prodavnice;
        }

        public static void dodajProdavnicu(ProdavnicaBasic p)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Prodavnica.Entiteti.Prodavnica o = new Prodavnica.Entiteti.Prodavnica();

                o.Naziv = p.Naziv;
                o.Adresa = p.Adresa;
                o.BrojTelefona = p.BrojTelefona;
                o.RadniDan = p.RadniDan;
                o.Subota = p.Subota;
                o.Nedelja = p.Nedelja;

                s.SaveOrUpdate(o);

                s.Flush();

                s.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }
        }

        public static ProdavnicaBasic azurirajProdavnicu(ProdavnicaBasic p)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Prodavnica.Entiteti.Prodavnica o = s.Load<Prodavnica.Entiteti.Prodavnica>(p.Id);
                o.Naziv = p.Naziv;
                o.Adresa = p.Adresa;
                o.BrojTelefona = p.BrojTelefona;
                o.RadniDan = p.RadniDan;
                o.Subota = p.Subota;
                o.Nedelja = p.Nedelja; 

                s.Update(o);
                s.Flush();

                s.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }

            return p;
        }

        public static ProdavnicaBasic vratiProdavnicu(int id)
        {
            ProdavnicaBasic pb = new ProdavnicaBasic();
            try
            {
                ISession s = DataLayer.GetSession();

                Prodavnica.Entiteti.Prodavnica o = s.Load<Prodavnica.Entiteti.Prodavnica>(id);
                pb = new ProdavnicaBasic(o.Id, o.Naziv, o.Adresa, o.BrojTelefona, o.RadniDan, o.Subota, o.Nedelja);

                s.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }

            return pb;
        }

        public static void obrisiProdavnicu(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Prodavnica.Entiteti.Prodavnica o = s.Load<Prodavnica.Entiteti.Prodavnica>(id);

                s.Delete(o);
                s.Flush();

                s.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }
        }
        #endregion
     
        #region Radnici

        public static void dodajRadniOdnos(RadiUBasic radi)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                RadiU r = new RadiU();
                r.Id = new RadiUId();
                r.Id.RadiUProdavnica = s.Load<Prodavnica.Entiteti.Prodavnica>(radi.Id.RadiUProdavnica.Id);
                r.Id.RadnikRadiU = s.Load<Radnik>(radi.Id.RadnikRadiU.Jbr);
                r.DatumOd = radi.DatumOd;
                r.DatumDo = radi.DatumDo;

                s.SaveOrUpdate(r);
                s.Flush();
                s.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }

        }
        public static List<RadnikBasic> vratiSveRadnike()
        {
            List<RadnikBasic> radnici = new List<RadnikBasic>();
            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<Prodavnica.Entiteti.Radnik> sviRadnici = from o in s.Query<Prodavnica.Entiteti.Radnik>()
                                                                    select o;

                foreach (Prodavnica.Entiteti.Radnik r in sviRadnici)
                {
                    radnici.Add(new RadnikBasic(r.Jbr, r.Mbr, r.Ime,
                        r.SrednjeSlovo, r.Prezime, r.DatumRodjenja,
                        r.StrucnaSpema, r.Sef));
                }

                s.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }

            return radnici;
        }
        public static List<RadnikPregled> vratiSveRadnikeProdavnice(int id)
        {
            List<RadnikPregled> radnici = new List<RadnikPregled>();
            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<Prodavnica.Entiteti.RadiU> sviRadnici = from o in s.Query<Prodavnica.Entiteti.RadiU>()
                                                                     where o.Id.RadiUProdavnica.Id==id
                                                                    select o;

                foreach (Prodavnica.Entiteti.RadiU r in sviRadnici)
                {
                    radnici.Add(new RadnikPregled(r.Id.RadnikRadiU.Jbr, r.Id.RadnikRadiU.Mbr, r.Id.RadnikRadiU.Ime,
                        r.Id.RadnikRadiU.SrednjeSlovo, r.Id.RadnikRadiU.Prezime, r.Id.RadnikRadiU.DatumRodjenja,
                        r.Id.RadnikRadiU.StrucnaSpema, r.Id.RadnikRadiU.Sef));
                }

                s.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }

            return radnici;
        }

        public static void dodajRadnika(RadnikBasic r)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Prodavnica.Entiteti.Radnik o = new Prodavnica.Entiteti.Radnik();
                o.Mbr = r.Mbr;
                o.Ime = r.Ime;
                o.SrednjeSlovo = r.SrednjeSlovo;
                o.Prezime = r.Prezime;
                o.DatumRodjenja = r.DatumRodjenja;
                o.StrucnaSpema = r.StrucnaSpema;
                
                
                s.SaveOrUpdate(o);

                

                s.Flush();

                s.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }
        }

        public static RadnikBasic azurirajRadnika(RadnikBasic r)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Prodavnica.Entiteti.Radnik o = s.Load<Prodavnica.Entiteti.Radnik>(r.Jbr);
               
                o.Ime = r.Ime;
                o.SrednjeSlovo = r.SrednjeSlovo;
                o.Prezime = r.Prezime;
                o.DatumRodjenja = r.DatumRodjenja;
                o.StrucnaSpema = r.StrucnaSpema;
               // o.Sef = r.Sef;

                s.Update(o);
                s.Flush();

                s.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }

            return r;
        }

        public static RadnikBasic vratiRadnika(int id)
        {
            RadnikBasic rb = new RadnikBasic();
            try
            {
                ISession s = DataLayer.GetSession();

                Prodavnica.Entiteti.Radnik r = s.Load<Prodavnica.Entiteti.Radnik>(id);
                rb = new RadnikBasic(r.Jbr, r.Mbr, r.Ime, r.SrednjeSlovo, r.Prezime, r.DatumRodjenja, r.StrucnaSpema, r.Sef);

                s.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }

            return rb;
        }
        public static void obrisiRadnikaIzSistema(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Prodavnica.Entiteti.Radnik r = s.Load<Prodavnica.Entiteti.Radnik>(id);
                r.Prodavnice.Clear();
                r.RadiUProdavnice.Clear(); //jedan radnik moze da radi i u vise prodavnica 
                s.Delete(r);
                s.Flush();

                s.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }

        }

        public static void obrisiRadnika(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Prodavnica.Entiteti.Radnik r = s.Load<Prodavnica.Entiteti.Radnik>(id);
                r.Prodavnice.Clear();
               // r.RadiUProdavnice.Clear(); jedan radnik moze da radi i u vise prodavnica //ovo mozda nece biti potrebno
                s.Delete(r);
                s.Flush();

                s.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }
        }

        #endregion

        #region RadiU
        public static List<RadiUBasic> vratiRadniOdnos(int idZaposlenog,int idProdavnice)
        {
            List<RadiUBasic> radi = new List<RadiUBasic>();
            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<RadiU> rad = from o in s.Query<RadiU>()
                            where o.Id.RadnikRadiU.Jbr==idZaposlenog
                            where o.Id.RadiUProdavnica.Id==idProdavnice
                            select o;

                foreach(RadiU r in rad)
                {
                    RadiUIdBasic id = new RadiUIdBasic();
                    id.RadiUProdavnica = DTOManager.vratiProdavnicu(r.Id.RadiUProdavnica.Id);
                    id.RadnikRadiU = DTOManager.vratiRadnika(r.Id.RadnikRadiU.Jbr);
                    radi.Add(new RadiUBasic(id, r.DatumOd, r.DatumDo));
                }

                s.Close();

            }
            catch (Exception ec)
            {
                //handle exceptions
            }

            return radi;
        

        }

        public static void izmeniRadniOdnos(RadiUBasic rad)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                RadiUId id = new RadiUId();
                id.RadnikRadiU = s.Load<Radnik>(rad.Id.RadnikRadiU.Jbr);
                id.RadiUProdavnica = s.Load<Prodavnica.Entiteti.Prodavnica>(rad.Id.RadiUProdavnica.Id);
                Prodavnica.Entiteti.RadiU o = s.Load<RadiU>(id);

                o.DatumOd = rad.DatumOd;
                o.DatumDo = rad.DatumDo;
                



                s.SaveOrUpdate(o);

                s.Flush();

                s.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }
        }
        #endregion

        #region Proizvodi

        public static List<ProizvodPregled> vratiSveProizvode()
        {
            List<ProizvodPregled> proizvodi = new List<ProizvodPregled>();
            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<Prodavnica.Entiteti.Proizvod> sviProizvodi = from o in s.Query<Prodavnica.Entiteti.Proizvod>()
                                                               select o;

                foreach (Prodavnica.Entiteti.Proizvod p in sviProizvodi)
                {
                    proizvodi.Add(new ProizvodPregled(p.BarKod, p.Tip, p.Naziv, p.Proizvodjac));
                }

                s.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }

            return proizvodi;
        }

        #endregion

        #region Sef
        public static List<SefBasic> vratiSveSefove()
        {
            List<SefBasic> radnici = new List<SefBasic>();
            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<Prodavnica.Entiteti.Sef> sviSefovi = from o in s.Query<Prodavnica.Entiteti.Sef>()
                                                                    
                                                                    select o;

                foreach (Prodavnica.Entiteti.Sef r in sviSefovi)
                {
                    radnici.Add(new SefBasic(r.Jbr,r.Mbr,r.Ime,r.SrednjeSlovo,r.Prezime
                        ,r.DatumRodjenja,r.StrucnaSpema,r.Sef));
                }

                s.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }

            return radnici;

        }

        public static List<SefujeBasic> vratiSveSefoveProdavnice(int id)
        {
            List<SefujeBasic> sefovanje = new List<SefujeBasic>();
            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<Prodavnica.Entiteti.Sefuje> sviSefovi = from o in s.Query<Prodavnica.Entiteti.Sefuje>()
                                                                    where o.Upravlja.Id == id
                                                                    select o;

                foreach (Prodavnica.Entiteti.Sefuje r in sviSefovi)
                {
                    SefBasic upravnik = DTOManager.vratiSefa(r.Upravnik.Jbr);
                    ProdavnicaBasic upravlja = DTOManager.vratiProdavnicu(r.Upravlja.Id);
                    sefovanje.Add(new SefujeBasic(r.Id,r.DatumPostavljenja,upravnik, upravlja));
                }

                s.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }

            return sefovanje;
        }

        public static void dodajSefOdnos(SefujeBasic sefuje)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Sefuje r = new Sefuje();
                r.Upravlja = s.Load<Prodavnica.Entiteti.Prodavnica>(sefuje.Upravlja.Id);
                r.Upravnik = s.Load<Sef>(sefuje.Upravnik.Jbr); // OVDE JE GRESKA
                r.DatumPostavljenja = sefuje.DatumPostavljenja;
                
                s.SaveOrUpdate(r);
                s.Flush();
                s.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }
        }

        public static void dodajSefa(SefBasic r)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Prodavnica.Entiteti.Sef o = new Prodavnica.Entiteti.Sef();
                o.Mbr = r.Mbr;
                o.Ime = r.Ime;
                o.SrednjeSlovo = r.SrednjeSlovo;
                o.Prezime = r.Prezime;
                o.DatumRodjenja = r.DatumRodjenja;
                o.StrucnaSpema = r.StrucnaSpema;
                

                s.SaveOrUpdate(o);

                s.Flush();

                s.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }
        }

        public static SefBasic vratiSefa(int id)
        {
            SefBasic rb = new SefBasic();
            try
            {
                ISession s = DataLayer.GetSession();

                Prodavnica.Entiteti.Sef r = s.Load<Prodavnica.Entiteti.Sef>(id);
                rb = new SefBasic(r.Jbr, r.Mbr, r.Ime, r.SrednjeSlovo, r.Prezime, r.DatumRodjenja, r.StrucnaSpema, r.Sef);

                s.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }

            return rb;
        }

        public static RadnikBasic azurirajSefa(RadnikBasic r)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Prodavnica.Entiteti.Radnik o = s.Load<Prodavnica.Entiteti.Radnik>(r.Jbr);

                o.Ime = r.Ime;
                o.SrednjeSlovo = r.SrednjeSlovo;
                o.Prezime = r.Prezime;
                o.DatumRodjenja = r.DatumRodjenja;
                o.StrucnaSpema = r.StrucnaSpema;
                // o.Sef = r.Sef;

                s.Update(o);
                s.Flush();

                s.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }

            return r;
        }

        public static void obrisiSefa(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Prodavnica.Entiteti.Sefuje r = s.Load<Prodavnica.Entiteti.Sefuje>(id);
                
                //r.RadiUProdavnice.Clear();
                //r.SefujeProdavnice.Clear();
                s.Delete(r);
                s.Flush();

                s.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }
        }

        #endregion

        #region Proizvodi
        public static List<ProizvodBasic> vratiSveProizvodeBasic()
        {
            List<ProizvodBasic> prodaja = new List<ProizvodBasic>();
            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<Proizvod> proizvodi = from o in s.Query<Prodavnica.Entiteti.Proizvod>()
                                                   select o;

                foreach (Proizvod p in proizvodi)
                {
                    ProizvodBasic proizvod = DTOManager.vratiProizvod(p.BarKod);
                    prodaja.Add(proizvod);
                }

                s.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }

            return prodaja;

        }

        public static List<ProdajeSeBasic> vratiProizvodeOdeljenjaDo5(int odeljenjeId)
        {
            List<ProdajeSeBasic> prodaja = new List<ProdajeSeBasic>();
            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<ProdajeSe> proizvodi = from o in s.Query<Prodavnica.Entiteti.ProdajeSe>()
                                                   where o.ProdajeOdeljenje.Id == odeljenjeId
                                                   select o;

                foreach (ProdajeSe p in proizvodi)
                {
                    ProizvodBasic proizvod = DTOManager.vratiProizvod(p.ProdajeProzivod.BarKod);
                    OdeljenjeDo5Basic odeljenje = DTOManager.vratiOdeljenjeDo5(p.ProdajeOdeljenje.Id);
                    prodaja.Add(new ProdajeSeBasic(p.Id, proizvod, odeljenje));
                }

                s.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }

            return prodaja;
        }

        public static List<ProdajeSeBasic> vratiProizvodeOdeljenjaOd6Do15(int odeljenjeId)
        {
            List<ProdajeSeBasic> prodaja = new List<ProdajeSeBasic>();
            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<ProdajeSe> proizvodi = from o in s.Query<Prodavnica.Entiteti.ProdajeSe>()
                                                   where o.ProdajeOdeljenje.Id == odeljenjeId
                                                   select o;

                foreach (ProdajeSe p in proizvodi)
                {
                    ProizvodBasic proizvod = DTOManager.vratiProizvod(p.ProdajeProzivod.BarKod);
                    OdeljenjeOd6Do15Basic odeljenje = DTOManager.vratiOdeljenjeOd6Do15(p.ProdajeOdeljenje.Id);
                    prodaja.Add(new ProdajeSeBasic(p.Id, proizvod, odeljenje));
                }

                s.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }

            return prodaja;
        }

        public static List<ProdajeSeBasic> vratiProizvodeOdeljenjaOdraslih(int odeljenjeId)
        {
            List<ProdajeSeBasic> prodaja = new List<ProdajeSeBasic>();
            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<ProdajeSe> proizvodi = from o in s.Query<Prodavnica.Entiteti.ProdajeSe>()
                                                   where o.ProdajeOdeljenje.Id == odeljenjeId
                                                   select o;

                foreach (ProdajeSe p in proizvodi)
                {
                    ProizvodBasic proizvod = DTOManager.vratiProizvod(p.ProdajeProzivod.BarKod);
                    OdeljenjeOdrasliBasic odeljenje = DTOManager.vratiOdeljenjeOdrasli(p.ProdajeOdeljenje.Id);
                    prodaja.Add(new ProdajeSeBasic(p.Id, proizvod, odeljenje));
                }

                s.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }

            return prodaja;
        }

        public static void obrisiProizvod(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                
                Prodavnica.Entiteti.ProdajeSe r = s.Load<Prodavnica.Entiteti.ProdajeSe>(id);
                
                s.Delete(r);
                s.Flush();

                s.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }
        }

        public static ProizvodBasic vratiProizvod(int id)
        {
            ProizvodBasic rb = new ProizvodBasic();
            try
            {
                ISession s = DataLayer.GetSession();

                Prodavnica.Entiteti.Proizvod p = s.Load<Prodavnica.Entiteti.Proizvod>(id);
                rb = new ProizvodBasic(p.BarKod, p.Tip, p.Naziv, p.Proizvodjac);

                s.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }

            return rb;
        }

        public static OdeljenjeDo5Basic vratiOdeljenjeDo5(int id)
        {
            OdeljenjeDo5Basic pb = new OdeljenjeDo5Basic();
            try
            {
                ISession s = DataLayer.GetSession();

                Prodavnica.Entiteti.OdeljenjeDo5 o = s.Load<Prodavnica.Entiteti.OdeljenjeDo5>(id);
                pb = new OdeljenjeDo5Basic(o.Id, o.Lokacija, o.PripadaProdavnici.Naziv, o.BrojKasa);

                s.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }

            return pb;
        }

        public static OdeljenjeOd6Do15Basic vratiOdeljenjeOd6Do15(int id)
        {
            OdeljenjeOd6Do15Basic pb = new OdeljenjeOd6Do15Basic();
            try
            {
                ISession s = DataLayer.GetSession();

                Prodavnica.Entiteti.OdeljenjeOd6Do15 o = s.Load<Prodavnica.Entiteti.OdeljenjeOd6Do15>(id);
                pb = new OdeljenjeOd6Do15Basic(o.Id, o.Lokacija, o.PripadaProdavnici.Naziv, o.BrojKasa);

                s.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }

            return pb;
        }

        public static OdeljenjeOdrasliBasic vratiOdeljenjeOdrasli(int id)
        {
            OdeljenjeOdrasliBasic pb = new OdeljenjeOdrasliBasic();
            try
            {
                ISession s = DataLayer.GetSession();

                Prodavnica.Entiteti.OdeljenjeOdrasli o = s.Load<Prodavnica.Entiteti.OdeljenjeOdrasli>(id);
                pb = new OdeljenjeOdrasliBasic(o.Id, o.Lokacija, o.PripadaProdavnici.Naziv, o.BrojKasa);

                s.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }

            return pb;
        }

        public static void sacuvajAutomobil(AutomobilBasic automobil)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Prodavnica.Entiteti.Automobil a = new Prodavnica.Entiteti.Automobil();

                a.Tip = automobil.Tip;
                a.Naziv = automobil.Naziv;
                a.Proizvodjac = automobil.Proizvodjac;
                a.NazivSerije = automobil.NazivSerije;
                a.Baterije = automobil.Baterije;

                s.Save(a);

                s.Flush();

                s.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }
        }

        public static void sacuvajIgrackuPlastika(IgrackaPlastikaBasic igracka)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Prodavnica.Entiteti.IgrackaPlastika ip = new Prodavnica.Entiteti.IgrackaPlastika();

                ip.Tip = igracka.Tip;
                ip.Naziv = igracka.Naziv;
                ip.Proizvodjac = igracka.Proizvodjac;
                ip.Uzrast = igracka.Uzrast;
                ip.Vodootporna = igracka.Vodootporna;
                ip.Lomljiva = igracka.Lomljiva;

                s.Save(ip);

                s.Flush();

                s.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }
        }

        public static void sacuvajVojnika(VojnikBasic vojnik)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Prodavnica.Entiteti.Vojnik v = new Prodavnica.Entiteti.Vojnik();

                v.Tip = vojnik.Tip;
                v.Naziv = vojnik.Naziv;
                v.Proizvodjac = vojnik.Proizvodjac;
                v.NazivSerije = vojnik.NazivSerije;
                v.Baterije = vojnik.Baterije;
                v.Metal = vojnik.Metal;
                v.Plastika = vojnik.Plastika;

                s.Save(v);

                s.Flush();

                s.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }
        }

        public static void sacuvajSlagalicu(SlagalicaBasic slagalica)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Prodavnica.Entiteti.Slagalica sl = new Prodavnica.Entiteti.Slagalica();

                sl.Tip = slagalica.Tip;
                sl.Naziv = slagalica.Naziv;
                sl.Proizvodjac = slagalica.Proizvodjac;
                sl.BrojDelova = slagalica.BrojDelova;
                sl.Turisticka = slagalica.Turisticka;
                sl.Umetnicka = slagalica.Umetnicka;
                sl.Ilustracija = slagalica.Ilustracija;

                s.Save(sl);

                s.Flush();

                s.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }
        }

        public static void sacuvajLutku(LutkaBasic lutka)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Prodavnica.Entiteti.Lutka l = new Prodavnica.Entiteti.Lutka();

                l.Tip = lutka.Tip;
                l.Naziv = lutka.Naziv;
                l.Proizvodjac = lutka.Proizvodjac;
                l.Ime = lutka.Ime;
                l.Govori = lutka.Govori;
                l.OsetljivaDodir = lutka.OsetljivaDodir;

                s.Save(l);

                s.Flush();

                s.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }
        }

        public static void sacuvajDodatakZaLutku(DodatakZaLutkuBasic dodatak)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Prodavnica.Entiteti.DodatakZaLutku dzl = new Prodavnica.Entiteti.DodatakZaLutku();

                dzl.Tip = dodatak.Tip;
                dzl.Naziv = dodatak.Naziv;
                dzl.Proizvodjac = dodatak.Proizvodjac;
                dzl.NazivDodatka = dodatak.NazivDodatka;
                dzl.TipDodatka = dodatak.TipDodatka;

                s.Save(dzl);

                s.Flush();

                s.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }
        }

        public static IgrackaPlastikaBasic vratiIgrackuPlastika(int id)
        {
            IgrackaPlastikaBasic rb = new IgrackaPlastikaBasic();
            try
            {
                ISession s = DataLayer.GetSession();

                Prodavnica.Entiteti.IgrackaPlastika ip = s.Load<Prodavnica.Entiteti.IgrackaPlastika>(id);
                rb = new IgrackaPlastikaBasic(ip.BarKod, ip.Tip, ip.Naziv, ip.Proizvodjac, ip.Uzrast, ip.Vodootporna, ip.Lomljiva);

                s.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }

            return rb;
        }

        public static IgrackaPlastikaBasic azurirajIgrackuPlastika(IgrackaPlastikaBasic r)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Prodavnica.Entiteti.IgrackaPlastika ip = s.Load<Prodavnica.Entiteti.IgrackaPlastika>(r.BarKod);

                ip.Naziv = r.Naziv;
                ip.Proizvodjac = r.Proizvodjac;
                ip.Uzrast = r.Uzrast;
                ip.Vodootporna = r.Vodootporna;
                ip.Lomljiva = r.Lomljiva;

                s.Update(ip);
                s.Flush();

                s.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }

            return r;
        }
        
        public static AutomobilBasic vratiAutomobil(int id)
        {
            AutomobilBasic rb = new AutomobilBasic();
            try
            {
                ISession s = DataLayer.GetSession();

                Prodavnica.Entiteti.Automobil a = s.Load<Prodavnica.Entiteti.Automobil>(id);
                rb = new AutomobilBasic(a.BarKod, a.Tip, a.Naziv, a.Proizvodjac, a.NazivSerije, a.Baterije);

                s.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }

            return rb;
        }

        public static AutomobilBasic azurirajAutomobil(AutomobilBasic r)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Prodavnica.Entiteti.Automobil a = s.Load<Prodavnica.Entiteti.Automobil>(r.BarKod);

                a.Naziv = r.Naziv;
                a.Proizvodjac = r.Proizvodjac;
                a.NazivSerije = r.NazivSerije;
                a.Baterije = r.Baterije;

                s.Update(a);
                s.Flush();

                s.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }

            return r;
        }

        public static VojnikBasic vratiVojnika(int id)
        {
            VojnikBasic rb = new VojnikBasic();
            try
            {
                ISession s = DataLayer.GetSession();

                Prodavnica.Entiteti.Vojnik v = s.Load<Prodavnica.Entiteti.Vojnik>(id);
                rb = new VojnikBasic(v.BarKod, v.Tip, v.Naziv, v.Proizvodjac, v.NazivSerije, v.Baterije, v.Metal, v.Plastika);

                s.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }

            return rb;
        }

        public static VojnikBasic azurirajVojnika(VojnikBasic r)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Prodavnica.Entiteti.Vojnik v = s.Load<Prodavnica.Entiteti.Vojnik>(r.BarKod);

                v.Naziv = r.Naziv;
                v.Proizvodjac = r.Proizvodjac;
                v.NazivSerije = r.NazivSerije;
                v.Baterije = r.Baterije;
                v.Metal = r.Metal;
                v.Plastika = r.Plastika;

                s.Update(v);
                s.Flush();

                s.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }

            return r;
        }

        public static LutkaBasic vratiLutku(int id)
        {
            LutkaBasic rb = new LutkaBasic();
            try
            {
                ISession s = DataLayer.GetSession();

                Prodavnica.Entiteti.Lutka l = s.Load<Prodavnica.Entiteti.Lutka>(id);
                rb = new LutkaBasic(l.BarKod, l.Tip, l.Naziv, l.Proizvodjac, l.Ime, l.Govori, l.OsetljivaDodir);

                s.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }

            return rb;
        }

        public static LutkaBasic azurirajLutku(LutkaBasic r)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Prodavnica.Entiteti.Lutka l = s.Load<Prodavnica.Entiteti.Lutka>(r.BarKod);

                l.Naziv = r.Naziv;
                l.Proizvodjac = r.Proizvodjac;
                l.Ime = r.Ime;
                l.Govori = r.Govori;
                l.OsetljivaDodir = r.OsetljivaDodir;

                s.Update(l);
                s.Flush();

                s.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }

            return r;
        }

        public static DodatakZaLutkuBasic vratiDodatakZaLutku(int id)
        {
            DodatakZaLutkuBasic rb = new DodatakZaLutkuBasic();
            try
            {
                ISession s = DataLayer.GetSession();

                Prodavnica.Entiteti.DodatakZaLutku dzl = s.Load<Prodavnica.Entiteti.DodatakZaLutku>(id);
                rb = new DodatakZaLutkuBasic(dzl.BarKod, dzl.Tip, dzl.Naziv, dzl.Proizvodjac, dzl.NazivDodatka, dzl.TipDodatka);

                s.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }

            return rb;
        }

        public static DodatakZaLutkuBasic azurirajDodatakZaLutku(DodatakZaLutkuBasic r)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Prodavnica.Entiteti.DodatakZaLutku dzl = s.Load<Prodavnica.Entiteti.DodatakZaLutku>(r.BarKod);

                dzl.Naziv = r.Naziv;
                dzl.Proizvodjac = r.Proizvodjac;
                dzl.NazivDodatka = r.NazivDodatka;
                dzl.TipDodatka = r.TipDodatka;

                s.Update(dzl);
                s.Flush();

                s.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }

            return r;
        }

        public static SlagalicaBasic vratiSlagalicu(int id)
        {
            SlagalicaBasic rb = new SlagalicaBasic();
            try
            {
                ISession s = DataLayer.GetSession();

                Prodavnica.Entiteti.Slagalica sl = s.Load<Prodavnica.Entiteti.Slagalica>(id);
                rb = new SlagalicaBasic(sl.BarKod, sl.Tip, sl.Naziv, sl.Proizvodjac, sl.BrojDelova, sl.Turisticka, sl.Umetnicka, sl.Ilustracija);

                s.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }

            return rb;
        }

        public static SlagalicaBasic azurirajSlagalicu(SlagalicaBasic r)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Prodavnica.Entiteti.Slagalica sl = s.Load<Prodavnica.Entiteti.Slagalica>(r.BarKod);

                sl.Naziv = r.Naziv;
                sl.Proizvodjac = r.Proizvodjac;
                sl.BrojDelova = r.BrojDelova;
                sl.Turisticka = r.Turisticka;
                sl.Umetnicka = r.Umetnicka;
                sl.Ilustracija = r.Ilustracija;

                s.Update(sl);
                s.Flush();

                s.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }

            return r;
        }

        public static void obrisiIgrackuIzSistema(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Prodavnica.Entiteti.Proizvod p = s.Load<Prodavnica.Entiteti.Proizvod>(id);
                s.Delete(p);
                s.Flush();

                s.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }
        }

        #endregion

        #region ProdajeSe
        public static void sacuvajProdajeSe(ProdajeSeBasic p)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Prodavnica.Entiteti.ProdajeSe a = new Prodavnica.Entiteti.ProdajeSe();

                a.ProdajeOdeljenje = s.Load<Odeljenje>(p.ProdajeOdeljenje.OdeljenjeId);
                a.ProdajeProzivod = s.Load<Proizvod>(p.ProdajeProzivod.BarKod);

                s.Save(a);

                s.Flush();

                s.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }

        }
        #endregion
    }
}

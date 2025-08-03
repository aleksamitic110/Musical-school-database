DROP TABLE Polaganje;
DROP TABLE Komisija;
DROP TABLE Ispit;
DROP TABLE Evidencija;
DROP TABLE Cas;
DROP TABLE Pohadja;
DROP TABLE KursInstrumentalni;
DROP TABLE KursVokalni;
DROP TABLE KursTeorijski;
DROP TABLE Kurs;
DROP TABLE Ucionica;
DROP TABLE Filijala;
DROP TABLE Stalni;
DROP TABLE Honorarni;
DROP TABLE Nastavnik;
DROP TABLE Odrasli;
DROP TABLE Dete;
DROP TABLE Polaznik;
DROP TABLE Staratelj;
DROP TABLE Telefon;
DROP TABLE Osoba;


-- TABLE
CREATE TABLE Filijala (
    idFilijale VARCHAR2(255) PRIMARY KEY,
    adresa VARCHAR2(255) NOT NULL,
    radnoVreme VARCHAR2(255) NOT NULL,
    opremljenostUcionica VARCHAR2(255) NOT NULL,
    kapacitetFilijale INTEGER NOT NULL
);
CREATE TABLE Osoba (
    jmbg VARCHAR2(13) PRIMARY KEY,
    ime VARCHAR2(255) NOT NULL,
    prezime VARCHAR2(255) NOT NULL,
    adresa VARCHAR2(255) NOT NULL,
    mail VARCHAR2(255) NOT NULL
);
CREATE TABLE Telefon ( 
    brojTelefona VARCHAR2(15),
    jmbg VARCHAR2(13),
    PRIMARY KEY (brojTelefona, jmbg),
    FOREIGN KEY (jmbg) REFERENCES Osoba(jmbg)
);
CREATE TABLE Staratelj (
    jmbgStaratelja VARCHAR2(13) PRIMARY KEY,
    FOREIGN KEY (jmbgStaratelja) REFERENCES Osoba(jmbg)
);
CREATE TABLE Nastavnik (
    jmbgNastavnika VARCHAR2(13) PRIMARY KEY,
    strucnaSprema VARCHAR2(255) NOT NULL,
    datumZaposlenja DATE NOT NULL,
    FOREIGN KEY (jmbgNastavnika) REFERENCES Osoba(jmbg)
);
CREATE TABLE Honorarni (
    jmbgNastavnikaHonorarni VARCHAR2(13) PRIMARY KEY,
    brUgovora VARCHAR2(255) NOT NULL,
    brCasovaMesecno INT NOT NULL,
    trajanjeUgovora DATE NOT NULL,
    FOREIGN KEY (jmbgNastavnikaHonorarni) REFERENCES Nastavnik(jmbgNastavnika)
);
CREATE TABLE Polaznik (
    jmbgPolaznika VARCHAR2(13) PRIMARY KEY,
    FOREIGN KEY (jmbgPolaznika) REFERENCES Osoba(jmbg)
);
CREATE TABLE Odrasli (
    jmbgPolaznikaOdrasli VARCHAR2(13) PRIMARY KEY,
    zanimanje VARCHAR2(255) NOT NULL,
    FOREIGN KEY (jmbgPolaznikaOdrasli) REFERENCES Polaznik(jmbgPolaznika)
);
CREATE TABLE Dete (
    jmbgPolaznikaDete VARCHAR2(13) PRIMARY KEY,
    datumRodjenja DATE NOT NULL,
    brojDosijea VARCHAR2(255) NOT NULL,
    jmbgStaratelja VARCHAR2(13) NOT NULL,
    FOREIGN KEY (jmbgPolaznikaDete) REFERENCES Polaznik(jmbgPolaznika),
    FOREIGN KEY (jmbgStaratelja) REFERENCES Staratelj(jmbgStaratelja)
);
CREATE TABLE Stalni (
    jmbgNastavnikaStalni VARCHAR2(13) PRIMARY KEY,
    jmbgMentora VARCHAR2(13),
    radnoVreme VARCHAR2(255) NOT NULL,
    statusMentora NUMBER(1) NOT NULL,
    FOREIGN KEY (jmbgNastavnikaStalni) REFERENCES Nastavnik(jmbgNastavnika),
    FOREIGN KEY (jmbgMentora) REFERENCES Nastavnik(jmbgNastavnika)
);
CREATE TABLE Kurs (
    idKursa VARCHAR2(255) PRIMARY KEY,
    idFilijale VARCHAR2(255) NOT NULL,
    jmbgNastavnika VARCHAR2(13) NOT NULL,
    naziv VARCHAR2(255) NOT NULL,
    nivo VARCHAR2(20) CHECK (nivo IN ('pocetni', 'srednji', 'napredni')),
    tipNastave VARCHAR2(20) CHECK (tipNastave IN ('individualna', 'grupna')),
    FOREIGN KEY (idFilijale) REFERENCES Filijala(idFilijale),
    FOREIGN KEY (jmbgNastavnika) REFERENCES Nastavnik(jmbgNastavnika)
);
CREATE TABLE Ispit (
    idIspita VARCHAR2(255) PRIMARY KEY,
    idKursa VARCHAR2(255) NOT NULL,
    datum DATE NOT NULL,
    FOREIGN KEY (idKursa) REFERENCES Kurs(idKursa)
);
CREATE TABLE Komisija (
    jmbgNastavnika VARCHAR2(13) NOT NULL,
    idIspita VARCHAR2(255) NOT NULL,
    PRIMARY KEY (jmbgNastavnika, idIspita),
    FOREIGN KEY (jmbgNastavnika) REFERENCES Nastavnik(jmbgNastavnika),
    FOREIGN KEY (idIspita) REFERENCES Ispit(idIspita)
);
CREATE TABLE KursInstrumentalni (
    idKursa VARCHAR2(255) PRIMARY KEY,
    instrumenti VARCHAR2(255) NOT NULL,
    FOREIGN KEY (idKursa) REFERENCES Kurs(idKursa)
);
CREATE TABLE KursTeorijski (
    idKursa VARCHAR2(255) PRIMARY KEY,
    nazivPredmeta VARCHAR2(255) NOT NULL,
    FOREIGN KEY (idKursa) REFERENCES Kurs(idKursa)
);
CREATE TABLE KursVokalni (
    idKursa VARCHAR2(255) PRIMARY KEY,
    tipPevanja VARCHAR2(50) CHECK (tipPevanja IN ('individualno', 'horsko')),
    FOREIGN KEY (idKursa) REFERENCES Kurs(idKursa)
);
CREATE TABLE Pohadja (
    jmbgPolaznika VARCHAR2(13) NOT NULL,
    idKursa VARCHAR2(255) NOT NULL,
    PRIMARY KEY (jmbgPolaznika, idKursa),
    FOREIGN KEY (jmbgPolaznika) REFERENCES Polaznik(jmbgPolaznika),
    FOREIGN KEY (idKursa) REFERENCES Kurs(idKursa)
);
CREATE TABLE Polaganje (
    jmbgPolaznika VARCHAR2(13) NOT NULL,
    idIspita VARCHAR2(255) NOT NULL,
    ocena INT NOT NULL,
    polozio NUMBER(1) NOT NULL,
    PRIMARY KEY (jmbgPolaznika, idIspita),
    FOREIGN KEY (jmbgPolaznika) REFERENCES Polaznik(jmbgPolaznika),
    FOREIGN KEY (idIspita) REFERENCES Ispit(idIspita)
);
CREATE TABLE Ucionica (
    idUcionice VARCHAR2(255) PRIMARY KEY,
    idFilijale VARCHAR2(255) NOT NULL,
    oznaka VARCHAR2(255) NOT NULL,
    kapacitetUcionice INTEGER NOT NULL,
    FOREIGN KEY (idFilijale) REFERENCES Filijala(idFilijale)
);
CREATE TABLE Cas (
    idCasa VARCHAR2(255) PRIMARY KEY,
    idKursa VARCHAR2(255) NOT NULL,
    idUcionice VARCHAR2(255) NOT NULL,
    datum DATE NOT NULL,
    vreme VARCHAR2(255) NOT NULL,
    lekcija VARCHAR2(255) NOT NULL,
    FOREIGN KEY (idKursa) REFERENCES Kurs(idKursa),
    FOREIGN KEY (idUcionice) REFERENCES Ucionica(idUcionice)
);

CREATE TABLE Evidencija (
    jmbgPolaznika VARCHAR2(13) NOT NULL,
    idCasa VARCHAR2(255) NOT NULL,
    ocena INT NOT NULL,
    prisustvo NUMBER(1) NOT NULL,
    PRIMARY KEY (jmbgPolaznika, idCasa),
    FOREIGN KEY (jmbgPolaznika) REFERENCES Polaznik(jmbgPolaznika),
    FOREIGN KEY (idCasa) REFERENCES Cas(idCasa)
);
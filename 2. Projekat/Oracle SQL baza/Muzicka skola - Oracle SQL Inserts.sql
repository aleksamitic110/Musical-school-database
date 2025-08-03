  -- Select * FROM Evidencija;
  -- Select * FROM Cas;
  -- Select * FROM Polaganje;
  -- Select * FROM Pohadja;
  -- Select * FROM Komisija;
  -- Select * FROM Ispit;
  -- Select * FROM KursInstrumentalni;
  -- Select * FROM KursVokalni;
  -- Select * FROM KursTeorijski;
  -- Select * FROM Kurs;
  -- Select * FROM Ucionica;
  -- Select * FROM Stalni;
  -- Select * FROM Honorarni;
  -- Select * FROM Odrasli;
  -- Select * FROM Dete;
  -- Select * FROM Polaznik;
  -- Select * FROM Nastavnik;
  -- Select * FROM Staratelj;
  -- Select * FROM Telefon;
  Select * FROM Osoba;
SELECT s.* 
FROM Staratelj s
LEFT JOIN Osoba o ON s.jmbg_osobe = o.jmbg
WHERE o.jmbg IS NULL;


BEGIN
  -- Brišemo podatke iz tabela redom da ne bi bilo problema sa FK
  DELETE FROM Evidencija;
  DELETE FROM Cas;
  DELETE FROM Polaganje;
  DELETE FROM Pohadja;
  DELETE FROM Komisija;
  DELETE FROM Ispit;
  DELETE FROM KursInstrumentalni;
  DELETE FROM KursVokalni;
  DELETE FROM KursTeorijski;
  DELETE FROM Kurs;
  DELETE FROM Ucionica;
  DELETE FROM Stalni;
  DELETE FROM Honorarni;
  DELETE FROM Odrasli;
  DELETE FROM Dete;
  DELETE FROM Polaznik;
  DELETE FROM Nastavnik;
  DELETE FROM Staratelj;
  DELETE FROM Telefon;
  DELETE FROM Osoba;

  COMMIT;
  -- Ubacivanje u Osoba
  INSERT INTO Osoba VALUES ('1234567890001', 'Ana', 'Anić', 'Beogradska 1', 'ana@mail.com');
  INSERT INTO Osoba VALUES ('1234567890002', 'Marko', 'Marić', 'Novosadska 2', 'marko@gmail.com');
  INSERT INTO Osoba VALUES ('1234567890003', 'Jelena', 'Jelić', 'Zrenjaninska 3', 'jelena@yahoo.com');
  INSERT INTO Osoba VALUES ('1234567890004', 'Petar', 'Petrović', 'Niska 4', 'petar@hotmail.com');
  INSERT INTO Osoba VALUES ('1234567890005', 'Ivana', 'Ivić', 'Sarajevska 5', 'ivana@hotmail.com');
  INSERT INTO Osoba VALUES ('1234567890006', 'Nikola', 'Nikolić', 'Zagrebačka 6', 'nikola@gmail.com');
  INSERT INTO Osoba VALUES ('1234567890007', 'Milica', 'Milić', 'Užička 7', 'milica@outlook.com');
  INSERT INTO Osoba VALUES ('1234567890008', 'Luka', 'Lukić', 'Niška 8', 'luka@outlook.com');
  INSERT INTO Osoba VALUES ('1234567890009', 'Sara', 'Sarić', 'Požeška 9', 'sara@yahoo.com');
  INSERT INTO Osoba VALUES ('1234567890010', 'Milan', 'Milićević', 'Dunavska 10', 'milan@yahoo.com');

  -- Ubacivanje u Telefon
  INSERT INTO Telefon (brojTelefona, jmbg) VALUES ('0601234561', '1234567890001');
  INSERT INTO Telefon (brojTelefona, jmbg) VALUES ('0601234562', '1234567890002');
  INSERT INTO Telefon (brojTelefona, jmbg) VALUES ('0601234563', '1234567890003');
  INSERT INTO Telefon (brojTelefona, jmbg) VALUES ('0601234564', '1234567890004');
  INSERT INTO Telefon (brojTelefona, jmbg) VALUES ('0601234565', '1234567890005');
  INSERT INTO Telefon (brojTelefona, jmbg) VALUES ('0601234566', '1234567890006');
  INSERT INTO Telefon (brojTelefona, jmbg) VALUES ('0601234567', '1234567890007');
  INSERT INTO Telefon (brojTelefona, jmbg) VALUES ('0601234568', '1234567890008');
  INSERT INTO Telefon (brojTelefona, jmbg) VALUES ('0601234569', '1234567890009');
  INSERT INTO Telefon (brojTelefona, jmbg) VALUES ('0601234570', '1234567890010');

  -- Ubacivanje u Staratelj
  INSERT INTO Staratelj (jmbg_osobe) VALUES ('1234567890001');
  INSERT INTO Staratelj (jmbg_osobe) VALUES ('1234567890002');
  INSERT INTO Staratelj (jmbg_osobe) VALUES ('1234567890003');

  -- Ubacivanje u Nastavnik
  INSERT INTO Nastavnik (jmbg_osobe, strucnaSprema, datumZaposlenja)
  VALUES ('1234567890001', 'Master muzike', TO_DATE('2018-09-01', 'YYYY-MM-DD'));
  INSERT INTO Nastavnik (jmbg_osobe, strucnaSprema, datumZaposlenja)
  VALUES ('1234567890002', 'Bachelor muzike', TO_DATE('2019-10-15', 'YYYY-MM-DD'));
  INSERT INTO Nastavnik (jmbg_osobe, strucnaSprema, datumZaposlenja)
  VALUES ('1234567890003', 'Doktor umetnosti', TO_DATE('2020-01-10', 'YYYY-MM-DD'));

  -- Dohvatanje ID nastavnika za Honorarni
  DECLARE
    v_nastavnik_id NUMBER;
  BEGIN
    SELECT id INTO v_nastavnik_id FROM Nastavnik WHERE jmbg_osobe = '1234567890002';
    INSERT INTO Honorarni (nastavnik_id, brUgovora, brCasovaMesecno, trajanjeUgovora)
    VALUES (v_nastavnik_id, 'H001', 20, TO_DATE('2025-12-31', 'YYYY-MM-DD'));
  END;

  -- Ubacivanje u Polaznik
  INSERT INTO Polaznik (jmbg_osobe) VALUES ('1234567890004');
  INSERT INTO Polaznik (jmbg_osobe) VALUES ('1234567890005');
  INSERT INTO Polaznik (jmbg_osobe) VALUES ('1234567890006');
  INSERT INTO Polaznik (jmbg_osobe) VALUES ('1234567890007');
  INSERT INTO Polaznik (jmbg_osobe) VALUES ('1234567890008');
  INSERT INTO Polaznik (jmbg_osobe) VALUES ('1234567890009');
  INSERT INTO Polaznik (jmbg_osobe) VALUES ('1234567890010');

  -- Ubacivanje u Odrasli
  DECLARE
    v_polaznik_id NUMBER;
  BEGIN
    SELECT id INTO v_polaznik_id FROM Polaznik WHERE jmbg_osobe = '1234567890007';
    INSERT INTO Odrasli (polaznik_id, zanimanje) VALUES (v_polaznik_id, 'Programer');

    SELECT id INTO v_polaznik_id FROM Polaznik WHERE jmbg_osobe = '1234567890008';
    INSERT INTO Odrasli (polaznik_id, zanimanje) VALUES (v_polaznik_id, 'Profesor');

    SELECT id INTO v_polaznik_id FROM Polaznik WHERE jmbg_osobe = '1234567890009';
    INSERT INTO Odrasli (polaznik_id, zanimanje) VALUES (v_polaznik_id, 'Muzičar');

    SELECT id INTO v_polaznik_id FROM Polaznik WHERE jmbg_osobe = '1234567890010';
    INSERT INTO Odrasli (polaznik_id, zanimanje) VALUES (v_polaznik_id, 'Novinar');
  END;

  -- Ubacivanje u Dete
  DECLARE
    v_polaznik_id NUMBER;
    v_staratelj_id NUMBER;
  BEGIN
    -- dete 1
    SELECT id INTO v_polaznik_id FROM Polaznik WHERE jmbg_osobe = '1234567890004';
    SELECT id INTO v_staratelj_id FROM Staratelj WHERE jmbg_osobe = '1234567890001';
    INSERT INTO Dete (polaznik_id, datumRodjenja, brojDosijea, staratelj_id)
    VALUES (v_polaznik_id, TO_DATE('2012-04-12', 'YYYY-MM-DD'), 'DOS001', v_staratelj_id);

    -- dete 2
    SELECT id INTO v_polaznik_id FROM Polaznik WHERE jmbg_osobe = '1234567890005';
    SELECT id INTO v_staratelj_id FROM Staratelj WHERE jmbg_osobe = '1234567890002';
    INSERT INTO Dete (polaznik_id, datumRodjenja, brojDosijea, staratelj_id)
    VALUES (v_polaznik_id, TO_DATE('2011-05-13', 'YYYY-MM-DD'), 'DOS002', v_staratelj_id);

    -- dete 3
    SELECT id INTO v_polaznik_id FROM Polaznik WHERE jmbg_osobe = '1234567890006';
    SELECT id INTO v_staratelj_id FROM Staratelj WHERE jmbg_osobe = '1234567890003';
    INSERT INTO Dete (polaznik_id, datumRodjenja, brojDosijea, staratelj_id)
    VALUES (v_polaznik_id, TO_DATE('2010-06-14', 'YYYY-MM-DD'), 'DOS003', v_staratelj_id);
  END;

  -- Ubacivanje u Stalni
  DECLARE
    v_nastavnik_id NUMBER;
  BEGIN
    -- Stalni nastavnik bez mentora
    SELECT id INTO v_nastavnik_id FROM Nastavnik WHERE jmbg_osobe = '1234567890001';
    INSERT INTO Stalni (nastavnik_id, jmbgMentora, radnoVreme, statusMentora)
    VALUES (v_nastavnik_id, NULL, '08:00-16:00', 1);

    -- Stalni nastavnik sa mentorom
    SELECT id INTO v_nastavnik_id FROM Nastavnik WHERE jmbg_osobe = '1234567890003';
    INSERT INTO Stalni (nastavnik_id, jmbgMentora, radnoVreme, statusMentora)
    VALUES (v_nastavnik_id, '1234567890001', '09:00-17:00', 0);
  END;

  -- Ubacivanje u Filijala
  INSERT INTO Filijala VALUES ('F001', 'Kralja Petra 1', '08:00-20:00', 'osnovna', 100);
  INSERT INTO Filijala VALUES ('F002', 'Bulevar 2', '09:00-21:00', 'napredna', 150);

  -- Ubacivanje u Kurs
  DECLARE
    v_nastavnik_id NUMBER;
  BEGIN
    SELECT id INTO v_nastavnik_id FROM Nastavnik WHERE jmbg_osobe = '1234567890001';
    INSERT INTO Kurs VALUES ('K001', 'F001', v_nastavnik_id, 'Gitara za početnike', 'pocetni', 'individualna');

    SELECT id INTO v_nastavnik_id FROM Nastavnik WHERE jmbg_osobe = '1234567890002';
    INSERT INTO Kurs VALUES ('K002', 'F001', v_nastavnik_id, 'Klavir za napredne', 'napredni', 'grupna');

    SELECT id INTO v_nastavnik_id FROM Nastavnik WHERE jmbg_osobe = '1234567890003';
    INSERT INTO Kurs VALUES ('K003', 'F002', v_nastavnik_id, 'Teorija muzike', 'srednji', 'grupna');
  END;

  -- Ubacivanje u Ispit
  INSERT INTO Ispit VALUES ('I001', 'K001', TO_DATE('2025-08-01', 'YYYY-MM-DD'));
  INSERT INTO Ispit VALUES ('I002', 'K002', TO_DATE('2025-08-02', 'YYYY-MM-DD'));

  -- Ubacivanje u Komisija
  DECLARE
    v_nastavnik_id NUMBER;
  BEGIN
    SELECT id INTO v_nastavnik_id FROM Nastavnik WHERE jmbg_osobe = '1234567890001';
    INSERT INTO Komisija (nastavnik_id, idIspita) VALUES (v_nastavnik_id, 'I001');

    SELECT id INTO v_nastavnik_id FROM Nastavnik WHERE jmbg_osobe = '1234567890002';
    INSERT INTO Komisija (nastavnik_id, idIspita) VALUES (v_nastavnik_id, 'I002');
  END;

  -- Ubacivanje u KursInstrumentalni
  INSERT INTO KursInstrumentalni VALUES ('K001', 'gitara');
  INSERT INTO KursInstrumentalni VALUES ('K002', 'klavir');

  -- Ubacivanje u KursVokalni
  INSERT INTO KursVokalni VALUES ('K003', 'horsko');

  -- Ubacivanje u KursTeorijski
  INSERT INTO KursTeorijski VALUES ('K003', 'Harmonija i kontrapunkt');

  -- Ubacivanje u Pohadja
  DECLARE
    v_polaznik_id NUMBER;
  BEGIN
    SELECT id INTO v_polaznik_id FROM Polaznik WHERE jmbg_osobe = '1234567890004';
    INSERT INTO Pohadja (polaznik_id, idKursa) VALUES (v_polaznik_id, 'K001');

    SELECT id INTO v_polaznik_id FROM Polaznik WHERE jmbg_osobe = '1234567890005';
    INSERT INTO Pohadja (polaznik_id, idKursa) VALUES (v_polaznik_id, 'K001');

    SELECT id INTO v_polaznik_id FROM Polaznik WHERE jmbg_osobe = '1234567890006';
    INSERT INTO Pohadja (polaznik_id, idKursa) VALUES (v_polaznik_id, 'K002');

    SELECT id INTO v_polaznik_id FROM Polaznik WHERE jmbg_osobe = '1234567890007';
    INSERT INTO Pohadja (polaznik_id, idKursa) VALUES (v_polaznik_id, 'K003');
  END;

  -- Ubacivanje u Polaganje
  DECLARE
    v_polaznik_id NUMBER;
  BEGIN
    SELECT id INTO v_polaznik_id FROM Polaznik WHERE jmbg_osobe = '1234567890004';
    INSERT INTO Polaganje (polaznik_id, idIspita, ocena, polozio) VALUES (v_polaznik_id, 'I001', 5, 1);

    SELECT id INTO v_polaznik_id FROM Polaznik WHERE jmbg_osobe = '1234567890005';
    INSERT INTO Polaganje (polaznik_id, idIspita, ocena, polozio) VALUES (v_polaznik_id, 'I001', 4, 1);

    SELECT id INTO v_polaznik_id FROM Polaznik WHERE jmbg_osobe = '1234567890006';
    INSERT INTO Polaganje (polaznik_id, idIspita, ocena, polozio) VALUES (v_polaznik_id, 'I002', 3, 0);
  END;

  -- Ubacivanje u Ucionica
  INSERT INTO Ucionica VALUES ('U001', 'F001', '101A', 20);
  INSERT INTO Ucionica VALUES ('U002', 'F001', '102B', 30);
  INSERT INTO Ucionica VALUES ('U003', 'F002', '201', 25);
  INSERT INTO Ucionica VALUES ('U004', 'F002', '202', 35);

  -- Ubacivanje u Cas
  INSERT INTO Cas VALUES ('C001', 'K001', 'U001', TO_DATE('2025-07-15', 'YYYY-MM-DD'), '10:00:00', 'Akordi');
  INSERT INTO Cas VALUES ('C002', 'K002', 'U002', TO_DATE('2025-07-16', 'YYYY-MM-DD'), '11:00:00', 'Skale');
  INSERT INTO Cas VALUES ('C003', 'K003', 'U003', TO_DATE('2025-07-17', 'YYYY-MM-DD'), '12:00:00', 'Teorija I');

  -- Ubacivanje u Evidencija
  DECLARE
    v_polaznik_id NUMBER;
  BEGIN
    SELECT id INTO v_polaznik_id FROM Polaznik WHERE jmbg_osobe = '1234567890004';
    INSERT INTO Evidencija (polaznik_id, idCasa, ocena, prisustvo) VALUES (v_polaznik_id, 'C001', 5, 1);

    SELECT id INTO v_polaznik_id FROM Polaznik WHERE jmbg_osobe = '1234567890005';
    INSERT INTO Evidencija (polaznik_id, idCasa, ocena, prisustvo) VALUES (v_polaznik_id, 'C001', 4, 1);

    SELECT id INTO v_polaznik_id FROM Polaznik WHERE jmbg_osobe = '1234567890006';
    INSERT INTO Evidencija (polaznik_id, idCasa, ocena, prisustvo) VALUES (v_polaznik_id, 'C002', 3, 0);
  END;

  COMMIT;
END;
/

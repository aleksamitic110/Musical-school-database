-- Reset podataka (brisanje u ispravnom redosledu zbog FK)
DELETE FROM Polaganje;
DELETE FROM Komisija;
DELETE FROM Ispit;
DELETE FROM Evidencija;
DELETE FROM Cas;
DELETE FROM Pohadja;
DELETE FROM KursInstrumentalni;
DELETE FROM KursVokalni;
DELETE FROM KursTeorijski;
DELETE FROM Kurs;
DELETE FROM Ucionica;
DELETE FROM Filijala;
DELETE FROM Stalni;
DELETE FROM Honorarni;
DELETE FROM Nastavnik;
DELETE FROM Odrasli;
DELETE FROM Dete;
DELETE FROM Polaznik;
DELETE FROM Staratelj;
DELETE FROM Telefon;
DELETE FROM Osoba;

-- Osoba
INSERT INTO Osoba VALUES 
('1234567890001', 'Ana', 'Anić', 'Beogradska 1', 'ana@example.com'),
('1234567890002', 'Marko', 'Marić', 'Novosadska 2', 'marko@example.com'),
('1234567890003', 'Jelena', 'Jelić', 'Zrenjaninska 3', 'jelena@example.com'),
('1234567890004', 'Petar', 'Petrović', 'Niska 4', 'petar@example.com'),
('1234567890005', 'Ivana', 'Ivić', 'Sarajevska 5', 'ivana@example.com'),
('1234567890006', 'Nikola', 'Nikolić', 'Zagrebačka 6', 'nikola@example.com'),
('1234567890007', 'Milica', 'Milić', 'Užička 7', 'milica@example.com'),
('1234567890008', 'Luka', 'Lukić', 'Niška 8', 'luka@example.com'),
('1234567890009', 'Sara', 'Sarić', 'Požeška 9', 'sara@example.com'),
('1234567890010', 'Milan', 'Milićević', 'Dunavska 10', 'milan@example.com');

-- Telefon
INSERT INTO Telefon VALUES
('0601234561', '1234567890001'),
('0601234562', '1234567890002'),
('0601234563', '1234567890003'),
('0601234564', '1234567890004'),
('0601234565', '1234567890005'),
('0601234566', '1234567890006'),
('0601234567', '1234567890007'),
('0601234568', '1234567890008'),
('0601234569', '1234567890009'),
('0601234570', '1234567890010');

-- Staratelj
INSERT INTO Staratelj VALUES
('1234567890001'),
('1234567890002'),
('1234567890003');

-- Polaznik
INSERT INTO Polaznik VALUES
('1234567890004'),
('1234567890005'),
('1234567890006'),
('1234567890007'),
('1234567890008'),
('1234567890009'),
('1234567890010');

-- Dete
INSERT INTO Dete VALUES
('1234567890004', '2012-04-12', 'DOS001', '1234567890001'),
('1234567890005', '2011-05-13', 'DOS002', '1234567890002'),
('1234567890006', '2010-06-14', 'DOS003', '1234567890003');

-- Odrasli
INSERT INTO Odrasli VALUES
('1234567890007', 'Programer'),
('1234567890008', 'Profesor'),
('1234567890009', 'Muzičar'),
('1234567890010', 'Novinar');

-- Nastavnik
INSERT INTO Nastavnik VALUES
('1234567890001', 'Master muzike', '2018-09-01'),
('1234567890002', 'Bachelor muzike', '2019-10-15'),
('1234567890003', 'Doktor umetnosti', '2020-01-10');

-- Honorarni
INSERT INTO Honorarni VALUES
('1234567890002', 'H001', 20, '2025-12-31');

-- Stalni
INSERT INTO Stalni VALUES
('1234567890001', NULL, '08:00-16:00', 1),
('1234567890003', '1234567890001', '09:00-17:00', 0);

-- Filijala
INSERT INTO Filijala VALUES
('F001', 'Kralja Petra 1', '08:00-20:00', 'osnovna', 100),
('F002', 'Bulevar 2', '09:00-21:00', 'napredna', 150);

-- Ucionica
INSERT INTO Ucionica VALUES
('U001', 'F001', '101A', 20),
('U002', 'F001', '102B', 30),
('U003', 'F002', '201', 25),
('U004', 'F002', '202', 35);

-- Kurs
INSERT INTO Kurs VALUES
('K001', 'F001', '1234567890001', 'Gitara za početnike', 'pocetni', 'individualna'),
('K002', 'F001', '1234567890002', 'Klavir za napredne', 'napredni', 'grupna'),
('K003', 'F002', '1234567890003', 'Teorija muzike', 'srednji', 'grupna');

-- KursInstrumentalni
INSERT INTO KursInstrumentalni VALUES
('K001', 'gitara'),
('K002', 'klavir');

-- KursVokalni
INSERT INTO KursVokalni VALUES
('K003', 'horsko');

-- KursTeorijski
INSERT INTO KursTeorijski VALUES
('K003', 'Harmonija i kontrapunkt');

-- Cas
INSERT INTO Cas VALUES
('C001', 'K001', 'U001', '2025-07-15', '10:00:00', 'Akordi'),
('C002', 'K002', 'U002', '2025-07-16', '11:00:00', 'Skale'),
('C003', 'K003', 'U003', '2025-07-17', '12:00:00', 'Teorija I');

-- Evidencija
INSERT INTO Evidencija VALUES
('1234567890004', 'C001', 5, 1),
('1234567890005', 'C001', 4, 1),
('1234567890006', 'C002', 3, 0);

-- Pohadja
INSERT INTO Pohadja VALUES
('1234567890004', 'K001'),
('1234567890005', 'K001'),
('1234567890006', 'K002'),
('1234567890007', 'K003');

-- Ispit
INSERT INTO Ispit VALUES
('I001', 'K001', '2025-08-01'),
('I002', 'K002', '2025-08-02');

-- Komisija
INSERT INTO Komisija VALUES
('1234567890001', 'I001'),
('1234567890002', 'I002');

-- Polaganje
INSERT INTO Polaganje VALUES
('1234567890004', 'I001', 5, 1),
('1234567890005', 'I001', 4, 1),
('1234567890006', 'I002', 3, 0);

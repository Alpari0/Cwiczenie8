
    public enum plec { mezczyzna, kobieta, inne };

    public struct Student
    {
        public string nazwisko;
        public int nrAlbumu;
        public double stopien;
        public plec plec;

        public Student(string nazwisko, int nrAlbumu, double stopien, plec plec)
        {
            this.nazwisko = nazwisko;
            this.nrAlbumu = nrAlbumu;
            this.stopien = stopien;
            this.plec = plec;
        }
    }

    class Program
    {
        static void uzupelnijStudent(ref Student student, string nazwisko, int nrAlbumu, double stopien, plec plec)
        {
            student.nazwisko = nazwisko;
            student.nrAlbumu = nrAlbumu;
            student.plec = plec;

            if (stopien < 2.0)
                student.stopien = 2.0;
            else if (stopien > 5.0)
                student.stopien = 5.0;
            else
                student.stopien = stopien;
        }

        static double srednistopien(Student[] studenci)
        {
            double sum = 0;
            foreach (var student in studenci)
                sum += student.stopien;

            return sum / studenci.Length;
        }

        static void studentWyswietlanie(Student student)
        {
            Console.WriteLine("{0} {1} {2} {3}", student.nazwisko, student.nrAlbumu, student.stopien, student.plec);
        }

        static void Main(string[] args)
        {
            Student[] studenci = new Student[5];

            uzupelnijStudent(ref studenci[0], "Kowalski", 12345, 4.5, plec.mezczyzna);
            uzupelnijStudent(ref studenci[1], "Nowak", 23456, 3.5, plec.kobieta);
            uzupelnijStudent(ref studenci[2], "Wiśniewski", 34567, 4.0, plec.mezczyzna);
            uzupelnijStudent(ref studenci[3], "Wójcik", 45678, 5.5, plec.kobieta);
            uzupelnijStudent(ref studenci[4], "Kowalczyk", 56789, 2.5, plec.inne);

            foreach (var student in studenci)
                studentWyswietlanie(student);

            Console.WriteLine("sredni stopien: {0}", srednistopien(studenci));
        }
    }

namespace ConsoleApp200
{
    internal class Doctor
    {

        private int doctorID;
        private String doctorName;

        public int DoctorID
        {
            get { return doctorID; }
            set { if (value > 0) { doctorID = value; } else { doctorID = 100; } }

        }

        public String DoctorName
        {
            get { return doctorName; }
            set { if (value != null) { doctorName = value; } else { Console.WriteLine("vot a valid name"); } }

        }


        public Doctor(int ID, String name)
        {
            doctorID = ID;
            doctorName = name;

        }

        public Doctor()
        {


        }

        public override string? ToString()
        {
            return $" Docter ID : {DoctorID}, Doctor Name: {DoctorName}";
        }
    }

    internal class Patient : Doctor
    {

        private int patientID;
        private String patientName;
        private int patientAge;
        private int doctorID;

        public int PatientID
        {
            get { return patientID; }

            set
            {

                if (value > 0) { patientID = value; } else { patientID = 0; }

            }

        }

        public String PatientName
        {
            get { return patientName; }
            set
            {
                if (value != null) { patientName = value; }
                else { patientName = "a"; }
            }
        }


        public int PatientAge
        {
            get { return patientAge; }
            set { if (patientAge > 18) { patientAge = value; } else { Console.WriteLine("not a valid age"); } }
        }

        public int DoctorID
        {
            get { return DoctorID; }
            set { if (DoctorID > 0) { DoctorID = value; } else { Console.WriteLine("not a valid id"); } }
        }


        public Patient(int patiId, String name, int age,int id)
        {

            patientID = patiId;
            patientName = name;
            patientAge = age;
            doctorID = id;

        }
        public Patient() { }

        public override string? ToString()
        {
            return $"patientID :{patientID} ,patientName :{patientName} ,patientAge :{patientAge}, doctorID :{doctorID}";
        }
    }

    internal class Mainclass : Patient
    {
        static void Main(string[] args)
        {

            List<Patient> patients = new List<Patient>();
            patients.Add(new Patient(100, "sham", 20,100));
            patients.Add(new Patient(101, "ram", 21,200));
            patients.Add(new Patient(102, "sunder", 20,300));
            patients.Add(new Patient(103, "mohan", 25,400));
            patients.Add(new Patient(104, "pratik", 30,500));


            List<Doctor> doctors = new List<Doctor>();
            doctors.Add(new Doctor(200, "pratik"));
            doctors.Add(new Doctor(300, "atik"));
            doctors.Add(new Doctor(400, "pravin"));
            doctors.Add(new Doctor(500, "ram"));
            doctors.Add(new Doctor(600, "sanny"));
            doctors.Add(new Doctor(700, "om"));
            doctors.Add(new Doctor(800, "pravin"));


            //first 
            var doc = from emp in doctors select emp;
            foreach (var doctor in doc)
            {
                Console.WriteLine(doctor);
            }


            //second
            var pat = from emp in patients select emp;
            foreach (var patin in pat)
            {
                Console.WriteLine(patin);
            }


            //third
            var patient = from emp in patients select new { emp.PatientName, emp.PatientID };
            foreach (Patient p in patients)
            {
                Console.WriteLine(p.PatientName);
                Console.WriteLine(p.PatientID);
            }

            //fourth
            var p2 = from emp in patients where emp.PatientAge > 40 select emp;
            foreach (Patient p in p2)
            {
                Console.WriteLine(p);
            }

            //five
            var p4 = from emp in patients where emp.PatientAge > 20 && emp.PatientAge < 40 select emp;
            foreach (Patient p in p4)
            {
                Console.WriteLine(p);


            }


            //six 
            var p6=from emp in patients orderby emp.PatientName descending select emp;
            foreach (Patient p in p6)
            {
                Console.WriteLine(p);


            }

            //seven
            var join1 = from emp in patients join emp1 in doctors on emp.DoctorID equals emp1.DoctorID select emp;
            foreach (Patient p in join1)
            {
                Console.WriteLine(p);

            }

            //eight
            var join2 = from emp in patients join emp1 in doctors on emp.DoctorID equals emp1.DoctorID select emp1;
            foreach (Patient p in join2)
            {
                Console.WriteLine(p);

            }


            //nine
            var join3 = from emp in patients join emp1 in doctors on emp.DoctorID equals emp1.DoctorID  select new { emp.PatientName,emp.PatientID,emp1.DoctorName,emp1.DoctorID};

            var ob = new object[] { join3 };
            foreach (Patient p in ob)
            {
                Console.WriteLine(p.PatientName);
                Console.WriteLine(p.PatientID);
                Console.WriteLine(p.DoctorName);
                Console.WriteLine(p.DoctorID);

            }



        }
    }

}
using lec3;

// 1st way
var st = new Student();
st.FirstName = "John";
st.LastName = "Doe";
st.Grades = [4, 2, 3];
st.Grades = new List<double>();
st.Grades = new HashSet<double>();
double average = st.CalculateAverage();

// 2nd way
var studies = new Studies();
studies.Name = "IT";
double average2 = studies.CalculateStudentsAverage(st);

// The 1st way is better
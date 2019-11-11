[System.Serializable]
public class Person
{
    public string Name;
    public int Age;
    public string PhoneNumber;
    public string Email;
    public Score score;

    public Person(string name,int age,string phoneNumber,string email,Score score)
    {
        this.Name = name;
        this.Age = age;
        this.PhoneNumber = phoneNumber;
        this.Email = email;
        this.score = score;
    }
}

public class Score
{
    public int stageScore;
    public int attackScore;
    public int damageScore;
}

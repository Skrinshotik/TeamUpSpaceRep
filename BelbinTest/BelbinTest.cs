public class BilbinTestProcessor
{
    private Dictionary<string, string> _answers;

    public BilbinTestProcessor()
    {
        _answers = new Dictionary<string, string>();
    }

    public void ProcessAnswer(string question, string answer)
    {
        _answers[question] = answer;
    }

    public PersonalityType GetPersonalityType()
    {
        int a = 0, b = 0, c = 0, d = 0, e = 0, f = 0, g = 0, h = 0;

        foreach (var answer in _answers.Values)
        {
            switch (answer.ToUpper())
            {
                case "A":
                    a++;
                    break;
                case "B":
                    b++;
                    break;
                case "C":
                    c++;
                    break;
                case "D":
                    d++;
                    break;
                case "E":
                    e++;
                    break;
                case "F":
                    f++;
                    break;
                case "G":
                    g++;
                    break;
                case "H":
                    h++;
                    break;
                default:
                    throw new ArgumentException("Invalid answer option: " + answer);
            }
        }

        int max = Math.Max(Math.Max(Math.Max(a, b), Math.Max(c, d)), Math.Max(Math.Max(e, f), Math.Max(g, h)));

        if (max == a)
        {
            return PersonalityType.A;
        }
        else if (max == b)
        {
            return PersonalityType.B;
        }
        else if (max == c)
        {
            return PersonalityType.C;
        }
        else if (max == d)
        {
            return PersonalityType.D;
        }
        else if (max == e)
        {
            return PersonalityType.E;
        }
        else if (max == f)
        {
            return PersonalityType.F;
        }
        else if (max == g)
        {
            return PersonalityType.G;
        }
        else
        {
            return PersonalityType.H;
        }
    }
}

public enum PersonalityType
{
    A,
    B,
    C,
    D,
    E,
    F,
    G,
    H
}

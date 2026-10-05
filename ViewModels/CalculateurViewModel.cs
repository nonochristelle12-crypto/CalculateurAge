namespace CalculateurAge.ViewModels;

public class CalculateurViewModel : BaseViewModel
{
    private string _nom = "";
    private DateTime _dateNaissance = DateTime.Today.AddYears(-20);
    private string _resultat = "";
    private bool _resultatVisible;
    private string _signeAstrologique = "";
    private int _ageMois;
    private int _ageSemaines;
    private int _ageJours;
    private long _ageHeures;

    public string Nom
    {
        get => _nom;
        set
        {
            if (SetField(ref _nom, value))
                CalculerCommand.Rafraichir();
        }
    }

    public DateTime DateNaissance
    {
        get => _dateNaissance;
        set
        {
            if (SetField(ref _dateNaissance, value))
            {
                CalculerSigneAstrologique();
                CalculerAgeDetaille();
            }
        }
    }

    public string Resultat
    {
        get => _resultat;
        set => SetField(ref _resultat, value);
    }

    public bool ResultatVisible
    {
        get => _resultatVisible;
        set => SetField(ref _resultatVisible, value);
    }

    public string SigneAstrologique
    {
        get => _signeAstrologique;
        set => SetField(ref _signeAstrologique, value);
    }

    public int AgeMois
    {
        get => _ageMois;
        set => SetField(ref _ageMois, value);
    }

    public int AgeSemaines
    {
        get => _ageSemaines;
        set => SetField(ref _ageSemaines, value);
    }

    public int AgeJours
    {
        get => _ageJours;
        set => SetField(ref _ageJours, value);
    }

    public long AgeHeures
    {
        get => _ageHeures;
        set => SetField(ref _ageHeures, value);
    }

    public RelayCommand CalculerCommand { get; }

    public CalculateurViewModel()
    {
        CalculerCommand = new RelayCommand(
            Calculer,
            () => !string.IsNullOrWhiteSpace(Nom));
        CalculerSigneAstrologique();
        CalculerAgeDetaille();
    }

    private void Calculer()
    {
        int age = DateTime.Today.Year - DateNaissance.Year;
        if (DateNaissance.Date > DateTime.Today.AddYears(-age))
            age--;

        Resultat = $"{Nom}, vous avez {age} ans";
        ResultatVisible = true;
    }

    private void CalculerSigneAstrologique()
    {
        int mois = DateNaissance.Month;
        int jour = DateNaissance.Day;

        SigneAstrologique = (mois, jour) switch
        {
            (1, >= 20) or (2, <= 18) => "Verseau",
            (2, >= 19) or (3, <= 20) => "Poissons",
            (3, >= 21) or (4, <= 19) => "Belier",
            (4, >= 20) or (5, <= 20) => "Taureau",
            (5, >= 21) or (6, <= 20) => "Gemeaux",
            (6, >= 21) or (7, <= 22) => "Cancer",
            (7, >= 23) or (8, <= 22) => "Lion",
            (8, >= 23) or (9, <= 22) => "Vierge",
            (9, >= 23) or (10, <= 22) => "Balance",
            (10, >= 23) or (11, <= 21) => "Scorpion",
            (11, >= 22) or (12, <= 21) => "Sagittaire",
            (12, >= 22) or (1, <= 19) => "Capricorne",
            _ => ""
        };
    }

    private void CalculerAgeDetaille()
    {
        TimeSpan diff = DateTime.Today - DateNaissance;
        AgeJours = (int)diff.TotalDays;
        AgeHeures = (long)diff.TotalHours;
        AgeSemaines = AgeJours / 7;

        DateTime today = DateTime.Today;
        AgeMois = (today.Year - DateNaissance.Year) * 12 + today.Month - DateNaissance.Month;
        if (today.Day < DateNaissance.Day) AgeMois--;
    }
}

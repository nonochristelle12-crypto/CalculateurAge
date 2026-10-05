namespace CalculateurAge.ViewModels;

public class ResultatViewModel : BaseViewModel
{
    public string Nom => CalculateurViewModel.Instance.Nom;
    public int AgeAnnees => CalculateurViewModel.Instance.AgeAnnees;
    public int AgeMois => CalculateurViewModel.Instance.AgeMois;
    public int AgeSemaines => CalculateurViewModel.Instance.AgeSemaines;
    public int AgeJours => CalculateurViewModel.Instance.AgeJours;
    public long AgeHeures => CalculateurViewModel.Instance.AgeHeures;
    public string SigneAstrologique => CalculateurViewModel.Instance.SigneAstrologique;
    public double ProgressionVie => CalculateurViewModel.Instance.ProgressionVie;

    public RelayCommand RetourCommand { get; }

    public ResultatViewModel()
    {
        RetourCommand = new RelayCommand(async () =>
        {
            await Shell.Current.GoToAsync("..");
        });
    }
}

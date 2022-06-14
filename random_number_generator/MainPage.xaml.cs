namespace random_number_generator;
using CommunityToolkit.Maui;

public partial class MainPage : ContentPage
{
	int count = 0;

	public MainPage()
	{
		InitializeComponent();
	}

	private void OnGenerateClicked(object sender, EventArgs e)
	{
        int qtdNumbers = int.Parse(QtdNumbers.Text);
        int min = int.Parse(MinNumber.Text);
        int max = int.Parse(MaxNumber.Text);
        string final_result = "Falha ao gerar números";

        {
            List<int> response = new List<int>();
            Random rnd = new Random();

            int candidate = 0;
            int attempt = 0;
            bool stop = false;

            for (int i = 0; i < qtdNumbers; i++)
            {
                do
                {
                    candidate = rnd.Next(min, max);
                    attempt++;
                    if (attempt > 50)
                    {
                        stop = true;
                        break;
                    }
                }
                while (response.Contains(candidate));

                if (stop)
                {
                    break;
                }
                response.Add(candidate);
            }

            if (stop == false)
            {
                response.Sort();
                final_result = String.Join(" ", response);
            }
            ResultLabel.Text = $"{final_result}";

            SemanticScreenReader.Announce(GenerateBtn.Text);
        }
    }
}


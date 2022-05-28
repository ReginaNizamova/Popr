using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Poprygunchic
{
    public partial class Agents : Window
    {
        public Agents()
        {
            InitializeComponent();
            agentsListView.ItemsSource = PoprygunchicEntities.GetContext().Agents.ToList();
           
        }

        private List<string> SetLogoAgent()
        {
            var logo = PoprygunchicEntities.GetContext().Agents.ToList();
            List<string> pathLogo = new List<string>();

            for (int i = 0; i < logo.Count; i++)
            {
                if (logo[i].Logo == "отсутствует")
                    pathLogo.Add ("/Resources/picture.png");
                else
                    pathLogo.Add (@"\Resources" + logo[i].Logo);
            }

            return pathLogo;
        }
    }
}

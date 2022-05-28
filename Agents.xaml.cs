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

        //private void Pages()
        //{
        //    var agents = PoprygunchicEntities.GetContext().Agents.ToList();

        //    List<Agent> tenAgents = new List<Agent>();

        //    if (agents.Count > 10)
        //        tenAgents.Add(agents.Skip(10).ToList());
        //}
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Poprygunchic.Windows
{
    public partial class AddWindow : Window
    {
        Agent _currentAgent = new Agent();
        public AddWindow(Agent selectedAgent)
        {
            InitializeComponent();

            //List<string> sourceTypeAgents = new List<string>
            //{
            //   "МКК",
            //   "ОАО",
            //   "ООО",
            //   "ЗАО",
            //   "МФО",
            //   "ПАО"
            //};
            //type.ItemsSource = sourceTypeAgents;

            if (selectedAgent != null)
                _currentAgent = selectedAgent;

            DataContext = _currentAgent;

            type.ItemsSource = PoprygunchicEntities.GetContext().AgentTypes.ToList();

            //if (_currentAgent.Title == null)
            //    type.SelectedItem = _currentAgent.AgentType.Title;
            //else
            //    type.SelectedItem = sourceTypeAgents;
        }

        private void SaveButtonClick(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (_currentAgent.AgentType.Title == null)
                errors.AppendLine("  Тип агента");
            else if (string.IsNullOrEmpty(priority.Text))
                errors.AppendLine("  Приоритет");
            else if (string.IsNullOrEmpty(address.Text))
                errors.AppendLine("  Адрес");
            else if (string.IsNullOrEmpty(INN.Text))
                errors.AppendLine("  ИНН");
            else if (string.IsNullOrEmpty(KPP.Text))
                errors.AppendLine("  КПП");
            else if (string.IsNullOrEmpty(director.Text))
                errors.AppendLine("  Директор");
            else if (string.IsNullOrEmpty(phone.Text))
                errors.AppendLine("  Телефон");
            else if (string.IsNullOrEmpty(email.Text))
                errors.AppendLine("  Email");

            if (errors.Length > 0)
            {
                MessageBox.Show("Введите:" + errors.ToString());
                return;
            }

            if (_currentAgent.ID == 0)
                PoprygunchicEntities.GetContext().Agents.Add(_currentAgent);

            try
            {
                PoprygunchicEntities.GetContext().SaveChanges();
                MessageBox.Show("Данные успешно сохранены!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}

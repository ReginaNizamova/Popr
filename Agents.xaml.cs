using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace Poprygunchic
{
    public partial class Agents : Window
    {
        public Agents()
        {
            InitializeComponent();
            List<string> sourceSortComboBox = new List<string>
            {
               "Не сортировать",
               "Наименование (А-Я)",
               "Наименование (Я-А)",
               "Размер скидки (мин.-макс.)",
               "Размер скидки (макс.-мин.)",
               "Приоритет агента (мин.-макс.)",
               "Приоритет агента (макс.-мин.)"
            };
            List<string> sourceFilterComboBox = new List<string>
            {
               "Все типы",
               "МКК",
               "ОАО",
               "ООО",
               "ЗАО",
               "МФО",
               "ПАО"

            };

            agentsListView.ItemsSource = PoprygunchicEntities.GetContext().Agents.ToList();
            sortComboBox.ItemsSource = sourceSortComboBox;
            filterComboBox.ItemsSource = sourceFilterComboBox;
        }

        private void SortComboBoxSelectionChanged(object sender, SelectionChangedEventArgs e) //Сортировка
        {
            string comboBoxContent = sortComboBox.SelectedItem.ToString();

            switch (comboBoxContent)
            {
                case "Не сортировать":
                {
                    agentsListView.ItemsSource = PoprygunchicEntities.GetContext().Agents.ToList();
                    break;
                }

                case "Наименование (А-Я)":
                {
                    agentsListView.ItemsSource = PoprygunchicEntities.GetContext().Agents.OrderBy(x => x.Title).ToList();
                    break;
                }

                case "Наименование (Я-А)":
                {
                    agentsListView.ItemsSource = PoprygunchicEntities.GetContext().Agents.OrderByDescending(x => x.Title).ToList();
                    break;
                }

                case "Размер скидки (мин.-макс.)":
                {
                    agentsListView.ItemsSource = PoprygunchicEntities.GetContext().Agents.ToList().OrderBy(x => x.PersentCount).ToList();
                    break;
                }

                case "Размер скидки (макс.-мин.)":
                {
                    agentsListView.ItemsSource = PoprygunchicEntities.GetContext().Agents.ToList().OrderByDescending(x => x.PersentCount).ToList();
                    break;
                }

                case "Приоритет агента (мин.-макс.)":
                {
                    agentsListView.ItemsSource = PoprygunchicEntities.GetContext().Agents.OrderBy(x => x.Priority).ToList();
                    break;
                }

                case "Приоритет агента (макс.-мин.)":
                {
                    agentsListView.ItemsSource = PoprygunchicEntities.GetContext().Agents.OrderByDescending(x => x.Priority).ToList();
                    break;
                }
            }

        }

        private void FilterComboBoxSelectionChanged(object sender, SelectionChangedEventArgs e) //Фильтрация
        {
            string currentItem = filterComboBox.SelectedItem.ToString();

            if (currentItem == "Все типы")
                agentsListView.ItemsSource = PoprygunchicEntities.GetContext().Agents.ToList();
            else
                agentsListView.ItemsSource = PoprygunchicEntities.GetContext().Agents.Where(x => x.AgentType.Title.Contains(currentItem)).ToList();
        }

        private bool AgentSearch (object item) //Поиск
        {
            if (string.IsNullOrEmpty(searchTextBox.Text))
                return true;
            else
                return (item as Agent).Title.IndexOf(searchTextBox.Text, System.StringComparison.OrdinalIgnoreCase) > 0 ||
                       (item as Agent).Phone.IndexOf(searchTextBox.Text, System.StringComparison.OrdinalIgnoreCase) > 0 ||
                       (item as Agent).Email.IndexOf(searchTextBox.Text, System.StringComparison.OrdinalIgnoreCase) > 0;
        }

        private void SearchTextBoxTextChanged(object sender, TextChangedEventArgs e)
        {
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(agentsListView.ItemsSource);
            view.Filter = AgentSearch;
            CollectionViewSource.GetDefaultView(agentsListView.ItemsSource).Refresh();
        }   
    }
}

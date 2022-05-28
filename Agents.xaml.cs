using System;
using System.Collections.Generic;
using System.ComponentModel;
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

            agentsListView.ItemsSource = PoprygunchicEntities.GetContext().Agents.ToList();
            sortComboBox.ItemsSource = sourceSortComboBox;

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
                    agentsListView.ItemsSource = PoprygunchicEntities.GetContext().Agents.OrderBy(x => x.PersentCount).ToList();
                    break;
                }

                case "Размер скидки (макс.-мин.)":
                {
                    agentsListView.ItemsSource = PoprygunchicEntities.GetContext().Agents.OrderByDescending(x => x.PersentCount).ToList();
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
    }
}

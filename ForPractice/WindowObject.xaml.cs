using ForPractice.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ForPractice
{
    /// <summary>
    /// Логика взаимодействия для WindowObject.xaml
    /// </summary>
    /// 
    
    public partial class WindowObject : Window
    {
        private ObjectRepository repositoryOb = new ObjectRepository();
        public WindowObject()
        {
            InitializeComponent();
            var objects = new ObjectRepository().GetAll();
            ObjectsDb.ItemsSource = objects;

        }

        private void addNew_Click(object sender, RoutedEventArgs e)
        {
            AddObject addObject = new AddObject(null);
            addObject.Show();
            this.Hide();
            
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            var index = (Object)ObjectsDb.SelectedItem;
            if (index != null)
            {
                if (MessageBox.Show("Точно хотите удалить?", "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    repositoryOb.Delete(index.ObjectId);
                    repositoryOb.Save();
                    MessageBox.Show("Успешно");
                }
            }
            else
            {
                MessageBox.Show("Выберите объект для удаления");
            }            
            ObjectsDb.ItemsSource = repositoryOb.GetAll();
        }

        private void updateButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Hide();
        }

        private void editOb_Click(object sender, RoutedEventArgs e)
        {
            var index = (Object)ObjectsDb.SelectedItem;
            if (index != null)
            {
                AddObject addObject = new AddObject(index);
                addObject.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Выберите объект для редактирования");
            }


        }
    }
}

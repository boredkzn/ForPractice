using ForPractice.Repository;
using System;
using System.Collections.Generic;
using System.Data;
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
    /// Логика взаимодействия для AddObject.xaml
    /// </summary>
    public partial class AddObject : Window
    {
        Object ob;
        public AddObject(Object obj)
        {
            InitializeComponent();
            var owners = new OwnerRepository().GetAll();
            OwnersComboBox.ItemsSource = owners;
            OwnersComboBox.DisplayMemberPath = "FIO";
            OwnersComboBox.SelectedValuePath = "OwnerId";
            ob = obj;
            if(ob != null)
            {
                NameBox.Text = obj.Name;
                TypeBox.Text = obj.Type;
                AdressBox.Text = obj.Adress;
                CountSeatsBox.Text = obj.CountSeats.ToString();           
                DateBoxTime.SelectedDate = obj.DateOpen;
                
            }
        }

       
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            WindowObject windowObject = new WindowObject();
            windowObject.Show();
            this.Hide();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
          
            ObjectRepository objectRepository = new ObjectRepository();
            var selectedIdOwner = OwnersComboBox.SelectedValue;
            var isOpen = OpenedBox.SelectedValue == "Да" ? true : false;
            if (ob != null)
            {
                
                ob.Name = NameBox.Text;
                ob.Type = TypeBox.Text;
                ob.Adress = AdressBox.Text;
                ob.CountSeats = Convert.ToInt32(CountSeatsBox.Text);
                if(isOpen)
                    ob.Opened_Closed = isOpen;
                ob.DateOpen = DateBoxTime.SelectedDate.Value;
                if(selectedIdOwner != null) 
                    ob.OwnerId = Convert.ToInt32(selectedIdOwner);
                

                objectRepository.Save();
            }
            else
            {
                var newObject = new Object()
                {
                    ObjectId = objectRepository.GetMaxNumber() + 1,
                    Name = NameBox.Text,
                    Type = TypeBox.Text,
                    Adress = AdressBox.Text,
                    CountSeats = Convert.ToInt32(CountSeatsBox.Text),
                    Opened_Closed = isOpen,
                    DateOpen = DateBoxTime.SelectedDate.Value,
                    OwnerId = Convert.ToInt32(selectedIdOwner)
                };
                objectRepository.Create(newObject);
            }
            objectRepository.Save();
            MessageBox.Show("Успешно");
            WindowObject windowObject = new WindowObject();
            windowObject.Show();
            this.Hide();

        }
    }
}

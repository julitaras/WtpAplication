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

namespace WpfAplication
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        private void ok_click_button(object sender, RoutedEventArgs e)
        {
            //Obtenemos los datos introducimos
            string user_introducido = TextBox_Usuario.Text;
            string password_introducida = TextBox_Password.Text;

            //Utilizamos el modelo de entidades
            databasewpfaplicationEntities modeloentities = new databasewpfaplicationEntities();

            //Verificamos que existan los datos en bd
            User user = modeloentities.Users.SingleOrDefault(us => us.username.Equals(user_introducido));

            if (user != null)
            {
                //Verficamos las contraseñas
                if (user.password.Equals(password_introducida))
                {
                    //Abrimos la nueva ventana
                    MainWindow mainwindow = new MainWindow();
                    mainwindow.Show();
                    this.Close();
                }
                else
                {
                    //Las contraseñas contrasñas no coinciden 
                    TextBox_Password.Background = Brushes.Red;
                    TextBlock_Error.Text = "La contraseña no es correcta";
                    TextBox_Password.Clear();
                }
            }
            //Ellipse usuario no existe
            else
            {
                TextBox_Usuario.Background = Brushes.Red;
                TextBlock_Error.Text = "El usuario introducido no es correcto";
                TextBox_Usuario.Clear();
                TextBox_Password.Clear();
            }


            //MainWindow mainwindow = new MainWindow();
            //mainwindow.Show();
            //this.Close();
        }
    }
}

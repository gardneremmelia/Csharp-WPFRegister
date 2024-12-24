/*
 * Emmelia Gardner
 * IT-230
 * Final Project Part 2
 */
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPFRegisterStudent
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Course choice;
        int totalCreditHours = 0; // Initialize variable for storing credit hours across button clicks

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            Course course1 = new Course("IT 145");
            Course course2 = new Course("IT 200");
            Course course3 = new Course("IT 201");
            Course course4 = new Course("IT 270");
            Course course5 = new Course("IT 315");
            Course course6 = new Course("IT 328");
            Course course7 = new Course("IT 330");


            this.comboBox.Items.Add(course1);
            this.comboBox.Items.Add(course2);
            this.comboBox.Items.Add(course3);
            this.comboBox.Items.Add(course4);
            this.comboBox.Items.Add(course5);
            this.comboBox.Items.Add(course6);
            this.comboBox.Items.Add(course7);


            this.textBox.Text = "";
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            choice = (Course)(this.comboBox.SelectedItem);

            if (choice == null) // Check if user selected a course
            {
                label3.Content = "Please select a course.";
                MessageBox.Show("Please select a course.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (choice.IsRegisteredAlready()) // Check if the selected course has already been registered for
            {
                label3.Content = $"You are already registered for {choice.getName()}.";
                MessageBox.Show($"You are already registered for {choice.getName()}.", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (totalCreditHours >= 9) // Check if user has registered for the maximum allowed credits
            {
                label3.Content = "You are already registered for the maximum allowed credit hours.";
                MessageBox.Show("You are already registered for the maximum allowed credit hours.", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            // Register for course successfully
            choice.SetToRegistered();
            totalCreditHours += 3;
            this.listBox.Items.Add(choice.getName());
            this.textBox.Text = totalCreditHours.ToString();
            label3.Content = $"You have registered for {choice.getName()}.";
            MessageBox.Show($"You have registered for {choice.getName()}.");
        }
    }
}

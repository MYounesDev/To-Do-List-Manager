using System;
using System.Collections.Generic;
using System.Windows;
using To_Do_List_Manager.Entities;
        
namespace To_Do_List_Manager
{
        
    public partial class MainWindow : Window
    {
        
        List <int> tasksIds = new List <int>();
        
        public MainWindow()
        {
            InitializeComponent();
            List <CurrentTask> currentTasks = CurrentTask.GetCurrentTasks();
            foreach (var task in currentTasks)
            {
                tasksIds.Add(task.CurrentTaskId);
                tasksListBox.Items.Add(task.TaskDiscription);
            }
        }


        private void addTaskBtn_Click(object sender, RoutedEventArgs e)
        {
            String task = taskEntry.Text;

            if (task != String.Empty)
                tasksListBox.Items.Add(task);

            taskEntry.Clear();

            int CurretTaskId = CurrentTask.AddCurrentTask(task);
            tasksIds.Add(CurretTaskId);


        }


        private void deleteTaskBtn_Click(object sender, RoutedEventArgs e)
        {
            if (tasksListBox.SelectedItem != null)
            {
                int selectedIndex = tasksListBox.SelectedIndex;

                int CurretTaskId = tasksIds[selectedIndex];
                CurrentTask.DeleteCurrentTask(CurretTaskId);

                tasksListBox.Items.RemoveAt(selectedIndex);
            }
        }


        private void deleteAllbtn_Click(object sender, RoutedEventArgs e)
        {
            tasksListBox.Items.Clear();
            CurrentTask.DeleteAllCurrentTask();
            tasksIds.Clear();
        }


        private void exitBtn_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }


    }
}

using BL;
using BL.Commands;
using BL.Model;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using UI.Pages;
using UI.Utility;

namespace UI
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var s = Select.Subjects();
        }

        private void btnFillingFileds_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new FillingFields();
        }

        private void btnInputSyllabus_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new Syllabus();
        }

        private void MainButtonsActivityOff()
        {
            btnFillingFileds.IsEnabled = false;
            btnInputSyllabus.IsEnabled = false;
            btnOptimalityCriterions.IsEnabled = false;
            btnMakeSchedule.IsEnabled = false;
        }

        private void MainButtonsActivityOn()
        {
            btnFillingFileds.IsEnabled = true;
            btnInputSyllabus.IsEnabled = true;
            btnOptimalityCriterions.IsEnabled = true;
            btnMakeSchedule.IsEnabled = true;
        }

        private async void btnMakeSchedule_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new SchedulePage();
            MainButtonsActivityOff();
            ProgressBarHelper.ProgressBarEvent(10);

            DeleteOldData();

            try
            {
                Task task = Task.Run(() => MakeSchedule());
                await task.ContinueWith(x => MainButtonsActivityOn());
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
                MainButtonsActivityOn();
            }
        }

        private void MakeSchedule()
        {
            ProgressBarHelper.ProgressBarEvent(20);
            ScheduleFrame.MakeScheduleFrame();
            var schedule = new Schedule();
            schedule.Create();
            WordTable.Lesson(schedule.MostOptimalitySchedule, schedule.SubgroupsInLessons);
        }

        private static void DeleteOldData()
        {
            foreach (var lessonFrame in Select.LessonFrames())
                Delete<LessonFrame>.DeleteFromTable(lessonFrame);
            foreach (var sub in Select.SubgroupsInLessonFrames())
                Delete<SubgroupsInLessonFrames>.DeleteFromTable(sub);

            foreach (var lesson in Select.Lessons())
                Delete<Lesson>.DeleteFromTable(lesson);
            foreach (var sub in Select.SubgroupsInLessons())
                Delete<SubgroupsInLessons>.DeleteFromTable(sub);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            OnStart.Start();
        }

        private void btnOptimalityCriterions_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new OptimalityCriterions();
        }
    }
}
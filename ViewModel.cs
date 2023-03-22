using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Diagnostics;

namespace DataBindingTest
{
    public partial class ViewModel : ObservableObject
    { 
        [ObservableProperty]
        public int subjectIndex = -1;
        [ObservableProperty]
        public SubjectClass subject;
        public List<SubjectClass> SubjectList { get; set; }

        public ViewModel()
        {
            SubjectList = new List<SubjectClass>()
            {
                new SubjectClass { Id = 0, Name = "Login", Picture = ReadImageFile("login_services.png") },
                new SubjectClass { Id = 1, Name = "Boat", Picture = ReadImageFile("sailboat.png") },
                new SubjectClass { Id = 2, Name = "Marina", Picture = ReadImageFile("marina.png") },
            };
            OnPropertyChanged(nameof(SubjectList));
        }

        public static ImageSource ReadImageFile(string fileName)
        {
            var image = new Image
            {
                Source = ImageSource.FromResource("DataBindingTest.Resources.Images." + fileName)
            };
            return image.Source;
        }

        [RelayCommand]
        public void SubjectPickerChanged()
        {
            if (MainThread.IsMainThread)
                Debug.WriteLine("It is running on the main thread.");

            Subject = SubjectList[SubjectIndex];
        }
    }
}
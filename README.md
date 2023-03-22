The purpose of this repo is to demonstrate an error displaying images on Android.

Error: Android.Util.AndroidRuntimeException: Only the original thread that created a view hierarchy can touch its views.

Desired functionality 
An app that based on a selection made through a picker list, displays the object information - including the object image – of the selected object. 
(Essential code is included in this text below issue descriptions)

Environment
•	MAUI .NET 7
•	Visual studio 17.5.3
•	Android emulator: Pixel 5 – API 32 (12.1 – API 32) & Pixel 5 – API 33 (13.0 – API 33)
•	Windows Machine

Issues
1)	Error picking a subject for the 2nd time only:
Picking an item for the 2nd time the image does not show and the below error message is generated.
OBS: To reproduce you need to pick a subject and then pick a different subject from the picker list.
When a 3rd subject is selected everything works fine (as well as for the 4th, 5th, and so on) The error only occur for the 2nd selection! (In a few tests, this error occurs after 3 selections not 2, but predominantly after 2 selections).
It is unclear to me which code executed in another thread but the UI thread creates the error. I have included a check on the thread which indicated the code is executed in the UI thread - as well as tried to include the code in a MainThread.BeginInvokeOnMainThread without any impact on the error.
As this error seems to occur outside the code I have written I’m in the dark as to a solution. Any help is highly appreciated.

[0:] Microsoft.Maui.StreamImageSourceService: Warning: Unable to load image stream.

Android.Util.AndroidRuntimeException: Only the original thread that created a view hierarchy can touch its views.
   at Java.Interop.JniEnvironment.StaticMethods.CallStaticVoidMethod(JniObjectReference type, JniMethodInfo method, JniArgumentValue* args) in /Users/runner/work/1/s/xamarin-android/external/Java.Interop/src/Java.Interop/obj/Release/net7.0/JniEnvironment.g.cs:line 13250
   at Java.Interop.JniPeerMembers.JniStaticMethods.InvokeVoidMethod(String encodedMember, JniArgumentValue* parameters) in /Users/runner/work/1/s/xamarin-android/external/Java.Interop/src/Java.Interop/Java.Interop/JniPeerMembers.JniStaticMethods.cs:line 97
   at Microsoft.Maui.PlatformInterop.LoadImageFromStream(ImageView imageView, Stream inputStream, IImageLoaderCallback callback) in D:\a\_work\1\s\src\Core\src\obj\Release
et7.0-android\generated\src\Microsoft.Maui.PlatformInterop.cs:line 443
   at Microsoft.Maui.StreamImageSourceService.LoadDrawableAsync(IImageSource imageSource, ImageView imageView, CancellationToken cancellationToken) in D:\a\_work\1\s\src\Core\src\ImageSources\StreamImageSourceService\StreamImageSourceService.Android.cs:line 28
  --- End of managed Android.Util.AndroidRuntimeException stack trace ---
android.view.ViewRootImpl$CalledFromWrongThreadException: Only the original thread that created a view hierarchy can touch its views.
	at android.view.ViewRootImpl.checkThread(ViewRootImpl.java:9461)
	at android.view.ViewRootImpl.requestLayout(ViewRootImpl.java:1825)
	at android.view.View.requestLayout(View.java:25757)
	at android.view.View.requestLayout(View.java:25757)
	at android.view.View.requestLayout(View.java:25757)
	at android.view.View.requestLayout(View.java:25757)
	at android.view.View.requestLayout(View.java:25757)
	at android.view.View.requestLayout(View.java:25757)
	at android.view.View.requestLayout(View.java:25757)
	at androidx.drawerlayout.widget.DrawerLayout.requestLayout(DrawerLayout.java:1353)
	at android.view.View.requestLayout(View.java:25757)
	at android.view.View.requestLayout(View.java:25757)
	at android.view.View.requestLayout(View.java:25757)
	at android.view.View.requestLayout(View.java:25757)
	at android.view.View.requestLayout(View.java:25757)
	at android.view.View.requestLayout(View.java:25757)
	at androidx.recyclerview.widget.RecyclerView.requestLayout(RecyclerView.java:4586)
	at android.view.View.requestLayout(View.java:25757)
	at android.view.View.requestLayout(View.java:25757)
	at android.view.View.requestLayout(View.java:25757)
	at android.view.View.requestLayout(View.java:25757)
	at androidx.core.widget.NestedScrollView.requestLayout(NestedScrollView.java:2075)
	at android.view.View.requestLayout(View.java:25757)
	at android.view.View.requestLayout(View.java:25757)
	at android.view.View.requestLayout(View.java:25757)
	at android.widget.ImageView.setImageDrawable(ImageView.java:601)
	at androidx.appcompat.widget.AppCompatImageView.setImageDrawable(AppCompatImageView.java:112)
	at com.microsoft.maui.glide.MauiCustomViewTarget.onResourceCleared(MauiCustomViewTarget.java:30)
	at com.bumptech.glide.request.target.CustomViewTarget.onLoadCleared(CustomViewTarget.java:210)
	at com.bumptech.glide.request.SingleRequest.clear(SingleRequest.java:337)
	at com.bumptech.glide.request.ErrorRequestCoordinator.clear(ErrorRequestCoordinator.java:48)
	at com.bumptech.glide.manager.RequestTracker.clearAndRemove(RequestTracker.java:70)
	at com.bumptech.glide.RequestManager.untrack(RequestManager.java:660)
	at com.bumptech.glide.Glide.removeFromManagers(Glide.java:913)
	at com.bumptech.glide.RequestManager.untrackOrDelegate(RequestManager.java:647)
	at com.bumptech.glide.RequestManager.clear(RequestManager.java:624)
	at com.bumptech.glide.RequestBuilder.into(RequestBuilder.java:811)
	at com.bumptech.glide.RequestBuilder.into(RequestBuilder.java:780)
	at com.bumptech.glide.RequestBuilder.into(RequestBuilder.java:771)
	at com.microsoft.maui.PlatformInterop.prepare(PlatformInterop.java:229)
	at com.microsoft.maui.PlatformInterop.loadInto(PlatformInterop.java:234)
	at com.microsoft.maui.PlatformInterop.loadImageFromStream(PlatformInterop.java:265)

  --- End of managed Android.Util.AndroidRuntimeException stack trace ---
android.view.ViewRootImpl$CalledFromWrongThreadException: Only the original thread that created a view hierarchy can touch its views.
	at android.view.ViewRootImpl.checkThread(ViewRootImpl.java:9461)
	at android.view.ViewRootImpl.requestLayout(ViewRootImpl.java:1825)
	at android.view.View.requestLayout(View.java:25757)
	at android.view.View.requestLayout(View.java:25757)
	at android.view.View.requestLayout(View.java:25757)
	at android.view.View.requestLayout(View.java:25757)
	at android.view.View.requestLayout(View.java:25757)
	at android.view.View.requestLayout(View.java:25757)
	at android.view.View.requestLayout(View.java:25757)
	at androidx.drawerlayout.widget.DrawerLayout.requestLayout(DrawerLayout.java:1353)
	at android.view.View.requestLayout(View.java:25757)
	at android.view.View.requestLayout(View.java:25757)
	at android.view.View.requestLayout(View.java:25757)
	at android.view.View.requestLayout(View.java:25757)
	at android.view.View.requestLayout(View.java:25757)
	at android.view.View.requestLayout(View.java:25757)
	at androidx.recyclerview.widget.RecyclerView.requestLayout(RecyclerView.java:4586)
	at android.view.View.requestLayout(View.java:25757)
	at android.view.View.requestLayout(View.java:25757)
	at android.view.View.requestLayout(View.java:25757)
	at android.view.View.requestLayout(View.java:25757)
	at androidx.core.widget.NestedScrollView.requestLayout(NestedScrollView.java:2075)
	at android.view.View.requestLayout(View.java:25757)
	at android.view.View.requestLayout(View.java:25757)
	at android.view.View.requestLayout(View.java:25757)
	at android.widget.ImageView.setImageDrawable(ImageView.java:601)
	at androidx.appcompat.widget.AppCompatImageView.setImageDrawable(AppCompatImageView.java:112)
	at com.microsoft.maui.glide.MauiCustomViewTarget.onResourceCleared(MauiCustomViewTarget.java:30)
	at com.bumptech.glide.request.target.CustomViewTarget.onLoadCleared(CustomViewTarget.java:210)
	at com.bumptech.glide.request.SingleRequest.clear(SingleRequest.java:337)
	at com.bumptech.glide.request.ErrorRequestCoordinator.clear(ErrorRequestCoordinator.java:48)
	at com.bumptech.glide.manager.RequestTracker.clearAndRemove(RequestTracker.java:70)
	at com.bumptech.glide.RequestManager.untrack(RequestManager.java:660)
	at com.bumptech.glide.Glide.removeFromManagers(Glide.java:913)
	at com.bumptech.glide.RequestManager.untrackOrDelegate(RequestManager.java:647)
	at com.bumptech.glide.RequestManager.clear(RequestManager.java:624)
	at com.bumptech.glide.RequestBuilder.into(RequestBuilder.java:811)
	at com.bumptech.glide.RequestBuilder.into(RequestBuilder.java:780)
	at com.bumptech.glide.RequestBuilder.into(RequestBuilder.java:771)
	at com.microsoft.maui.PlatformInterop.prepare(PlatformInterop.java:229)
	at com.microsoft.maui.PlatformInterop.loadInto(PlatformInterop.java:234)
	at com.microsoft.maui.PlatformInterop.loadImageFromStream(PlatformInterop.java:265)

2)	Different image is shown
At random, a subject can be selected and the subject ID and name is correct however, a different Image is shown. I cannot find a pattern to this error. But try a few times and the error will occur.

Observation
None of the above issues exist if the app is compiled to windows!

App code

Subject class:
    public partial class SubjectClass
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ImageSource Picture { get; set; }
    }
    
Viewmodel:
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
                new SubjectClass { Id = 1, Name = "Boat", Picture =	ReadImageFile("sailboat.png") },
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

View:
<?xml version="1.0" encoding="utf-8" ?>
<ContentPage xmlns="http://schemas.microsoft.com/dotnet/2021/maui"
      xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
      xmlns:toolkit="http://schemas.microsoft.com/dotnet/2022/maui/toolki"
      xmlns:model="clr-namespace:DataBindingTest"
      xmlns:viewmodel="clr-namespace:DataBindingTest"
      x:DataType="viewmodel:ViewModel"
      x:Class="DataBindingTest.View">

  <ScrollView>
    <VerticalStackLayout Padding="30">
      <Label Text="Testing data binding to Image!"
      FontSize="Medium" HorizontalOptions="Center" />

      <Picker Title="Pick from list" 
        ItemsSource="{Binding SubjectList}" ItemDisplayBinding="{Binding 'Name'}" 
            SelectedIndex ="{Binding SubjectIndex, Mode=TwoWay}" 
            TitleColor="DarkGray" TextColor="Black" 
            HeightRequest="80" WidthRequest="200" 
            HorizontalOptions="Start" VerticalOptions="Center" >
        <Picker.Behaviors>
          <toolkit:EventToCommandBehavior ="SelectedIndexChanged" Command="{Binding SubjectPickerChangedCommand}"/>
        </Picker.Behaviors>
      </Picker>

      <Label Text="Subject Id is:" Margin="0,10,0,0"/>
      <Label Text="{Binding Subject.Id}" />

      <Label Text="Subject Name is:" Margin="0,10,0,0"/>
      <Label Text="{Binding Subject.Name}" />

      <Label Text="Subject Image is:" Margin="0,10,0,0"/>
      <Image Source="{Binding Subject.Picture, Mode=OneWay, TargetNullValue=camera}" Aspect="AspectFit" HeightRequest="220" WidthRequest="255" />
    </VerticalStackLayout>
  </ScrollView>

</ContentPage>

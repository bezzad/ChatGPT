using System.Runtime.InteropServices;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.VisualTree;
using ChatGPT.UI.Model.Services;
using ChatGPT.UI.Services;
using CommunityToolkit.Mvvm.DependencyInjection;

namespace ChatGPT.UI.Views;

public partial class MainView : UserControl
{
    private bool _draggingWindow;

    public MainView()
    {
        InitializeComponent();

        ClippyImage.PointerPressed += (_, e) =>
        {
            if (e.GetCurrentPoint(this).Properties.IsLeftButtonPressed)
            {
                MoveDrag(e);
            }
        };

        ClippyImage.PointerReleased += (_, e) =>
        {
            if (_draggingWindow)
            {
                EndDrag(e);
            }
        };
    }

    private void ThemeButton_OnClick(object? sender, RoutedEventArgs e)
    {
        var app = Ioc.Default.GetService<IApplicationService>();
        if (app is { })
        {
            app.ToggleTheme();
        }
    }

    private void MoveDrag(PointerPressedEventArgs e)
    {
        _draggingWindow = true;

        (this.GetVisualRoot() as Window)?.BeginMoveDrag(e);
            
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
        {
            EndDrag(e);
        }
    }

    private void EndDrag(PointerEventArgs e)
    {
        _draggingWindow = false;
    }
}

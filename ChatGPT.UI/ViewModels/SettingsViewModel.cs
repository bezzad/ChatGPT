using System.Text.Json.Serialization;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace ChatGPT.UI.ViewModels;

public partial class SettingsViewModel : ObservableObject
{
    private decimal _temperature;
    private int _maxTokens;
    private string? _apiKey;
    private ActionsViewModel? _actions;

    public SettingsViewModel()
    {
        NewCommand = new AsyncRelayCommand(async () =>
        {
            if (_actions?.New is { })
            {
                await _actions.New();
            }
        });

        OpenCommand = new AsyncRelayCommand(async () =>
        {
            if (_actions?.Open is { })
            {
                await _actions.Open();
            }
        });

        SaveCommand = new AsyncRelayCommand(async () =>
        {
            if (_actions?.Save is { })
            {
                await _actions.Save();
            }
        });

        ExportCommand = new AsyncRelayCommand(async () =>
        {
            if (_actions?.Export is { })
            {
                await _actions.Export();
            }
        });

        ExitCommand = new RelayCommand(() =>
        {
            _actions?.Exit?.Invoke();
        });
    }

    [JsonPropertyName("temperature")]
    public decimal Temperature
    {
        get => _temperature;
        set => SetProperty(ref _temperature, value);
    }

    [JsonPropertyName("maxTokens")]
    public int MaxTokens
    {
        get => _maxTokens;
        set => SetProperty(ref _maxTokens, value);
    }

    [JsonPropertyName("apiKey")]
    public string? ApiKey
    {
        get => _apiKey;
        set => SetProperty(ref _apiKey, value);
    }

    [JsonIgnore]
    public IAsyncRelayCommand NewCommand { get; }

    [JsonIgnore]
    public IAsyncRelayCommand OpenCommand { get; }

    [JsonIgnore]
    public IAsyncRelayCommand SaveCommand { get; }

    [JsonIgnore]
    public IAsyncRelayCommand ExportCommand { get; }

    [JsonIgnore]
    public IRelayCommand ExitCommand { get; }

    public void SetActions(ActionsViewModel? actions)
    {
        _actions = actions;
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace ChatGPT.UI.Model.Services;

public interface IApplicationService
{
    Task OpenFile(Func<Stream, Task> callback, List<string> fileTypes, string title);
    Task SaveFile(Func<Stream, Task> callback, List<string> fileTypes, string title, string fileName, string defaultExtension);
    void ToggleTheme();
    void Exit();
}

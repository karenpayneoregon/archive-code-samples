# About

[Globbing](https://docs.microsoft.com/en-us/dotnet/api/microsoft.extensions.filesystemglobbing?view=dotnet-plat-ext-5.0) is an alternate way to search for information on disk via patterns. Although there are 529M downloads not much is out there than spare Microsoft documention yet well worth checking out.

**Key features**: [patterns](https://docs.microsoft.com/en-us/dotnet/api/microsoft.extensions.filesystemglobbing.matcher?view=dotnet-plat-ext-5.0#remarks)

- Include patterns
- Exclude patterns

So let's say you want all .png files in a folder or all .png files in a folder and subfolders, using include and exclude patterns make this possible and more.

**See also**: [Methods](https://docs.microsoft.com/en-us/dotnet/api/microsoft.extensions.filesystemglobbing.matcherextensions?view=dotnet-plat-ext-5.0)

How to use GlobbingOperations class

- Add a reference from NuGet [FileSystemGlobbing](https://www.nuget.org/packages/Microsoft.Extensions.FileSystemGlobbing/6.0.0-rc.2.21480.5)
- Change namespace `WinApp2` to your namespace.
- Change parameter to `Sample1` to an existing folder
- Change patterns in `figure 1` to your search pattern

**Figure 1**

```csharp
matcher.AddIncludePatterns(new[] { "*.pdf", "**/*.ico" });
```

```csharp
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Extensions.FileSystemGlobbing;
using Microsoft.Extensions.FileSystemGlobbing.Abstractions;
using WinApp2.Classes;

namespace WinApp2
{
    public partial class GlobbingForm : Form
    {
        public GlobbingForm()
        {
            InitializeComponent();

            Shown += OnShown;
        }

        private void OnShown(object sender, EventArgs e)
        {
            GlobbingOperations.TraverseHandler += GlobbingOperationsOnTraverseHandler;
            GlobbingOperations.Done += GlobbingOperationsOnDone;
            GlobbingOperations.Sample1("C:\\Users\\paynek\\Documents\\Snagit\\");

            OtherSample();
        }

        private static void OtherSample()
        {
            DirectoryInfoBase directoryInfoBase = new DirectoryInfoWrapper(
                new DirectoryInfo("C:\\Users\\paynek\\Documents\\Snagit\\"));

            GlobbingOperations.IncludePatterns = new List<string>() { "*.pdf", "**/*.ico" };
            PatternMatchingResult result = GlobbingOperations.Sample2(directoryInfoBase);
        }

        private void GlobbingOperationsOnDone()
        {
            if (listBox1.Items.Count >0)
            {
                Height += 30;
                listBox1.SelectedIndex = 0;
                ActiveControl = listBox1;
            }
            
        }

        private void GlobbingOperationsOnTraverseHandler(string sender)
        {
            listBox1.Items.Add(sender);
        }
    }
}

```
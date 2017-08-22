@echo off
NuGet.exe install MSBuildTasks -OutputDirectory .\Tools\ -ExcludeVersion -NonInteractive
NuGet.exe install Microsoft.CodeAnalysis.CSharp -OutputDirectory .\packages\ -ExcludeVersion -NonInteractive

using System.Diagnostics;
using UnityEditor;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class TortoiseGitEditor
{
    private const string quota = "\"";

    public const string COMMAND_TORTOISE_LOG = @"/command:log /path:{0} /findtype:0 /closeonend:0";
    public const string COMMAND_TORTOISE_PULL = @"/command:pull /path:{0} /closeonend:0";
    public const string COMMAND_TORTOISE_COMMIT = @"/command:commit /path:{0} /closeonend:0";
    public const string COMMAND_TORTOISE_PUSH = @"/command:push /path:{0} /closeonend:0";
    public const string COMMAND_TORTOISE_STASHSAVE = @"/command:stashsave /path:{0} /closeonend:0";
    public const string COMMAND_TORTOISE_STASHPOP = @"/command:stashpop /path:{0} /closeonend:0";
    public static string tortoiseGitPath = @"E:\TortoiseGit\bin\TortoiseGitProc.exe";

    //[MenuItem("TortoiseGit/StashSave")]
    public static void GitAssetsStushSave()
    {
        //TortoiseGit.GitCommand(GitType.StashSave, Application.dataPath, tortoiseGitPath);
    }

    //[MenuItem("TortoiseGit/StashPop")]
    public static void GitAssetsStushPop()
    {
        //TortoiseGit.GitCommand(GitType.StashPop, Application.dataPath, tortoiseGitPath);
    }

    [MenuItem("Tools/TortoiseGit/Push")]
    public static void GitAssetPush()
    {
        //TortoiseGit.GitCommand(GitType.Push, Application.dataPath, tortoiseGitPath);
        ProcessCommand(COMMAND_TORTOISE_PUSH);
    }

    [MenuItem("Tools/TortoiseGit/Log")]
    public static void GitAssetsLog()
    {
        ProcessCommand(COMMAND_TORTOISE_LOG);
    }

    [MenuItem("Tools/TortoiseGit/Pull")]
    public static void GitAssetsPull()
    {
        //TortoiseGit.GitCommand(GitType.Pull, Application.dataPath, tortoiseGitPath);
        ProcessCommand(COMMAND_TORTOISE_PULL);
    }

    [MenuItem("Tools/TortoiseGit/Commit")]
    public static void GitAssetsCommit()
    {
        //TortoiseGit.GitCommand(GitType.Commit, Application.dataPath, tortoiseGitPath);
        ProcessCommand(COMMAND_TORTOISE_COMMIT);
    }

    public static void ProcessCommand(string command)
    {
        string path = Application.dataPath;
        var args = quota + path + quota;
        args = string.Format(command, args);
        // Process process = ProcessCommand("TortoiseGitProc.exe", args);
        // process.Start();
        ProcessStartInfo info = new ProcessStartInfo("TortoiseGitProc.exe");
        info.Arguments = args;
        info.CreateNoWindow = false;
        info.ErrorDialog = true;
        info.UseShellExecute = true;

        if(info.UseShellExecute){
            info.RedirectStandardOutput = false;
            info.RedirectStandardError = false;
            info.RedirectStandardInput = false;
        } else{
            info.RedirectStandardOutput = true;
            info.RedirectStandardError = true;
            info.RedirectStandardInput = true;
            info.StandardOutputEncoding = System.Text.UTF8Encoding.UTF8;
            info.StandardErrorEncoding = System.Text.UTF8Encoding.UTF8;
        }

        System.Diagnostics.Process process = System.Diagnostics.Process.Start(info);

        if(!info.UseShellExecute){
            Debug.Log(process.StandardOutput);
            Debug.Log(process.StandardError);
        }

        process.WaitForExit();
        process.Close();
    }
}
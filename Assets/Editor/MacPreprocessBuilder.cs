//#if UNITY_EDITOR && UNITY_UNITY_EDITOR_OSX
#if UNITY_EDITOR 
using UnityEditor.Build;
using UnityEditor.Build.Reporting;

public class MacPreprocessBuilder : IPreprocessBuildWithReport {
    public int callbackOrder => 1;
    public void OnPreprocessBuild (BuildReport report) {
       // System.Environment.SetEnvironmentVariable ("EMSDK_PYTHON", "/Library/Frameworks/Python.framework/Versions/3.10/bin/python3.10");
          System.Environment.SetEnvironmentVariable("EMSDK_PYTHON", "/Library/Frameworks/Python.framework/Versions/2.7/bin/python");
    }
}

#endif
using UnityEditor;
using UnityEditor.Build;
using UnityEditor.iOS.Xcode;
using UnityEngine;
using System.IO;

class ModifyPlistBuildProcessor : IPostprocessBuild
{
    public int callbackOrder { get { return 0; } }
    public void OnPostprocessBuild(BuildTarget target, string path)
    {
    	if (target == BuildTarget.iOS) {
	        Debug.Log("ModifyPlistBuildProcessor.OnPostprocessBuild for target " + target + " at path " + path);
			string plistPath = path + "/Info.plist";
            PlistDocument plist = new PlistDocument();
            plist.ReadFromString(File.ReadAllText(plistPath));
       
            // Get root
            PlistElementDict rootDict = plist.root;
       
            /*
elements_to_add = '''
<key>CFBundleURLTypes</key>
<array>
 <dict>
  <key>CFBundleURLSchemes</key>
  <array>
   <string>''' + bundle_id + '''</string>
  </array>
 </dict>
</array>
'''
            */
            var buildKey = "CFBundleURLTypes";
            var urlArray = rootDict.CreateArray(buildKey);
            var urlDict = urlArray.AddDict();
            var schemeArray = urlDict.CreateArray("CFBundleURLSchemes");
            schemeArray.AddString("com.suntomi.tweeter");

            // Write to file
            File.WriteAllText(plistPath, plist.WriteToString());
	    }
    }
}

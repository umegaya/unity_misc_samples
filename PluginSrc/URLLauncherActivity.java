package com.suntomi.util;

import android.content.Intent;
import android.os.Bundle;
import android.app.Activity;
import android.util.Log;
import com.unity3d.player.UnityPlayer;
import com.unity3d.player.UnityPlayerActivity;
 
public class URLLauncherActivity extends Activity {
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        Log.v("Unity", "URLLauncherActivity start");
        super.onCreate(savedInstanceState);
        String url = getIntent().getDataString();
        try {
            Intent intent = new Intent(this, UnityPlayerActivity.class);
            intent.addFlags(Intent.FLAG_ACTIVITY_CLEAR_TOP | Intent.FLAG_ACTIVITY_SINGLE_TOP);
            if (null != intent.resolveActivity(getPackageManager())) {
                startActivity(intent);
            }
        } catch (java.lang.Exception e) {
            Log.v("Unity", "fail to launch UnityPlayerActivity:" + e.getMessage());
        }

        int flags = getIntent().getFlags();
        if ((flags & Intent.FLAG_ACTIVITY_LAUNCHED_FROM_HISTORY) != 0) {
            // The activity was launched from history
            // remove extras here
            Log.v("Unity", "launch from history");
        } else {
            // this calls the LaunchFromUrl method in the Start GameObject's script in our Unity project
            Log.v("Unity", "try send message:" + url);
            UnityPlayer.UnitySendMessage("URLLauncher", "Launch", url);
        }

        Log.v("Unity", "finish url launch");
        finish();
    }
}

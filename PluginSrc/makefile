UNITY_CLASSES_JAR=/Applications/Unity/PlaybackEngines/AndroidPlayer/Variations/mono/Release/Classes/classes.jar
TARGET_JAR=URLLauncher.jar

jar:
	JAVA_HOME=$(JAVA7_HOME) javac -classpath $(ANDROID_SDK)/platforms/android-23/android.jar:$(UNITY_CLASSES_JAR) -d ./build *.java
	JAVA_HOME=$(JAVA7_HOME) cd build && jar cvf $(TARGET_JAR) *
	JAVA_HOME=$(JAVA7_HOME) cp build/$(TARGET_JAR) ../Assets/Plugins/Android/
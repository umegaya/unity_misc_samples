#import "AppDelegateListener.h"

@interface OpenURLDelegateListener : NSObject <AppDelegateListener>
@end

@implementation OpenURLDelegateListener

static OpenURLDelegateListener *_instance = nil;

+ (void)load {
    if(!_instance) {
        _instance = [[OpenURLDelegateListener alloc] init];
    }
}

- (id)init {
    self = [super init];
    if(!self)
        return nil;
    
    _instance = self;
    
    // register to unity
    UnityRegisterAppDelegateListener(self);
    
    return self;
}

- (void)didRegisterForRemoteNotificationsWithDeviceToken:(NSNotification*)notification {
    NSLog(@"didRegisterForRemoteNotificationsWithDeviceToken was called!");
}

- (void)didFailToRegisterForRemoteNotificationsWithError:(NSNotification*)notification {
    NSLog(@"didFailToRegisterForRemoteNotificationsWithError was called!");
}

- (void)didReceiveRemoteNotification:(NSNotification*)notification {
    NSLog(@"didReceiveRemoteNotification was called!");
}

- (void)didReceiveLocalNotification:(NSNotification*)notification {
    NSLog(@"didReceiveLocalNotification was called!");
}

- (void)onOpenURL:(NSNotification*)notification {
    NSLog(@"onOpenURL was called!");

    const char *URLString = [[[notification.userInfo valueForKey:@"url"] absoluteString] UTF8String];
    NSLog( @"url used to open app: %s", URLString );
    
    UnitySendMessage("URLLauncher", "Launch", URLString);
}

- (void)applicationDidReceiveMemoryWarning:(NSNotification*)notification {
    NSLog(@"applicationDidReceiveMemoryWarning was called!");
}

- (void)applicationSignificantTimeChange:(NSNotification*)notification {
    NSLog(@"applicationSignificantTimeChange was called!");
}

- (void)applicationWillChangeStatusBarFrame:(NSNotification*)notification {
    NSLog(@"applicationWillChangeStatusBarFrame was called!");
}

- (void)applicationWillChangeStatusBarOrientation:(NSNotification*)notification {
    NSLog(@"applicationWillChangeStatusBarOrientation was called!");
}

@end

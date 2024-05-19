import { SafeAreaProvider } from "react-native-safe-area-context";
import { NavigationContainer } from "@react-navigation/native";
import { createStackNavigator } from "@react-navigation/stack";
import Onboarding from "@/onboarding/onBoarding";

const AppStack = createStackNavigator();

export default function App() {
  return (
    <SafeAreaProvider>
      <NavigationContainer>
        <AppStack.Navigator>
          <AppStack.Screen
            name="Onboarding"
            component={Onboarding}
            options={{headerShown:false}}
          ></AppStack.Screen>
        </AppStack.Navigator>
      </NavigationContainer>
    </SafeAreaProvider>
  );
}

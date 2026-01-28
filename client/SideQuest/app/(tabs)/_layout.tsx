import '../../global.css'; 
import { Tabs } from 'expo-router';
import FontAwesome5 from '@expo/vector-icons/FontAwesome5';
import MaterialIcons from '@expo/vector-icons/MaterialIcons';
import Entypo from '@expo/vector-icons/Entypo';
import { View } from 'react-native';

export default function TabsLayout() {
    return (
        <Tabs initialRouteName='dashboard' screenOptions={{tabBarStyle: {backgroundColor: '#999999'} ,tabBarActiveTintColor: "#ffffff", tabBarInactiveTintColor: '#c5c5c5' }}>
            <Tabs.Screen 
                name='shop'
                options={{
                    headerShown: false,
                    tabBarLabel: 'Shop',
                    tabBarIcon: ({ color }) => (
                        <Entypo name='shop' color={color} size={30}/>
                    ),
                }}  
            />

            <Tabs.Screen 
                name='dashboard'
                options={{
                    headerShown: false,
                    tabBarLabel: () => null,
                    tabBarIcon: ({ focused }) => (
                        <View className={"w-20 h-20 rounded-full items-center justify-center -mt-8 border-4 border-[#797979] " + (focused ? 'bg-[#D9D9D9]' : 'bg-[#B3B3B3]')}>
                            <FontAwesome5 name='scroll' color={'#fff'} size={30}/>
                        </View>
                    ),
                }}  
            />

            <Tabs.Screen 
                name='leaderboard'
                options={{
                    headerShown: false,
                    tabBarLabel: 'Leaderboard',
                    tabBarIcon: ({ color }) => (
                        <MaterialIcons name='leaderboard' color={color} size={30}/>
                    ),
                }}  
            />
        </Tabs>
    );
}
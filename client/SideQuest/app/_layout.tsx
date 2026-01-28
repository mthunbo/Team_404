import '../global.css'; 
import { Stack } from 'expo-router';

export default function RootLayout() {
    return (
        <Stack>
            <Stack.Screen 
                name="(tabs)" 
                options={{ headerShown: false }} // This hides the STACK's header
            />
            <Stack.Screen 
                name='settings'
                options={{ title: 'Settings' }}
            />
        </Stack>
    );
}
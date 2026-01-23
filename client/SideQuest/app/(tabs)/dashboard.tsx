import React, { useEffect, useState } from 'react';
import { Text, View } from 'react-native';
import { useRouter } from 'expo-router';

export default function Dashboard() {
    return (
        <View className='flex-1 justify-center items-center'>
            <Text className='text-xl text-red-500 font-bold text-center'>This is the Dashboard</Text>
        </View>
    );
}